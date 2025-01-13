using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HappyBirthday.BL.Model
{
    /// <summary>
    /// Класс валидации элементов.
    /// </summary>
    public abstract class Checker
    {
        /// <summary>
        /// Проверяет контроллы на пустое значение.
        /// </summary>
        /// <param name="controls"> Коллекция контроллов. </param>
        /// <returns> Коллекция контроллов, не прошедших проверку. </returns>
        public static List<Control> CheckControlsOnNull(Control.ControlCollection controls)
        {
            List<Control> failedControls = new List<Control>();

            foreach (Control control in controls)
            {
                if (control is Panel)
                {
                    failedControls.AddRange(CheckControlsOnNull(control.Controls));
                }             

                if (control is TextBox || control is ComboBox || control is RichTextBox)
                {
                    if (string.IsNullOrWhiteSpace(control.Text))
                    {
                        failedControls.Add(control);
                    }
                }
            }

            return failedControls;
        }

        /// <summary>
        /// Проверяет ListBox на пустое значение.
        /// </summary>
        /// <param name="box"> ListBox. </param>
        /// <returns> Список контроллов, не прошедших проверку. </returns>
        public static List<Control> CheckListBoxOnNull(ListBox box)
        {
            List<Control> failedControls = new List<Control>();

            if (box.Items.Count < 1)
            {
                failedControls.Add(box);
            }
                          
            return failedControls;
        }

        /// <summary>
        /// Закрашивает коллекцию контроллов в белый цвет.
        /// </summary>
        /// <param name="controls"> Коллекция контроллов. </param>
        public static void SetControlsToWhite(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Panel)
                {
                    SetControlsToWhite(control.Controls);
                }

                if (control is TextBox || control is ComboBox || control is RichTextBox || control is ListBox)
                {
                    control.BackColor = Color.White;
                }                                 
            }
        }

        /// <summary>
        /// Закрашивает коллекцию контроллов в красный цвет.
        /// </summary>
        /// <param name="controls"> Коллекция контроллов. </param>
        public static void SetControlsToRed(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                 control.BackColor = Color.LightCoral;                             
            }
        }
    }
}
