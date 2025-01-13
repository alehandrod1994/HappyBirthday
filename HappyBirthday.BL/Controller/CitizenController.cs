using HappyBirthday.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HappyBirthday.BL.Controller
{
    /// <summary>
    /// Контроллер жителя.
    /// </summary>
    public class CitizenController : ControllerBase
    {
        /// <summary>
        /// Создаёт новый контроллер.
        /// </summary>
        public CitizenController()
        {
            Citizens = GetCitizens();
        }

        /// <summary>
        /// Список жителей.
        /// </summary>
        public List<Citizen> Citizens { get; set; }

        /// <summary>
        /// Возвращает список жителей.
        /// </summary>
        /// <returns> Список жителей. </returns>
        public List<Citizen> GetCitizens()
        {
            return Load<Citizen>() ?? new List<Citizen>();
        }

        /// <summary>
        /// Сохраняет данные.
        /// </summary>
        public void Save()
        {
            Save(Citizens);
        }

        /// <summary>
        /// Приводит список жителей в строку, разделяя их запятой.
        /// </summary>
        /// <param name="month"> Месяц рождения. </param>
        /// <returns> Результат операции. </returns>
        public string ToString(int month)
        {
            List<Citizen> citizens = Citizens.Where(c => c.BirthdayMonth == month).ToList();
            return ToString(citizens);
        }

        /// <summary>
        /// Приводит список жителей в строку, разделяя их запятой.
        /// </summary>
        /// <param name="citizens"> Список жителей. </param>
        /// <returns> Результат операции. </returns>
        public string ToString(List<Citizen> citizens)
        {
            StringBuilder inLineCitizenNames = new StringBuilder();

            if (citizens != null)
            {
                foreach (Citizen citizen in citizens)
                {
                    inLineCitizenNames.Append(citizen.Name + ", ");
                }

                if (inLineCitizenNames.Length > 0)
                {
                    inLineCitizenNames = inLineCitizenNames.Remove(inLineCitizenNames.Length - 2, 2);
                }
            }

            return inLineCitizenNames.ToString();
        }

        /// <summary>
        /// Сохраняет жителей.
        /// </summary>
        /// <param name="inLineCitizenNames"> Жители в строковом представлении. </param>
        /// <param name="month"> Месяц рождения. </param>
        public void SaveCitizens(string inLineCitizenNames, int month)
        {
            Citizens.RemoveAll(c => c.BirthdayMonth == month);

            string[] newCitizenNames = Regex.Replace(inLineCitizenNames, @"\s+", " ")
                                            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (newCitizenNames.Length == 0) return;
            
            for (int i = 0; i < newCitizenNames.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(newCitizenNames[i])) continue;

                newCitizenNames[i] = RemoveWhiteSpace(0, newCitizenNames[i]);
                newCitizenNames[i] = RemoveWhiteSpace(newCitizenNames[i].Length - 1, newCitizenNames[i]);
                Citizen citizen = new Citizen(newCitizenNames[i], month);

                bool match = Citizens.Any(c => c.Equals(citizen));                             
                if (!match) Citizens.Add(citizen);                             
            }
                       
            Save();
        }

        /// <summary>
        /// Сохраняет жителей.
        /// </summary>
        /// <param name="citizens"> Список жителей. </param>
        /// <param name="month"> Месяц рождения. </param>
        public void SaveCitizens(List<Citizen> citizens, int month)
        {
            Citizens.RemoveAll(c => c.BirthdayMonth == month);
            Citizens.AddRange(citizens);
            Save();
        }

        /// <summary>
        /// Удаляет лишние пробелы.
        /// </summary>
        /// <param name="index"> Индекс пробела. </param>
        /// <param name="input"> Строка. </param>
        /// <returns> Новая строка после операции. </returns>
        private string RemoveWhiteSpace(int index, string input)
        {
            if (input[index].Equals(' '))
            {
                input = input.Remove(index, 1);
            }

            return input;
        }

        /// <summary>
        /// Переводит первую букву каждого слова в ФИО жителя в верхний регистр.
        /// </summary>
        /// <param name="citizenName"> ФИО жителя. </param>
        /// <returns> Результат операции. </returns>
        public string ToUpperFirstLetter(string citizenName)
        {
            for (int i = 0; i < citizenName.Length; i++)
            {
                if (i == 0 || citizenName[i - 1] == ' ')
                {
                    char temp = citizenName[i];
                    citizenName = citizenName.Remove(i, 1);
                    citizenName = citizenName.Insert(i, char.ToUpper(temp).ToString());
                }
            }

            return citizenName;
        }
    }
}
