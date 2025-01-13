using System;
using System.Runtime.Serialization;

namespace HappyBirthday.BL.Model
{
    /// <summary>
    /// Житель.
    /// </summary>
    [DataContract]
    public class Citizen
    {
        /// <summary>
        /// Создаёт нового жителя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="birthdayMonth"> Месяц рождения. </param>
        public Citizen(string name, int birthdayMonth)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя жителя не может быть пустым.", nameof(name));
            }

            if (birthdayMonth < 1 || birthdayMonth > 12)
            {
                throw new ArgumentException("Месяц рождения не может быть меньше 1 или больше 12.", nameof(birthdayMonth));
            }

            Name = name;
            BirthdayMonth = birthdayMonth;
        }

        /// <summary>
        /// Имя.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Месяц рождения.
        /// </summary>
        [DataMember]
        public int BirthdayMonth { get; set; }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (obj is Citizen)
            {
                Citizen citizen = (Citizen)obj;
                return Name == citizen.Name && BirthdayMonth == citizen.BirthdayMonth;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
