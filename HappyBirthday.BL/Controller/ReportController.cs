using HappyBirthday.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Word = Microsoft.Office.Interop.Word;

namespace HappyBirthday.BL.Controller
{
    /// <summary>
    /// Контроллер поздравительного отчёта.
    /// </summary>
    public class ReportController : ControllerBase
    {
        private CitizenController _citizenController = new CitizenController();
        private Status _status = Status.Start;

        private Word.Application _app;
        private Word.Document _doc;

        private string _paragraphMargin = "   ";
        private string _signature = "Совет ветеранов п. Памяти 13 Борцов.";

        /// <summary>
        /// Создаёт новый контроллер поздравительного отчёта.
        /// </summary>
        public ReportController()
        {
            Report = GetReport();
        }
     
        /// <summary>
        /// Поздравительный отчёт.
        /// </summary>
		public Report Report { get; private set; }

        /// <summary>
        /// Возвращает поздравительный отчёт.
        /// </summary>
        /// <returns> Поздравительный отчёт. </returns>
        private Report GetReport()
        {
            List<Report> reports = Load<Report>();
            return reports.Count > 0 ? reports.First() : new Report();
        }

        /// <summary>
        /// Автоимпортирует папку с поздравлениями.
        /// </summary>
        /// <returns> Название файла. </returns>
        public string AutoImport()
        {
            return Directory.Exists(Report.SourceDirectory) ? Report.SourceDirectory : "";
        }

        /// <summary>
        /// Создаёт соединение с новым файлом.
        /// </summary>
        private void CreateConnection()
        {
            _app = new Word.Application();
            _doc = _app.Documents.Add(Visible: true);
        }

        /// <summary>
        /// Закрывает соединение с новым файлом.
        /// </summary>
        /// <returns> True, если подключение прошло успешно; в противном случае - false. </returns>
        private bool CloseConnection()
        {
            try
            {
                object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                _doc.Close(ref saveOption, ref originalFormat, ref routeDocument);
                _app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                _app.Quit();
                _doc = null;
                _app = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Вставляет выбранных юбиляров.
        /// </summary>
        private void PasteAnniversaryCitizens()
        {
            string anniversaryCitizens = _citizenController.ToString(Report.SelectedAnniversaryCitizens);

            _doc.Sections.PageSetup.LeftMargin = 30;
            _doc.Sections.PageSetup.RightMargin = 30;

            Word.Range data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Font.Size = 14;
            data.Font.Name = "Tahoma";
            data.Text = "Поздравляем с Юбилеем";
            data.Text += $"{_paragraphMargin}{anniversaryCitizens}.\n\n";
        }

        /// <summary>
        /// Вставляет выбранных именинников.
        /// </summary>
        private void PasteBirthdayCitizens()
        {
            string birthdayCitizens = _citizenController.ToString(Report.SelectedBirthdayCitizens);
            string month = Parser.GetMonthInName(Report.SelectedMonth);

            Word.Range data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Font.Size = 14;
            data.Font.Name = "Tahoma";
            data.Text = "Поздравляем с Днём рождения";
            data.Text += $"{_paragraphMargin}{birthdayCitizens} и поздравляем всех, кто родился в {month}.\n\n";
        }

        /// <summary>
        /// Вставляет стихотворение.
        /// </summary>
        /// <param name="poem"> Стихотворение. </param>
        private void PastePoem(string poem)
        {
            Word.Range data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Font.Size = 10.5f;
            data.Font.Name = "Verdana";
            data.Text = poem + "\n\n";
        }

        /// <summary>
        /// Вставляет поздравительное стихотворение с днём рождения.
        /// </summary>
        /// <param name="poem"> Поздравительное стихотворение с днём рождения. </param>
        private void PasteBirthdayPoem(string poem)
        {
            PastePoem(poem);

            Word.Range data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Font.Size = 12;
            data.Text = _signature + "\n\n\n\n";
        }

        /// <summary>
        /// Вставляет поздравительное стихотворение с годовщиной свадьбы. 
        /// </summary>
        /// <param name="poem"> Стихотворение. </param>
        /// <param name="date"> Дата годовщины свадьбы. </param>
        private void PasteWeddingPoem(string poem, DateTime date)
        {
            PastePoem(poem);

            Word.Range data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Font.Size = 12;
            data.Text = $"{date.Day} {Parser.GetMonthOfName(date.Month)}";
            data.Text += _signature + "\n\n";
        }

        /// <summary>
        /// Вставляет годовщины свадеб.
        /// </summary>
        private void PasteWeddings()
        {
            if (Report.Weddings.Count == 0) return;

            Word.Range data;

            foreach (Wedding wedding in Report.Weddings)
            {
                data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
                data.Font.Size = 14;
                data.Font.Name = "Tahoma";

                string weddingByName = Parser.GetWeddingByName(wedding.WeddingType);

                if (wedding.WeddingType == WeddingType.Coral && wedding.Poem.ToLower().Contains("полотн"))
                {
                    weddingByName = "полотняной";
                }

                data.Text = $"Поздравляем с {weddingByName} свадьбой - {wedding.Age} лет";
                data.Text += wedding.Marrieds + "\n\n";

                PasteWeddingPoem(wedding.Poem, wedding.Date);
            }

            data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Text = "\n\n";
        }

        /// <summary>
        /// Вставляет дополнительную информацию.
        /// </summary>
        private void PasteAdditionally()
        {
            if (string.IsNullOrWhiteSpace(Report.Additionally)) return;

            Word.Range data = _doc.Range(_doc.Paragraphs.Last.Range.Start, _doc.Paragraphs.Last.Range.End);
            data.Font.Size = 14;
            data.Font.Name = "Tahoma";
            data.Text = Report.Additionally;
        }

        /// <summary>
        /// Устанавливает жирный шрифт.
        /// </summary>
        /// <param name="findText"> Текст, для которого нужно установить жирный шрифт. </param>
        private void SetBold(string findText)
        {
            Word.Range data = _doc.Content;
            data.Find.ClearFormatting();
            data.Find.Execute(FindText: findText);
            data.Bold = 1;
        }

        /// <summary>
        /// Убирает отступы после абзаца.
        /// </summary>
        private void RemoveParagraphSpaceAfter()
        {
            Word.Range data = _doc.Content;
            data.ParagraphFormat.SpaceAfter = 0;
        }

        /// <summary>
        /// Устанавливает размеры полей.
        /// </summary>
        private void SetMargins()
        {
            _doc.PageSetup.TopMargin = 56.7f;
            _doc.PageSetup.BottomMargin = 56.7f;
            _doc.PageSetup.LeftMargin = 85.05f;
            _doc.PageSetup.RightMargin = 42.5f;
        }

        /// <summary>
        /// Форматирует поздравительный отчёт.
        /// </summary>
        private void FormatReport()
        {
            SetBold("Юбилеем");
            SetBold("Днём рождения");
            RemoveParagraphSpaceAfter();
            SetMargins();
        }

        /// <summary>
        /// Создаёт поздравительный отчёт.
        /// </summary>
        /// <returns> Статус выполнения операции. </returns>
        public Status MakeHappyBirthdayReport()
        {
            CreateConnection();

            PasteAnniversaryCitizens();
            PasteBirthdayCitizens();
            PasteBirthdayPoem(Report.Poem);
            PasteWeddings();
            PasteAdditionally();
            FormatReport();          

            if (!SaveFile())
            {
                return _status;
            }

            CloseConnection();
            _status = Status.Success;
            return _status;
        }

        /// <summary>
        /// Сохраняет созданный документ.
        /// </summary>
        /// <returns> True, если сохранение прошло успешно; в противном случае - false. </returns>
        private bool SaveFile()
        {
            try
            {
                _doc.SaveAs(Report.FilePath);
            }
            catch
            {
                CloseConnection();
                _status = Status.NotSave;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Сохраняет данные.
        /// </summary>
        /// <param name="report"> Поздравительный отчёт. </param>
        public void SaveData(Report report)
        {
            Save(new List<Report>() { report });
        }
    }
}
