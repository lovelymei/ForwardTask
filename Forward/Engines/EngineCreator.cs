using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Forward.Engines
{
    internal class EngineCreator : IEngineCreator
    {
        /// <summary>
        /// Создание объекта класса Engine 
        /// </summary>
        /// <param name="dataFilePath">Путь к файлу с данными</param>
        /// <returns></returns>
        public Engine Create(string dataFilePath)
        {
            return JsonConvert.DeserializeObject<Engine>(File.ReadAllText(dataFilePath));
        }
    }
}
