using System.IO;

namespace csTask5_DuoDuoNatureBlance
{
    /// <summary> Класс, описывающий естественную последовательность, 
    /// используемую для внешней сортировки
    /// </summary>
    public class NatureSequence
    {
        /// <summary> Поток для чтения/записи файла
        /// </summary>
        public FileStream FileOfSeq { get; private set; }
        
        /// <summary> Средство чтения из файла 
        /// </summary>
        private BinaryReader _reader;

        /// <summary> Средство записи в файл 
        /// </summary>
        private BinaryWriter _writer;

        /// <summary> Имя связанного с последовательностью файла
        /// </summary>
        private readonly string _filename;

        /// <summary> Текущее значение последовательности
        /// </summary>
        public int CurrentValue { get; private set; }

        /// <summary> Признак конца последовательности
        /// </summary>
        public bool EndOfSequence { get; private set; }

        /// <summary> Признак конца файла
        /// </summary>
        public bool EndOfFile { get; private set; }

        /// <summary> Инициализация объекта
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public NatureSequence(string filename)
        {
            _filename = filename;            
        }

        /// <summary> Закрытие связанного с потоком файла
        /// </summary>
        public void Close()
        {
            FileOfSeq.Close();            
        }

        /// <summary> Удаление связанного с потоком файла
        /// </summary>
        public void DeleteFile()
        {
            File.Delete(_filename);
        }

        /// <summary> Копирование информации из текущего файла в другую последовательность,
        /// переданную в качестве параметра
        /// </summary>
        /// <param name="other">Последовательность, в которую будет производиться запись
        /// Должна быть открыта на запись</param>
        /// <returns>Возвращает количество скопированных элементов</returns>
        public int Copy(NatureSequence other)
        {            
            other._writer.Write(CurrentValue);
            other.CurrentValue = CurrentValue;

            EndOfFile = _reader.BaseStream.Position == _reader.BaseStream.Length;
            int res = 0;
            if (!EndOfFile) {
                ++res;
                CurrentValue = _reader.ReadInt32();
            }
            EndOfSequence = EndOfFile || other.CurrentValue > CurrentValue;
            return res;
        }

        /// <summary> Копирование всей последовательности из текущего файла в другой, 
        /// переданный в качестве параметра
        /// </summary>
        /// <param name="other">Последовательность, в которую будет производиться запись 
        /// (в связанный с ней файл)</param>
        /// <returns>Возвращает количество скопированных элементов</returns>
        public int CopySequence(NatureSequence other)
        {
            int res = 0;
            while (!EndOfSequence)
                res += Copy(other);            
            return res;
        }

        /// <summary> Проверка пуст ли файл 
        /// </summary>
        /// <returns>TRUE, если файл пуст</returns>
        public bool EmptyFile()
        {
            return FileOfSeq.Length == 0;
        }

        /// <summary> Фиксация начала следующей серии. 
        /// Новая серия если файл пуст 
        /// </summary>
        public void NextSequence()
        {
            EndOfSequence = EndOfFile;
        }

        /// <summary> Открытие файла с данными на чтение 
        /// </summary>
        public void OpenRead()
        {
            FileOfSeq = new FileStream(_filename, FileMode.OpenOrCreate, FileAccess.Read);
            _reader = new BinaryReader(FileOfSeq);

            EndOfSequence = EndOfFile = EmptyFile();
            if (!EndOfFile)
                CurrentValue = _reader.ReadInt32();
        }

        /// <summary> Открытие файла с данными на запись 
        /// </summary>
        public void OpenWrite()
        {
            FileOfSeq = new FileStream(_filename, FileMode.Create, FileAccess.Write);
            _writer = new BinaryWriter(FileOfSeq);
        }
    }
}