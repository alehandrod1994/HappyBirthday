using HappyBirthday.BL.Controller;
using System;
using System.Windows.Forms;

namespace HappyBirthday.UI
{
    public partial class BirthdaysForm : Form
    {
        private readonly CitizenController _citizenController;
      
        public BirthdaysForm(CitizenController citizenController)
        {
            InitializeComponent();

            _citizenController = citizenController;
            MonthsCombobox.SelectedIndex = 0;
        }

        private void MonthsCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CitizensRichTextBox.Text = _citizenController.ToString(MonthsCombobox.SelectedIndex + 1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            _citizenController.SaveCitizens(CitizensRichTextBox.Text, MonthsCombobox.SelectedIndex + 1);
            CitizensRichTextBox.Text = _citizenController.ToString(MonthsCombobox.SelectedIndex + 1);
            MessageBox.Show("Сохранено");
        }
    }
}
