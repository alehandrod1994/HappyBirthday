using System;
using System.Windows.Forms;

namespace HappyBirthday.UI
{
    /// <summary>
    /// Вкладка.
    /// </summary>
    public class Tab
    {
        /// <summary>
        /// Создаёт новую вкладку.
        /// </summary>
        /// <param name="number"> Номер. </param>
        /// <param name="name"> Название. </param>
        /// <param name="panel"> Панель. </param>
        public Tab(int number, string name, Panel panel)
        {
            #region Проверка входных параметров
            if (number < 0)
            {
                throw new ArgumentNullException(nameof(name), "Номер вкладки не может быть меньше нуля.");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Название вкладки не может быть пустым.");
            }

            if (panel == null)
            {
                throw new ArgumentNullException(nameof(name), "Панель не может быть пустой.");
            }
            #endregion

            Number = number;
            Name = name;
            Panel = panel;
        }

        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Панель.
        /// </summary>
        public Panel Panel { get; }

        public override string ToString() => $"{Number}: {Name}";
    }
}
