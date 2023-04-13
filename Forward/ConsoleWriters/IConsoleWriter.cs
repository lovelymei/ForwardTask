namespace Forward.ConsoleWriters
{
   public interface IConsoleWriter
    {
        /// <summary>
        /// Вывод результатов при непройденном тесте
        /// </summary>
        /// <param name="time">Время работы двигателя</param>
        void WriteNotPassedTestResult(double time);

        /// <summary>
        /// Вывод результатов при пройденном тесте
        /// </summary>
        void WritePassedTestResult();
    }
}
