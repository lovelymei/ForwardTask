using Forward.TestBenches;

namespace Forward.Engines
{
    public interface IEngine
    {
        /// <summary>
        /// Симулировать работу двигателя
        /// </summary>
        /// <param name="airTemp">Температура воздуха</param>
        void Simulate(double airTemp);

        /// <summary>
        /// Присоединить тестовый стенд
        /// </summary>
        /// <param name="bench">Тестовый стенд</param>
        void Attach(ITestBench bench);
    }
}
