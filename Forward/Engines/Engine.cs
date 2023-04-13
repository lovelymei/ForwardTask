using Forward.TestBenches;
using System; 

namespace Forward.Engines
{
    public class Engine :IEngine
    {
        /// <summary>
        /// Флаг, работает ли двигатель
        /// </summary>
        public bool isRunning { get; set; } = false;
        /// <summary>
        /// Момент инерции двигателя
        /// </summary>
        public double I { get; set; }
        /// <summary>
        ///  Кусочно-линейная зависимость крутящего момента, вырабатываемого двигателем
        /// </summary>
        public int[] M { get; set; }
        /// <summary>
        /// Cкорость вращения коленвала
        /// </summary>
        public int[] V { get; set; }

        /// <summary>
        /// Температура перегрева
        /// </summary>
        public double T { get; set; }
        /// <summary>
        /// Коэффициент зависимости скорости нагрева от крутящего момент
        /// </summary>
        public double Hm { get; set; }
        /// <summary>
        /// Коэффициент зависимости скорости нагрева от скорости вращения коленвала
        /// </summary>
        public double Hv { get; set; }
        /// <summary>
        /// Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды
        /// </summary>
        public double C { get; set; }
        /// <summary>
        /// Температура двигателя
        /// </summary>
        public double EngineTemperature { get; set; }
        /// <summary>
        /// Температура воздуха
        /// </summary>
        public double AirTemperature { get; set; }
        /// <summary>
        /// индекс (для массива)
        /// </summary>
        private int index = 0;

        /// <summary>
        /// Тестовый стенд
        /// </summary>
        private ITestBench _testBench = null;

        /// <summary>
        /// Свойство для поля index
        /// </summary>
        private int Index { get => index; set => index = value; }

        /// <summary>
        /// Время работы (секунды)
        /// </summary>
        private double _runTime;

        /// <summary>
        /// Свойство для поля _runTime
        /// </summary>
        public double RunTime { get => _runTime; set => _runTime = value; }

        /// <summary>
        /// Конструктор класса Engine
        /// </summary>
        public Engine() { }

        /// <summary>
        /// Найти скорость охлаждения двигателя
        /// </summary>
        private double FindVc() => (M[Index] + Hm + Math.Pow(V[Index], 2) + Hv);

        /// <summary>
        /// Найти скорость нагрева двигателя
        /// </summary>
        private double FindVh() => (C * (AirTemperature - EngineTemperature));

       /// <summary>
       /// Симулировать работу двигателя
       /// </summary>
       /// <param name="airTemp">Температура воздуха</param>
       public void Simulate(double airTemp)
        {
            //Задание изначальных значений
            isRunning = true;
            RunTime = 0;

            AirTemperature = airTemp;
            EngineTemperature = airTemp;

            double v = V[0];
            double m = M[0];
            double a = m / I;

            
            //Собственно, процесс работы двигателя
            while (isRunning)
            {
                RunTime++;
                v += a;
                if (Index < M.Length - 2)
                {
                    Index += v < M[Index + 1] ? 0 : 1;
                }

                double up = v - V[Index];
                double down = V[Index + 1] - V[Index];
                double factor = M[Index + 1] - M[Index];
                m = up / down * factor + M[Index];
                EngineTemperature += FindVc() + FindVh();
                a = m / I;
                _testBench.CheckTemperature(this);
            }

        }

        /// <summary>
        /// Присоединить тестовый стенд
        /// </summary>
        /// <param name="bench">Тестовый стенд</param>
        public void Attach(ITestBench bench)
        {
            _testBench = bench;
        }
    }
}
