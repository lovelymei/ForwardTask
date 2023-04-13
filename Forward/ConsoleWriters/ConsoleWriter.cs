using System;

namespace Forward.ConsoleWriters
{
    public class ConsoleWriter : IConsoleWriter
    {
        public ConsoleWriter() { }
        /// <summary>
        /// Вывод результатов при непройденном тесте
        /// </summary>
        /// <param name="time">Время работы двигателя</param>
        public void WriteNotPassedTestResult(double time)
        {
            Console.WriteLine("The engine did not pass the test, time = " + time + " seconds");
        }

        /// <summary>
        /// Вывод результатов при пройденном тесте
        /// </summary>
        public void WritePassedTestResult()
        {
            Console.WriteLine("The engine passed the test");
        }
    }
}
