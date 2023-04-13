using Forward.Engines;

namespace Forward.TestBenches
{
    public interface ITestBench
    {
        /// <summary>
        /// Включить двигатель
        /// </summary>
        /// <param name="engine">Двигатель</param>
        /// <param name="parameters">Параметры</param>
        void TurnOnTheEngine(IEngine engine, params double[] parameters);

        /// <summary>
        /// Проверить температуру двигателя
        /// </summary>
        /// <param name="engine">Двигатель </param>
        void CheckTemperature(Engine engine);
    }
}
