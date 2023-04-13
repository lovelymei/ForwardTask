
namespace Forward.Engines
{
    internal interface IEngineCreator
    {
        /// <summary>
        /// Создание объекта класса Engine 
        /// </summary>
        /// <param name="dataFilePath">Путь к файлу с данными</param>
        /// <returns></returns>
        Engine Create(string dataFilePath);
    }
}
