using Forward.ConsoleWriters;
using Forward.Engines;

namespace Forward.TestBenches
{
    public class TestBench :ITestBench
    {
        /// <summary>
        /// Абсолютная погрешность
        /// </summary>
        private double _absoluteError = 0.0000001;

        /// <summary>
        /// Максимальное время работы
        /// </summary>
        private int _maxTime = 100;

        /// <summary>
        /// ДЛя вывода результатов на экран
        /// </summary>
        private IConsoleWriter _consoleWriter = new ConsoleWriter();

        /// <summary>
        /// Конструктор класса TestBench
        /// </summary>
        public TestBench() { }

        /// <summary>
        /// Включить двигатель
        /// </summary>
        /// <param name="engine">Двигатель</param>
        /// <param name="parameters">Параметры</param>
        public void TurnOnTheEngine(IEngine engine, params double[] parameters)
        {
            engine.Attach(this);
            engine.Simulate(parameters[0]);
        }

        /// <summary>
        /// Проверить температуру двигателя
        /// </summary>
        /// <param name="engine">Двигатель </param>
        public void CheckTemperature(Engine engine)
        {
            var epsilon = engine.T - engine.EngineTemperature;
            engine.isRunning = epsilon > _absoluteError && engine.RunTime < _maxTime;
            if (!engine.isRunning)
            {
                if (engine.RunTime < _maxTime)
                {
                    _consoleWriter.WriteNotPassedTestResult(engine.RunTime);
                }
                else
                {
                    _consoleWriter.WritePassedTestResult();
                }
            }
        }
    }
}
