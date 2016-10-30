using System;
using System.Collections.Generic;
using System.IO;

namespace csTask5_DuoDuoNatureBlance
{
    /// <summary> Класс работы с последовательностями, используемыми 
    /// в двухпутевом двухфазном сбалансированном естественном слиянии
    /// </summary>
    public class Sequences
    {
        /// <summary> Источник данных. Будет отсортирован вызовом метода
        /// Хранит информацию о файле и управляет им
        /// </summary>
        private NatureSequence _source;

        /// <summary> Вспомогательные последовательности для двухпутевой сортировки
        /// Связанные с ними временные файлы будут удалены
        /// </summary>
        private NatureSequence _otherTwo, _otherOne;

        /// <summary> Имя файла, в который будет производиться запись
        /// </summary>
        public string Filename { get; protected set; }                

        /// <summary> Счетчик затраченного времени, количества итераций и чтений файлов
        /// </summary>
        public Counter Counter { get; }

        /// <summary> Количество полученных серий. Признак конца сортировки
        /// </summary>
        public int Count { get; private set; }
        
        /// <summary> Инициализация объекта 
        /// </summary>
        /// <param name="filename">Имя файла, который требуется сортировать</param>
        public Sequences(string filename)
        {
            Counter = new Counter();
            Filename = filename;
        }

        /// <summary> Создает файл случайных чисел. Имя файла хранится в поле filename объекта 
        /// </summary>
        /// <param name="size">Количество элементов в файле</param>
        /// <param name="min">Минимальное значение элементов в фалйе</param>
        /// <param name="max">Максимальное значение элементов в файле</param>
        public void GenerateRandomFile(uint size, int min = 1, int max = 3500)
        {            
            FileStream file = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            Random rnd = new Random();
            for (var i = 0; i < size; ++i)
                writer.Write(rnd.Next(min, max));            
            file.Close();
        }

        /// <summary> Создает файл с данными виде: size, size - 1, size - 2, ...., 1;
        /// Таким образом, это файл чисел в количестве size, записанных в обратном порядке
        /// </summary>
        /// <param name="size">Размер файла</param>
        public void GenerateReverseFile(uint size)
        {
            FileStream file = new FileStream(Filename, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            for (uint i = size; i > 0; --i)
                writer.Write(i);
            file.Close();            
        }

        /// <summary> Двухпутевое двухфазное естественное сбалансированное слияние 
        /// </summary>
        public void Sort()
        {
            Counter.SetDefault();

            _source = new NatureSequence(Filename);
            _otherOne = new NatureSequence("natSeq1"); 
            _otherTwo = new NatureSequence("natSeq2"); 

            DateTime firstTime = DateTime.Now;
            do
            {
                Counter.Inc(ECounter.OfCyclint, 1); // запоминаем каждую итерацию 
                Distribute(); // стадия распределения по двум файлам
                Merge(); // стадия слияния
            } while (Count > 1); // пока количество полученных серий больше одной
            DateTime secondTime = DateTime.Now;
            // получаем затраченное время как разность двух показателей: время текущее - время до начала процесса            
            Counter.OfTime = (secondTime - firstTime).TotalMilliseconds; 

            _otherOne.DeleteFile();
            _otherTwo.DeleteFile();
        }

        /// <summary> Распределение серий исходного файла по двум вспомогательным        
        /// </summary>
        private void Distribute()
        {            
            _source.OpenRead();
            Counter.Inc(ECounter.OfReading, 1);

            _otherOne.OpenWrite();
            _otherTwo.OpenWrite();

            // копирование и взятие следующей серии (сначала в первый потом во второй файл)
            CopyAndNextSequence(true);  
            CopyAndNextSequence(false);                

            bool destFirstFile = true;
            // пока не закончился файл-источник, копируем серии поочередно в два файла
            while (!_source.EndOfFile) {
                Counter.Inc(ECounter.OfCompare, 1);
                CopySeqFromDest(ref destFirstFile);
            }
            _source.Close();
            _otherTwo.Close();
            _otherOne.Close();
        }

        /// <summary> Объединение серий из вспомогательных файлов в исходный файл 
        /// </summary>
        private void Merge()
        {
            _source.OpenWrite();
            _otherOne.OpenRead();
            _otherTwo.OpenRead();
            Counter.Inc(ECounter.OfReading, 2);
            Count = 0;

            // пока не конец какого-то из файлов
            while (!_otherOne.EndOfFile && !_otherTwo.EndOfFile) {
                // пока не конец какой-то из последовательностей 
                while (!_otherOne.EndOfSequence && !_otherTwo.EndOfSequence) {
                    Counter.Inc(ECounter.OfCompare, 1);
                    // определяем, в какой последовательности текущий элемент больший
                    var tmp = _otherOne.CurrentValue <= _otherTwo.CurrentValue
                        //если в первой, то последующее копирование произойдет
                        ? _otherOne     // из первой последовательности
                        : _otherTwo;    // иначе из второй
                    tmp.Copy(_source);                    
                }
                
                CopyIfNotEndOfSeq(true);    // если последовательность кончилась, дописываем из другой 
                CopyIfNotEndOfSeq(false);   // (сработает только одно копирование)

                _otherOne.NextSequence();
                _otherTwo.NextSequence();
                ++Count;
            } // while (не конец какого-то файла)

            CopyWhileNotEndOfFile(true);    // копируем до конца файла 
            CopyWhileNotEndOfFile(false);   // (копирование только из одного, не закончившегося файла)

            _source.Close();
            _otherOne.Close();
            _otherTwo.Close();
        }

        /// <summary> Копирование серий в файл-источник пока не закончился вспомогательный файл
        /// </summary>
        /// <param name="destFirstFile">True, если следует копировать из первого вспомогательного файла
        /// false, если из второго </param>
        private void CopyWhileNotEndOfFile(bool destFirstFile)
        {
            var tmp = destFirstFile ? _otherOne : _otherTwo;
            while (!tmp.EndOfFile) {
                Counter.Inc(ECounter.OfCompare, tmp.CopySequence(_source));
                ++Count; 
            }
        }

        /// <summary> Копирование в файл-источник если не конец серии
        /// </summary>
        /// <param name="destFirstFile">True, если следует копировать из первого вспомогательного файла
        /// false, если из второго </param>
        private void CopyIfNotEndOfSeq(bool destFirstFile)
        {
            var tmp = destFirstFile ? _otherOne : _otherTwo;
            if (!tmp.EndOfSequence)
                Counter.Inc(ECounter.OfCompare, tmp.CopySequence(_source));
        }

        /// <summary> Копирование из доп файла и получение следующий серии в файле-источнике
        /// </summary>
        /// <param name="destFirstFile">True, если следует копировать в первый вспомогательный файл
        /// false, если во второй </param>
        private void CopyAndNextSequence(bool destFirstFile)
        {
            if (_source.EndOfFile)
                return;
            var tmp = destFirstFile ? _otherOne : _otherTwo;
            Counter.Inc(ECounter.OfCompare, _source.CopySequence(tmp));
            ++Count;
            _source.NextSequence();
        }

        /// <summary> Копирует серию из основоного файла во вспомогательный
        /// </summary>
        /// <param name="destFirstFile">True, если следует копировать в первый вспомогательный файл
        /// false, если во второй </param>
        private void CopySeqFromDest(ref bool destFirstFile)
        {            
            var tmp = destFirstFile ? _otherOne : _otherTwo;            
            if (_source.CurrentValue >= tmp.CurrentValue) {
                Counter.Inc(ECounter.OfCompare, _source.CopySequence(tmp));
                _source.NextSequence();
            }
            Counter.Inc(ECounter.OfCompare, _source.CopySequence(tmp));
            _source.NextSequence();
            destFirstFile = !destFirstFile;            
        }

        /// <summary> Получение информации о хранимых числах в виде набора строк 
        /// </summary>
        /// <returns>Список чисел в текстовом формате</returns>
        protected List<string> ToStringList()
        {
            List<string> list = new List<string>();
            FileStream stream = new FileStream(Filename, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            while (stream.Position != stream.Length)            
                list.Add(reader.ReadInt32().ToString());            
            stream.Close();
            return list;
        }
        
    }
}