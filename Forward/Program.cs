using Forward.Engines;
using Forward.TestBenches;
using System;

namespace Forward
{
    internal class Program
    {
        static void Main(string[] args)
        {
             IEngineCreator engineCreator = new EngineCreator();
             IEngine engine = engineCreator.Create("../../Data.json");

            double temperature = 0;

            try
            {
                Console.WriteLine("Enter the air temperature");
                temperature = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            ITestBench bench = new TestBench();
            engine.Attach(bench);
            bench.TurnOnTheEngine(engine, temperature);
            Console.ReadLine();
        }
    }
}
