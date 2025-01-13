using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HappyBirthday.BL.Model
{
    /// <summary>
    /// Поздравительный отчёт.
    /// </summary>
    [DataContract]
    public class Report
    {
        /// <summary>
        /// Создаёт новый поздравительный отчёт.
        /// </summary>
        /// <param name="selectedMonth"> Выбранный месяц. </param>
        public Report() { }

        /// <summary>
        /// Все юбиляры.
        /// </summary>
        [DataMember]
        public List<Citizen> AllAnniversaryCitizens { get; set; } = new List<Citizen>();

        /// <summary>
        /// Выбранные юбиляры.
        /// </summary>
        [DataMember]
        public List<Citizen> SelectedAnniversaryCitizens { get; set; } = new List<Citizen>();

        /// <summary>
        /// Все именинники.
        /// </summary>
        [DataMember]
        public List<Citizen> AllBirthdayCitizens { get; set; } = new List<Citizen>();

        /// <summary>
        /// Выбранные именинники.
        /// </summary>
        [DataMember]
        public List<Citizen> SelectedBirthdayCitizens { get; set; } = new List<Citizen>();

        /// <summary>
        /// Годовщины свадеб.
        /// </summary>
        [DataMember]
        public List<Wedding> Weddings { get; set; } = new List<Wedding>();

        /// <summary>
        /// Поздравительное стихотворение с днём рождения.
        /// </summary>
        [DataMember]
        public string Poem { get; set; } = "";

        /// <summary>
        /// Дополнительная информация.
        /// </summary>
        [DataMember]
        public string Additionally { get; set; } = "";

        /// <summary>
        /// Исходная папка для сохранённого файла.
        /// </summary>
        [DataMember]
        public string SourceDirectory { get; set; } = "";

        /// <summary>
        /// Пусть к сохранённому файлу поздравительного отчёта.
        /// </summary>
        [DataMember]
        public string FilePath { get; set; } = "";

        /// <summary>
        /// Выбранный месяц.
        /// </summary>
        [DataMember]
        public int SelectedMonth { get; set; }

        /// <summary>
        /// Выбранный год.
        /// </summary>
        [DataMember]
        public int SelectedYear { get; set; }       
    }
}
