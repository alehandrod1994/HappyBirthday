using System;

namespace HappyBirthday.BL.Model
{
    /// <summary>
    /// Годовщина свадьбы.
    /// </summary>
    public class Wedding
    {
        /// <summary>
        /// Создаёт новую годовщину свадьбы.
        /// </summary>
        /// <param name="age"> Номер годовщины свадьбы. </param>
        /// <param name="weddingType"> Тип свадьбы. </param>
        /// <param name="marrieds"> Супруги. </param>
        /// <param name="poem"> Стихотворение. </param>
        /// <param name="date"> Дата годовщины свадьбы. </param>
        public Wedding(int age, WeddingType weddingType, string marrieds, string poem, DateTime date)
        {
            #region Проверка входных параметров
            if (age < 20 || age > 100)
            {
                throw new ArgumentException("Годовщина свадьбы не может быть меньше 20 или больше 100.", nameof(age));
            }

            if (string.IsNullOrWhiteSpace(marrieds))
            {
                throw new ArgumentNullException("Имена супругов не могут быть пустыми.", nameof(marrieds));
            }

            if (string.IsNullOrWhiteSpace(poem))
            {
                throw new ArgumentNullException("Стихотворение не может быть пустым.", nameof(poem));
            }

            if (date.Year < 2024)
            {
                throw new ArgumentException("Год поздравления не может быть меньше 2024.", nameof(date));
            }
            #endregion

            Age = age;
            WeddingType = weddingType;
            Marrieds = marrieds;
            Poem = poem;
            Date = date;
        }

        /// <summary>
        /// Номер годовщины свадьбы.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Тип свадьбы.
        /// </summary>
        public WeddingType WeddingType { get; set; }

        /// <summary>
        /// Супруги.
        /// </summary>
        public string Marrieds { get; set; }

        /// <summary>
        /// Поздравительное стихотворение с годовщиной свадьбы. 
        /// </summary>
        public string Poem { get; set; }

        /// <summary>
        /// Дата годовщины свадьбы.
        /// </summary>
        public DateTime Date { get; set; }

        public override string ToString() => $"{Age} лет - {Marrieds}";
    }
}
