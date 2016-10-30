using System.Windows.Forms;
using csTask5_DuoDuoNatureBlance.Properties;

namespace csTask5_DuoDuoNatureBlance
{
    /// <summary> Класс, связывающий двухпутевую двухфазную естественную сбалансированную сортировку
    /// с графическим интерфейсом. 
    /// </summary>
    public class GuiSequences: Sequences
    {
        /// <summary> Текстовое поле, в которое выводятся данные неотсортированного файла
        /// </summary>
        private readonly TextBox _textBoxIn;
        
        /// <summary> Текстовое поле, в которое выводятся данные отсортированного файла
        /// </summary>
        private readonly TextBox _textBoxOut;
        
        /// <summary> Инициализация данных
        /// </summary>
        /// <param name="filename">Имя исходного файла</param>
        /// <param name="textboxIn">Поле вывода исходных данных</param>
        /// <param name="textBoxOut">Поле вывода результата сортировки</param>
        public GuiSequences(string filename, TextBox textboxIn, TextBox textBoxOut) : base(filename)
        {
            _textBoxIn = textboxIn;
            _textBoxOut = textBoxOut;         
        }

        /// <summary> Создание файла случайных чисел с выводом значений в текстовое поле
        /// </summary>
        /// <param name="size">Размер файла</param>
        /// <param name="min">Минимальная величина элемента файла</param>
        /// <param name="max">Максимальная величина элемента файла</param>
        public new void GenerateRandomFile(uint size, int min = 1, int max = 3500)
        {            
            base.GenerateRandomFile(size, min, max); 
            ToTextBox(false);
        }

        /// <summary> Создание файла из чисел, записанных в обратном порядке, например
        /// size, size - 1, size - 2, ..., 1;
        /// </summary>
        /// <param name="size">Размер файла</param>
        public new void GenerateReverseFile(uint size)
        {
            base.GenerateReverseFile(size);
            ToTextBox(false);
        }

        /// <summary> Сортировка данных файла с последующим выводом на текстовое поле
        /// </summary>
        public new void Sort()
        {
            base.Sort();
            ToTextBox(true);
        }

        /// <summary> Сортировка с заполнением информации в таблицу результатов
        /// </summary>
        /// <param name="gridRand">Результат заполнения случайными числами</param>
        /// <param name="gridReverse">Результат заполнения числами в обратном порядке</param>
        public void RatioSort(DataGridView gridRand, DataGridView gridReverse)
        {
            RatioSort(1000, 5000, 10000, gridRand, gridReverse);
        }

        /// <summary> Сортировка с заполнением информации в таблицу результатов.
        /// Происходит в три итерации, таблица состоит из трех строк
        /// </summary>
        /// <param name="one">Размер файла на первой итерации</param>
        /// <param name="two">Размер файла на второй итерации</param>
        /// <param name="three">Размер файла на третьей итерации</param>
        /// <param name="gridRand">Таблица, предназначеннная для данных о случайном заполнении</param>
        /// <param name="gridReverse">Таблица, предназначенная для данных о обратном заполнении</param>
        private void RatioSort(uint one, uint two, uint three, DataGridView gridRand, DataGridView gridReverse)
        {
            _textBoxIn.Clear();
            _textBoxOut.Clear();
            GenAndFill(true, one, gridRand, 0);
            GenAndFill(true, two, gridRand, 1);
            GenAndFill(true, three, gridRand, 2);   
            GenAndFill(false, one, gridReverse, 0);
            GenAndFill(false, two, gridReverse, 1);
            GenAndFill(false, three, gridReverse, 2);            
        }

        /// <summary> Создание файла специальным образом 
        /// и заполнение данных о результатах его сортировки
        /// </summary>
        /// <param name="isRandomGen">Способ создания файла. Файл случайных чисел, если TRUE</param>
        /// <param name="size">Размер созданного файла</param>
        /// <param name="grid">Таблица, в которую вывести результат</param>
        /// <param name="row">Строка вывода</param>
        private void GenAndFill(bool isRandomGen, uint size, DataGridView grid, int row)
        {
            if (isRandomGen)
                GenerateRandomFile(size);
            else 
                GenerateReverseFile(size);
            base.Sort();
            InfoToGrid(grid, row);
        }

        /// <summary> Печать информации из файла
        /// Если это не информация о результате сортировки, 
        /// соответствующее выходной информации поле очищается
        /// </summary>
        /// <param name="isOutInformation">Является ли значение информацией о результате сортировки</param>
        private void ToTextBox(bool isOutInformation)
        {
            var tmp = !isOutInformation ? _textBoxIn : _textBoxOut;            
            tmp.Clear();
            tmp.Lines = ToStringList().ToArray();            
            if (!isOutInformation)
                _textBoxOut.Clear();
        }

        /// <summary> Заполнение строки таблицы информацией о результатах сортировки
        /// </summary>
        /// <param name="grid">Таблица для записи информации</param>
        /// <param name="row">Строка записи</param>
        public void InfoToGrid(DataGridView grid, int row)
        {
            grid.Rows[row].Cells[1].Value = Counter.OfTime;
            grid.Rows[row].Cells[2].Value = Counter.OfCompare;
            grid.Rows[row].Cells[3].Value = Counter.OfCycling;
        }

        /// <summary> Инициализация таблицы результатов сортировки
        /// </summary>
        /// <param name="grid">Таблица, требующая форматирования</param>
        public static void InitGridView(DataGridView grid)
        {            
            grid.ColumnCount = 4;
            grid.RowCount = 3;            
            CalcGridSize(grid);
            grid.Columns[0].HeaderText = Resources.headerElements;
            grid.Columns[1].HeaderText = Resources.headerTimes;            
            grid.Columns[2].HeaderText = Resources.headerCmp;
            grid.Columns[3].HeaderText = Resources.headerIter;
            grid.Rows[0].Cells[0].Value = "1000";
            grid.Rows[1].Cells[0].Value = "5000";
            grid.Rows[2].Cells[0].Value = "10000";                        
        }

        /// <summary> Вычисление размеров таблицы, в которую будет выводитсья результат
        /// </summary>
        /// <param name="grid">Таблица для вывода результатов, нуждающаяся в форматировании</param>
        public static void CalcGridSize(DataGridView grid)
        {                        
            for (int i = 0; i < grid.ColumnCount; ++i)
                grid.Columns[i].Width = (grid.Width - grid.RowHeadersWidth) / 4 - 1;
            for (int i = 0; i < grid.RowCount; ++i)
                grid.Rows[i].Height = (grid.Height - grid.ColumnHeadersHeight) / 3 - 1;         
        }

    }
}