using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace HappyBirthday.BL.Controller
{
    /// <summary>
	/// Базовый контроллер.
	/// </summary>
	public abstract class ControllerBase
    {
        /// <summary>
        /// Сохраняет данные.
        /// </summary>
        /// <typeparam name="T"> Класс сохраняемого элемента. </typeparam>
        /// <param name="items"> Список элементов для сохранения. </param>
        protected void Save<T>(List<T> items) where T : class
        {
            var formatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"data\\{typeof(T).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.WriteObject(fs, items);
            }
        }

        /// <summary>
        /// Загружает данные.
        /// </summary>
        /// <typeparam name="T"> Класс загружаемого элемента. </typeparam>
        /// <returns> Список элементов. </returns>
        protected List<T> Load<T>() where T : class
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }          

            var formatter = new DataContractJsonSerializer(typeof(List<T>));
            var fileName = $"data\\{typeof(T).Name}s.json";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                {
                    var items = formatter.ReadObject(fs);

                    if (items is List<T>)
                    {
                        return (List<T>)items;
                    }
                }               
            }

            return new List<T>();
        }
    }
}
