using System;
using System.Windows.Forms;

namespace HappyBirthday.UI
{
    public partial class BrowserForm : Form
    {
        public BrowserForm(string url)
        {
            InitializeComponent();

            PoemBrowser.Url = new Uri(url);
        }
    }
}
