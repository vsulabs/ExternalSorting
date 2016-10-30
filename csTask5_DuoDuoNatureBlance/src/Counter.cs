namespace csTask5_DuoDuoNatureBlance
{
    /// <summary> Перечисление типов "считаемых" объектов
    /// </summary>
    public enum ECounter
    {
        /// <summary> Если считаются сравнения
        /// </summary>
        OfCompare,        
        
        /// <summary> Если считаются чтения из файла
        /// </summary>
        OfReading,

        /// <summary> Есди считаются итнрации (проходы)
        /// </summary>
        OfCyclint
    }

    /// <summary> класс-счетчик затраченного времени, количества чтений и сравнений
    /// </summary>
    public class Counter
    {
        /// <summary> Затраченное время
        /// </summary>
        public double OfTime { get; set; }

        /// <summary> Количество сравнений 
        /// </summary>
        public int OfCompare { get; private set; }

        /// <summary> Количество чтений файла
        /// </summary>
        public int OfReading { get; private set; }

        /// <summary> Количество итераций, проходов
        /// </summary>
        public int OfCycling { get; private set; }

        public Counter()
        {
            SetDefault();
        }

        /// <summary> Задание начальных значений
        /// </summary>
        public void SetDefault()
        {
            OfTime = OfCompare = OfCycling = OfReading = 0;
        }

        /// <summary> Увеличение некоторого параметра на заданную величину
        /// </summary>
        /// <param name="ec">Изменяемый параметр</param>
        /// <param name="x">Величина, на которую следует изменить счетчик</param>
        public void Inc(ECounter ec, int x) {
            switch (ec)
            {
                case ECounter.OfCompare:
                    OfCompare += x;
                    break;
                case ECounter.OfCyclint:
                    OfCycling += x;
                    break;
                case ECounter.OfReading:
                    OfReading += x;
                    break;                    
            }
        }        

    }
}