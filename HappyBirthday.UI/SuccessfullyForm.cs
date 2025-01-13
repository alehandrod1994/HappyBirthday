using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HappyBirthday.UI
{
    /// <summary>
    /// Форма "Сохранение файла".
    /// </summary>
    public partial class SuccessfullyForm : Form
    {
        /// <summary>
        /// Создаёт форму.
        /// </summary>
        /// <param name="newPath"> Путь к сохранённому файлу. </param>
        public SuccessfullyForm(string newPath)
        {
            InitializeComponent();

            labelPath2.Text = newPath;
        }
       
        /// <summary>
        /// Открывает файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            string path = labelPath2.Text;

            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBox.Show("Файл не найден");
        }
       
        /// <summary>
        /// Открывает папку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            Process PrFolder = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = labelPath2.Text;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = @"/n, /select, " + file;
            PrFolder.StartInfo = psi;
            PrFolder.Start();
        }
       
        /// <summary>
        /// Закрывает приложение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
