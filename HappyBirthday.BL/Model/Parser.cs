using HappyBirthday.BL.Model;
using System;
using System.Collections.Generic;

namespace HappyBirthday.BL
{
    /// <summary>
    /// Парсер.
    /// </summary>
    public abstract class Parser
    {
        private static readonly Dictionary<int, WeddingType> _weddingTypes = new Dictionary<int, WeddingType>()
        {
            { 20, WeddingType.Porcelain},
            { 25, WeddingType.Silver},
            { 30, WeddingType.Pearl},
            { 35, WeddingType.Coral},
            { 40, WeddingType.Ruby},
            { 45, WeddingType.Sapphire},
            { 50, WeddingType.Gold},
            { 55, WeddingType.Emerald},
            { 60, WeddingType.Brilliant},
            { 65, WeddingType.Iron},
        };

        private static readonly Dictionary<int, Month> _months = new Dictionary<int, Month>()
        {
            { 1, Month.January},
            { 2, Month.February},
            { 3, Month.March},
            { 4, Month.April},
            { 5, Month.May},
            { 6, Month.June},
            { 7, Month.July},
            { 8, Month.August},
            { 9, Month.September},
            { 10, Month.October},
            { 11, Month.November},
            { 12, Month.December}
        };

        /// <summary>
        /// Переводит строку в дату.
        /// </summary>
        /// <param name="value"> Строка. </param>
        /// <returns> Результат операции. </returns>
        public static DateTime ToDate(string value)
        {
            DateTime result;
            if (DateTime.TryParse(value, out result))
            {
                return result;
            }

            return DateTime.Today;
        }

        /// <summary>
        /// Переводит строку в целое число.
        /// </summary>
        /// <param name="value"> Строка. </param>
        /// <returns> Результат операции. </returns>
        public static int ToInt(string value)
        {
            int result;
            if (int.TryParse(value, out result))
            {
                return result;
            }

            return 0;
        }

        /// <summary>
        /// Возвращает тип свадьбы.
        /// </summary>
        /// <param name="age"> Номер годовщины свадьбы. </param>
        /// <returns> Результат операции. </returns>
        public static WeddingType GetWeddingType(int age)
        {
            WeddingType result;
            if (_weddingTypes.TryGetValue(age, out result))
            {
                return result;
            }

            return default(WeddingType);
        }

        /// <summary>
        /// Возвращает название годовщины свадьбы.
        /// </summary>
        /// <param name="weddingType"> Тип свадьбы. </param>
        /// <returns> Результат операции. </returns>
        public static string GetWeddingName(WeddingType weddingType)
        {
            string weddingName = "";

            switch (weddingType)
            {
                case WeddingType.Porcelain:
                    weddingName = "фарфоровая";
                    break;

                case WeddingType.Silver:
                    weddingName = "серебряная";
                    break;

                case WeddingType.Pearl:
                    weddingName = "жемчужная";
                    break;

                case WeddingType.Coral:
                    weddingName = "коралловая";
                    break;

                case WeddingType.Ruby:
                    weddingName = "рубиновая";
                    break;

                case WeddingType.Sapphire:
                    weddingName = "сапфировая";
                    break;

                case WeddingType.Gold:
                    weddingName = "золотая";
                    break;

                case WeddingType.Emerald:
                    weddingName = "изумрудная";
                    break;

                case WeddingType.Brilliant:
                    weddingName = "бриллиантовая";
                    break;

                case WeddingType.Iron:
                    weddingName = "железная";
                    break;

                default:
                    break;
            }

            return weddingName;
        }

        /// <summary>
        /// Возвращает название годовщины свадьбы в творительном падеже.
        /// </summary>
        /// <param name="weddingType"> Тип свадьбы. </param>
        /// <returns> Результат операции. </returns>
        public static string GetWeddingByName(WeddingType weddingType)
        {
            string weddingName = GetWeddingName(weddingType);
            return weddingName.Remove(weddingName.Length - 2) + "ой";           
        }

        /// <summary>
        /// Возвращает URL-адрес поздравительных стихотворений с годовщиной свадьбы.
        /// </summary>
        /// <param name="weddingType"> Тип свадьбы. </param>
        /// <returns> URL-адрес. </returns>
        public static string GetWeddingPoemUrl(WeddingType weddingType)
        {
            string weddingUrlName = "";

            switch (weddingType)
            {
                case WeddingType.Porcelain:
                    weddingUrlName = "farforovaya-20";
                    break;

                case WeddingType.Silver:
                    weddingUrlName = "serebryanaya-25";
                    break;

                case WeddingType.Pearl:
                    weddingUrlName = "zhemchuzhnaya-30";
                    break;

                case WeddingType.Coral:
                    weddingUrlName = "polotnyanaya-35";
                    break;

                case WeddingType.Ruby:
                    weddingUrlName = "rubinovaya-40";
                    break;

                case WeddingType.Sapphire:
                    weddingUrlName = "sapfirovaya-45";
                    break;

                case WeddingType.Gold:
                    weddingUrlName = "zolotaya-50";
                    break;

                case WeddingType.Emerald:
                    weddingUrlName = "izumrudnaya-55";
                    break;

                case WeddingType.Brilliant:
                    weddingUrlName = "brilliantovaya-60";
                    break;

                case WeddingType.Iron:
                    weddingUrlName = "zheleznaya-65";
                    break;

                default:
                    break;
            }

            return "https://pozdravok.com/pozdravleniya/yubiley-svadby/" + weddingUrlName;
        }

        /// <summary>
        /// Возвращает месяц.
        /// </summary>
        /// <param name="monthNumber"> Номер месяца. </param>
        /// <returns> Результат операции. </returns>
        private static Month GetMonth(int monthNumber)
        {
            Month result;
            if (_months.TryGetValue(monthNumber, out result))
            {
                return result;
            }

            return default(Month);
        }

        /// <summary>
        /// Возвращает название месяца.
        /// </summary>
        /// <param name="monthNumber"> Номер месяца. </param>
        /// <returns> Результат операции. </returns>
        public static string GetMonthName(int monthNumber)
        {
            Month month = GetMonth(monthNumber);
            string monthName = "";

            switch (month)
            {
                case Month.January:
                    monthName = "январь";
                    break;

                case Month.February:
                    monthName = "февраль";
                    break;

                case Month.March:
                    monthName = "март";
                    break;

                case Month.April:
                    monthName = "апрель";
                    break;

                case Month.May:
                    monthName = "май";
                    break;

                case Month.June:
                    monthName = "июнь";
                    break;

                case Month.July:
                    monthName = "июль";
                    break;

                case Month.August:
                    monthName = "август";
                    break;

                case Month.September:
                    monthName = "сентябрь";
                    break;

                case Month.October:
                    monthName = "октябрь";
                    break;

                case Month.November:
                    monthName = "ноябрь";
                    break;

                case Month.December:
                    monthName = "декабрь";
                    break;

                default:
                    break;
            }

            return monthName;
        }

        /// <summary>
        /// Возвращает название месяца в родительном падеже.
        /// </summary>
        /// <param name="monthNumber"> Номер месяца. </param>
        /// <returns> Результат операции. </returns>
        public static string GetMonthOfName(int monthNumber)
        {
            string monthName = GetMonthName(monthNumber);

            if (monthName != "март" && monthName != "август")
            {
                return monthName.Remove(monthName.Length - 1) + "я";
            }
          
            return monthName + "а";                    
        }

        /// <summary>
        /// Возвращает название месяца в предложном падеже.
        /// </summary>
        /// <param name="monthNumber"> Номер месяца. </param>
        /// <returns> Результат операции. </returns>
        public static string GetMonthInName(int monthNumber)
        {
            string monthName = GetMonthName(monthNumber);

            if (monthName != "март" && monthName != "август")
            {
                return monthName.Remove(monthName.Length - 1) + "е";
            }

            return monthName + "е";
        }

        /// <summary>
        /// Возвращает URL-адрес поздравительных стихотворений с днём рождения.
        /// </summary>
        /// <param name="monthNumber"> Номер месяца. </param>
        /// <returns> URL-адрес. </returns>
        public static string GetBirthdayPoemUrl(int monthNumber)
        {
            Month month = GetMonth(monthNumber);
            string monthUrlName = "";

            switch (month)
            {
                case Month.January:
                    monthUrlName = "yanvar";
                    break;

                case Month.February:
                    monthUrlName = "fevral";
                    break;

                case Month.March:
                    monthUrlName = "mart";
                    break;

                case Month.April:
                    monthUrlName = "aprel";
                    break;

                case Month.May:
                    monthUrlName = "may";
                    break;

                case Month.June:
                    monthUrlName = "iyun";
                    break;

                case Month.July:
                    monthUrlName = "iyul";
                    break;

                case Month.August:
                    monthUrlName = "avgust";
                    break;

                case Month.September:
                    monthUrlName = "sentyabr";
                    break;

                case Month.October:
                    monthUrlName = "oktyabr";
                    break;

                case Month.November:
                    monthUrlName = "noyabr";
                    break;

                case Month.December:
                    monthUrlName = "dekabr";
                    break;

                default:
                    break;
            }

            return "https://pozdravok.com/pozdravleniya/den-rozhdeniya/i/" + monthUrlName;
        }
    }
}
