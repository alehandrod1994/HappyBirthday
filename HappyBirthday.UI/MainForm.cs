using HappyBirthday.BL;
using HappyBirthday.BL.Controller;
using HappyBirthday.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HappyBirthday.UI
{
    /// <summary>
    /// Главная форма.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly CitizenController _citizenController = new CitizenController();
        private readonly ReportController _reportController = new ReportController();
        private Report _report = new Report();

        private int _currentTabNumber;
        private int _maxTabNumber;
        private List<Tab> _tabs;
          
        /// <summary>
        /// Создаёт главную форму.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();          

            WindowState = FormWindowState.Maximized;
            SetColors();
        }

        #region Обработка нажатий на изображение месяца.
        private void JanuaryImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(1);
        }

        private void FebruaryImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(2);
        }

        private void MarchImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(3);
        }

        private void AprilImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(4);
        }

        private void MayImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(5);
        }

        private void JuneImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(6);
        }

        private void JulyImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(7);
        }

        private void AugustImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(8);
        }

        private void SeptemberImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(9);
        }

        private void OctoberImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(10);
        }

        private void NovemberImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(11);
        }

        private void DecemberImage_Click(object sender, EventArgs e)
        {
            CreateNewReport(12);
        }
        #endregion

        /// <summary>
        /// Устанавливает цвета визуальных компонентов.
        /// </summary>
        private void SetColors()
        {
            WeddingCount.BackColor = Color.FromArgb(255, 236, 178);
        }

        private void OpenBirthdaysButton_Click(object sender, EventArgs e)
        {
            ShowBirthdaysForm();
        }

        /// <summary>
        /// Открывает форму со списками дней рождений.
        /// </summary>
        private void ShowBirthdaysForm()
        {
            BirthdaysForm form = new BirthdaysForm(_citizenController);
            form.ShowDialog();
        }

        /// <summary>
        /// Открывает браузерную форму со списками стихотворений.
        /// </summary>
        private void ShowBrowserForm(string url)
        {
            BrowserForm form = new BrowserForm(url);
            form.ShowDialog();
        }

        /// <summary>
        /// Создаёт новый отчёт.
        /// </summary>
        /// <param name="selectedMonth"> Выбранный месяц. </param>
        private void CreateNewReport(int selectedMonth)
        {
            _tabs = new List<Tab>()
            {
                new Tab(1, "Поздравление с Юбилеем", AnniversaryPanel),
                new Tab(2, "Поздравление с Днём рождения", BirthdayPanel),
                new Tab(3, "Поздравительное стихотворение с днём рождения", PoemPanel),
                new Tab(4, "Поздравление с Годовщиной Свадьбы", WeddingPanel),
                new Tab(5, "Дополнительная информация", AdditionallyPanel),
                new Tab(6, "Сохранение", SavePanel)
            };

            _currentTabNumber = 1;
            _maxTabNumber = _tabs.Count;

            SaveDirectory.Text = _reportController.AutoImport();
            _report = _reportController.Report;
            _report.SelectedMonth = selectedMonth;
            _report.AllAnniversaryCitizens = _citizenController.Citizens.Where(c => c.BirthdayMonth == selectedMonth).ToList();
            UpdateBox(_report.AllAnniversaryCitizens, AllAnniversaryCitizensBox);

            _report.AllBirthdayCitizens = _citizenController.Citizens.Where(c => c.BirthdayMonth == selectedMonth).ToList();
            UpdateBox(_report.AllBirthdayCitizens, AllBirthdayCitizensBox);

            _report.SelectedYear = DateTime.Today.Year;
            if (DateTime.Today.Month == 12 && selectedMonth == 1)
            {
                _report.SelectedYear++;
            }
            WeddingDatePicker.Value = Parser.ToDate($"01.{_report.SelectedMonth}.{_report.SelectedYear}");
          
            OpenTab(_currentTabNumber);           

            Title.Visible = true;
            ProgressPanel.Invalidate();
            NavigationPanel.Visible = true;
            PreviousButton.Enabled = false;
            NextButton.Enabled = true;
        }       

        /// <summary>
        /// Открывает вкладку.
        /// </summary>
        /// <param name="tabNumber"> Номер вкладки. </param>
        private void OpenTab(int tabNumber)
        {
            if (tabNumber > _maxTabNumber)
            {
                return;
            }

            Tab tab = _tabs[tabNumber - 1];
            Panel panel = tab.Panel;
            panel.BringToFront();
            panel.Show();

            Title.Text = tab.Name;
            ProgressPanel.Invalidate();

            PreviousButton.Enabled = true;
            NextButton.Enabled = true;

            if (_currentTabNumber == 1)
            {
                PreviousButton.Enabled = false;
            }

            if (_currentTabNumber == _maxTabNumber)
            {
                NextButton.Enabled = false;
            }
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            _currentTabNumber--;
            OpenTab(_currentTabNumber);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (CheckTabControls())
            {
                _currentTabNumber++;
                OpenTab(_currentTabNumber);
            }
        }

        /// <summary>
        /// Подсчитывает прогресс заполнения отчёта. 
        /// </summary>
        /// <returns> Значение прогресса. </returns>
        private int CalculateProgress()
        {
            return _currentTabNumber * 1164 / _maxTabNumber;
        }

        private void ProgressPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_currentTabNumber > 0)
            {
                int width = CalculateProgress();

                Pen yellowPen = new Pen(Color.Yellow, 5);
                e.Graphics.DrawLine(yellowPen, 0, 0, width, 0);
            }          
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (CheckTabControls())
            {
                SaveFile();
            }         
        }

        /// <summary>
        /// Сохраняет файл поздравительного отчёта.
        /// </summary>
        /// <param name="status"> Статус сохранения. </param>
        /// <returns> Асинхронная операция. </returns>
        private async Task SaveFile()
        {
            SetUiForStartSave();

            _report.SelectedAnniversaryCitizens.Reverse();
            _report.SelectedBirthdayCitizens.Reverse();
            _report.Poem = PoemBox.Text;
            _report.Additionally = AdditionallyBox.Text;

            string monthName = Parser.GetMonthName(_report.SelectedMonth);
            _report.SourceDirectory = SaveDirectory.Text;
            _report.FilePath = $"{_report.SourceDirectory}\\поздравление {monthName} {_report.SelectedYear}.doc";

            Status status = await Task.Run(() => _reportController.MakeHappyBirthdayReport());

            if (status != Status.Success)
            {
                ShutdownSave(status);
                return;
            }

            SaveSourceDirectory();
            SaveNewCitizens();
            SetUiForEndSave();
            PlaySuccessSound();
            ShowSuccessfullyForm(_report.FilePath);
        }

        /// <summary>
        /// Сохраняет путь к исходной папки для поздравительного отчёта.
        /// </summary>
        private void SaveSourceDirectory()
        {
            Report report = new Report() { SourceDirectory = _report.SourceDirectory };
            _reportController.SaveData(report);
        }

        /// <summary>
        /// Сохраняет всех новых жителей, у кого день рождения в текущем месяце.
        /// </summary>
        private void SaveNewCitizens()
        {
            List<Citizen> allCitizens = _report.SelectedAnniversaryCitizens.Union(_report.SelectedBirthdayCitizens).ToList();
            _citizenController.SaveCitizens(allCitizens, _report.SelectedMonth);
        }

        /// <summary>
        /// Меняет значения визуальных компонентов для начала сохранения.
        /// </summary>
        private void SetUiForStartSave()
        {
            SavingAnimation.Visible = true;
            ToolBar.Enabled = false;
            SaveDirectory.Enabled = false;
            ChooseDirectoryButton.Enabled = false;
            SaveButton.Enabled = false;
            NavigationPanel.Enabled = false;
        }

        /// <summary>
        /// Меняет значения визуальных компонентов для завершения сохранения.
        /// </summary>
        private void SetUiForEndSave()
        {
            SavingAnimation.Visible = false;
            ToolBar.Enabled = true;
            SaveDirectory.Enabled = true;
            ChooseDirectoryButton.Enabled = true;
            SaveButton.Enabled = true;
            NavigationPanel.Enabled = true;
        }

        /// <summary>
        /// Прекращает процесс сохранения.
        /// </summary>
        /// <param name="status"> Статус сохранения. </param>
        private void ShutdownSave(Status status)
        {
            SetUiForEndSave();

            if (status == Status.NotSave)
            {
                MessageBox.Show("Не удалось сохранить файл.");
            }
        }

        /// <summary>
        /// Открывает форму успешного сохранения.
        /// </summary>
        /// <param name="newPath"> Путь сохранённого файла. </param>
        private void ShowSuccessfullyForm(string newPath)
        {
            SuccessfullyForm form = new SuccessfullyForm(newPath);
            form.ShowDialog();
        }

        /// <summary>
        /// Производит звуковое оповещение успешного выполнения сохранения.
        /// </summary>
        private void PlaySuccessSound()
        {
            using (SoundPlayer sp = new SoundPlayer("audio\\success.wav"))
            {
                sp.Play();
            }           
        }

        /// <summary>
        /// Проверяет визуальные компоненты вкладок на валидность.
        /// </summary>
        /// <returns> True, если все компоненты прошли проверку; в противном случае - false. </returns>
        private bool CheckTabControls()
        {
            Panel panel = _tabs[_currentTabNumber - 1].Panel;

            Checker.SetControlsToWhite(panel.Controls);
            List<Control> controls = new List<Control>();

            switch (_currentTabNumber)
            {
                case 1:
                    controls.AddRange(Checker.CheckListBoxOnNull(SelectedAnniversaryCitizensBox));
                    break;

                case 2:
                    controls.AddRange(Checker.CheckListBoxOnNull(SelectedBirthdayCitizensBox));
                    break;

                default:
                    break;
            }

            if (_currentTabNumber == 3 || _currentTabNumber == 6)
            {
                controls.AddRange(Checker.CheckControlsOnNull(panel.Controls));
            }

            if (controls.Count > 0)
            {
                Checker.SetControlsToRed(controls);
                return false;
            }

            return true;
        }

        private bool CheckWedding()
        {
            Checker.SetControlsToWhite(WeddingPanel.Controls);
            List<Control> controls = Checker.CheckControlsOnNull(WeddingPanel.Controls);

            if (controls.Count > 0)
            {
                Checker.SetControlsToRed(controls);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Переносит жителя в другой список.
        /// </summary>
        /// <param name="citizensA"> Список, в котором находится житель. </param>
        /// <param name="citizensB"> Список, куда нужно перенести жителя. </param>
        /// <param name="boxA"> Визуальный компонент, в котором отображется первый список. </param>
        /// <param name="boxB"> Визуальный компонент, в котором отображется второй список. </param>
        private void MoveCitizenToOtherBox(List<Citizen> citizensA, List<Citizen> citizensB, ListBox boxA, ListBox boxB)
        {
            Citizen citizen = citizensA.FirstOrDefault(c => c.Name == boxA.SelectedItem?.ToString());
            if (citizen == null) return;

            bool match = citizensB.Any(c => c.Equals(citizen));
            if (!match)
            {
                citizensB.Insert(0, citizen);
                UpdateBox(citizensB, boxB);

                citizensA.Remove(citizen);
                UpdateBox(citizensA, boxA);
            }
            else
            {
                MessageBox.Show("Такой житель уже есть в списке.");
            }
        }

        private void MoveAnniversaryCitizenToSelectedBoxButton_Click(object sender, EventArgs e)
        {
            MoveCitizenToOtherBox(_report.AllAnniversaryCitizens,
                                  _report.SelectedAnniversaryCitizens,
                                  AllAnniversaryCitizensBox,
                                  SelectedAnniversaryCitizensBox);

            AnniversaryCitizen.Text = "";
            SelectedAnniversaryCitizen.Text = "";
            AnniversaryCitizen.Select();
        }

        private void MoveAnniversaryCitizenToAllBoxButton_Click(object sender, EventArgs e)
        {
            MoveCitizenToOtherBox(_report.SelectedAnniversaryCitizens,
                                  _report.AllAnniversaryCitizens,
                                  SelectedAnniversaryCitizensBox,
                                  AllAnniversaryCitizensBox);

            AnniversaryCitizen.Text = "";
            SelectedAnniversaryCitizen.Text = "";
            SelectedAnniversaryCitizen.Select();
        }

        /// <summary>
        /// Переносит всех жителей в другой список.
        /// </summary>
        /// <param name="citizensA"> Список, в котором находятся жители. </param>
        /// <param name="citizensB"> Список, куда нужно перенести жителей. </param>
        /// <param name="boxA"> Визуальный компонент, в котором отображется первый список. </param>
        /// <param name="boxB"> Визуальный компонент, в котором отображется второй список. </param>
        private void MoveAllCitizensToOtherBox(List<Citizen> citizensA, List<Citizen> citizensB, ListBox boxA, ListBox boxB)
        {
            citizensB.AddRange(citizensA);
            UpdateBox(citizensB, boxB);

            citizensA.Clear();
            UpdateBox(citizensA, boxA);
        }

        private void MoveAnniversaryCitizensToSelectedBoxButton_Click(object sender, EventArgs e)
        {
            MoveAllCitizensToOtherBox(_report.AllAnniversaryCitizens,
                                      _report.SelectedAnniversaryCitizens,
                                      AllAnniversaryCitizensBox,
                                      SelectedAnniversaryCitizensBox);

            AnniversaryCitizen.Text = "";
            SelectedAnniversaryCitizen.Text = "";
        }

        private void MoveAnniversaryCitizensToAllBoxButton_Click(object sender, EventArgs e)
        {
            MoveAllCitizensToOtherBox(_report.SelectedAnniversaryCitizens,
                                      _report.AllAnniversaryCitizens,
                                      SelectedAnniversaryCitizensBox,
                                      AllAnniversaryCitizensBox);

            AnniversaryCitizen.Text = "";
            SelectedAnniversaryCitizen.Text = "";
        }

        /// <summary>
        /// Обновляет визуальный компонент.
        /// </summary>
        /// <param name="citizens"> Список жителей. </param>
        /// <param name="box"> Визуальный компонент. </param>
        private void UpdateBox(List<Citizen> citizens, ListBox box)
        {
            box.Items.Clear();
            box.Items.AddRange(citizens.ToArray());
        }

        /// <summary>
        /// Осуществляет поиск жителей по ключевой фразе и отображает результат в визуальном компоненте.
        /// </summary>
        /// <param name="key"> Ключевая фраза. </param>
        /// <param name="citizens"> Список жителей. </param>
        /// <param name="box"> Визуальный компонент. </param>
        private void SearchCitizens(string key, List<Citizen> citizens, ListBox box)
        {
            List<Citizen> result = citizens.Where(c => c.Name.ToLower().Contains(key.ToLower())).ToList();

            if (result != null)
            {
                UpdateBox(result, box);
            }
            else
            {
                box.Items.Clear();
            }
        }

        private void AnniversaryCitizen_TextChanged(object sender, EventArgs e)
        {
            SearchCitizens(AnniversaryCitizen.Text, _report.AllAnniversaryCitizens, AllAnniversaryCitizensBox);
        }

        private void SelectedAnniversaryCitizen_TextChanged(object sender, EventArgs e)
        {
            SearchCitizens(SelectedAnniversaryCitizen.Text, _report.SelectedAnniversaryCitizens, SelectedAnniversaryCitizensBox);
        }

        private void AddAllAnniversaryCitizenButton_Click(object sender, EventArgs e)
        {
            AddNewCitizen(AnniversaryCitizen.Text, _report.SelectedAnniversaryCitizens, SelectedAnniversaryCitizensBox);
            AnniversaryCitizen.Text = "";
            AnniversaryCitizen.Select();
        }

        private void AddSelectedAnniversaryCitizenButton_Click(object sender, EventArgs e)
        {
            AddNewCitizen(SelectedAnniversaryCitizen.Text, _report.SelectedAnniversaryCitizens, SelectedAnniversaryCitizensBox);
            SelectedAnniversaryCitizen.Text = "";
            SelectedAnniversaryCitizen.Select();
        }

        /// <summary>
        /// Добавляет нового жителя.
        /// </summary>
        /// <param name="citizenName"> ФИО нового жителя. </param>
        /// <param name="citizens"> Список, куда нужно добавить нового жителя. </param>
        /// <param name="box"> Визуальный компонент, который отображает список. </param>
        private void AddNewCitizen(string citizenName, List<Citizen> citizens, ListBox box)
        {
            if (citizenName != "")
            {
                citizenName = _citizenController.ToUpperFirstLetter(citizenName);
                Citizen citizen = new Citizen(citizenName, _report.SelectedMonth);

                bool match = citizens.Any(c => c.Equals(citizen));
                if (!match)
                {
                    citizens.Insert(0, citizen);
                    UpdateBox(citizens, box);
                }
                else
                {
                    MessageBox.Show("Такой житель уже есть в спике.");
                }              
            }
        }       

        private void MoveBirthdayCitizenToSelectedBoxButton_Click(object sender, EventArgs e)
        {
            MoveCitizenToOtherBox(_report.AllBirthdayCitizens,
                                  _report.SelectedBirthdayCitizens,
                                  AllBirthdayCitizensBox,
                                  SelectedBirthdayCitizensBox);

            BirthdayCitizen.Text = "";
            SelectedBirthdayCitizen.Text = "";
            BirthdayCitizen.Select();
        }

        private void MoveBirthdayCitizenToAllBoxButton_Click(object sender, EventArgs e)
        {
            MoveCitizenToOtherBox(_report.SelectedBirthdayCitizens,
                                  _report.AllBirthdayCitizens,
                                  SelectedBirthdayCitizensBox,
                                  AllBirthdayCitizensBox);

            BirthdayCitizen.Text = "";
            SelectedBirthdayCitizen.Text = "";
            SelectedBirthdayCitizen.Select();
        }

        private void MoveBirthdayCitizensToSelectedBoxButton_Click(object sender, EventArgs e)
        {
            MoveAllCitizensToOtherBox(_report.AllBirthdayCitizens,
                                      _report.SelectedBirthdayCitizens,
                                      AllBirthdayCitizensBox,
                                      SelectedBirthdayCitizensBox);

            BirthdayCitizen.Text = "";
            SelectedBirthdayCitizen.Text = "";
        }

        private void MoveBirthdayCitizensToAllBoxButton_Click(object sender, EventArgs e)
        {
            MoveAllCitizensToOtherBox(_report.SelectedBirthdayCitizens,
                                      _report.AllBirthdayCitizens,
                                      SelectedBirthdayCitizensBox,
                                      AllBirthdayCitizensBox);

            BirthdayCitizen.Text = "";
            SelectedBirthdayCitizen.Text = "";
        }

        private void BirthdayCitizen_TextChanged(object sender, EventArgs e)
        {
            SearchCitizens(BirthdayCitizen.Text, _report.AllBirthdayCitizens, AllBirthdayCitizensBox);
        }

        private void SelectedBirthdayCitizen_TextChanged(object sender, EventArgs e)
        {
            SearchCitizens(SelectedBirthdayCitizen.Text, _report.SelectedBirthdayCitizens, SelectedBirthdayCitizensBox);
        }

        private void AddAllBirthdayCitizenButton_Click(object sender, EventArgs e)
        {
            AddNewCitizen(BirthdayCitizen.Text, _report.SelectedBirthdayCitizens, SelectedBirthdayCitizensBox);
            BirthdayCitizen.Text = "";
            BirthdayCitizen.Select();
        }

        private void AddSelectedBirthdayCitizenButton_Click(object sender, EventArgs e)
        {
            AddNewCitizen(SelectedBirthdayCitizen.Text, _report.SelectedBirthdayCitizens, SelectedBirthdayCitizensBox);
            SelectedBirthdayCitizen.Text = "";
            SelectedBirthdayCitizen.Select();
        }

        private void SaveWeddingButton_Click(object sender, EventArgs e)
        {
            if (CheckWedding())
            {
                Wedding wedding = AddWedding();
                ClearWeddingData();               
                MessageBox.Show($"Поздравление {wedding.Marrieds} с {Parser.GetWeddingByName(wedding.WeddingType)} свадьбой добавлено.");
            }           
        }

        /// <summary>
        /// Добавляет текущую годовщину свадьбы в список.
        /// </summary>
        /// <returns> Годовщина свадьбы. </returns>
        private Wedding AddWedding()
        {
            int age = Parser.ToInt(WeddingTypesBox.SelectedItem?.ToString().Substring(0, 2));
            WeddingType weddingType = Parser.GetWeddingType(age);
            string marrieds = Marrieds.Text;
            string poem = WeddingPoemBox.Text;
            DateTime date = WeddingDatePicker.Value;

            Wedding wedding = new Wedding(age, weddingType, marrieds, poem, date);
            _report.Weddings.Add(wedding);
            WeddingCount.Text = _report.Weddings.Count.ToString();

            return wedding;
        }

        /// <summary>
        /// Очистить визуальные компоненты годовщины свадьбы.
        /// </summary>
        private void ClearWeddingData()
        {
            WeddingTypesBox.SelectedItem = null;
            Marrieds.Text = "";
            WeddingPoemBox.Text = "";
            WeddingDatePicker.Value = Parser.ToDate($"01.{_report.SelectedMonth}.{_report.SelectedYear}");
        }

        private void ChooseDirectoryButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SaveDirectory.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            MainPanel.Location = LayoutCalculator.GetCenterLocation(MainPanel.Size, Size, TopPanel.Height, BottomPanel.Height);
            NavigationPanel.Location = LayoutCalculator.GetHorizontalCenterNavigation(NavigationPanel.Width, Width);
            Head.Left = MainPanel.Left;
        }

        private void OpenPoemInBrowserButton_Click(object sender, EventArgs e)
        {
            string url = Parser.GetBirthdayPoemUrl(_report.SelectedMonth);
            ShowBrowserForm(url);
        }

        private void OpenWeddingPoemInBrowserButton_Click(object sender, EventArgs e)
        {
            if (WeddingTypesBox.SelectedItem != null)
            {
                int age = Parser.ToInt(WeddingTypesBox.SelectedItem?.ToString().Substring(0, 2));
                WeddingType weddingType = Parser.GetWeddingType(age);

                string url = Parser.GetWeddingPoemUrl(weddingType);
                ShowBrowserForm(url);
            }
            else
            {
                MessageBox.Show("Не выбрана годовщина свадьбы.");
            }
            
        }
    }
}
