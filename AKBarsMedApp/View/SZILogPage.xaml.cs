using AKBarsMedApp.Database;
using Infragistics.Documents.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AKBarsMedApp.View
{
    /// <summary>
    /// Логика взаимодействия для SZILogPage.xaml
    /// </summary>
    public partial class SZILogPage : Page
    {
        List<JornalSZI> szilst = App.akbmeddbEntities.JornalSZI.ToList();
        public SZILogPage()
        {
            InitializeComponent();
            SZILogDG.ItemsSource = szilst;
        }

        private void CreateLogBtn_Click(object sender, RoutedEventArgs e)
        {
            if (szilst.Count > 0)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Word Documents (.docx)|*.docx";
                if (saveFileDialog1.ShowDialog() == true)
                {
                    //tableproperties
                    WordDocumentWriter docWriter = WordDocumentWriter.Create(saveFileDialog1.FileName);
                    docWriter.StartDocument();

                    ParagraphProperties paragraphProps = docWriter.CreateParagraphProperties();
                    paragraphProps.Alignment = ParagraphAlignment.Right;
                    paragraphProps.SpacingAfter = 10;

                    //fonts
                    Font fontheader = docWriter.CreateFont();
                    fontheader.Bold = true;
                    fontheader.Size = 9;

                    Font fontcell = docWriter.CreateFont();
                    fontcell.Size = 8;

                    Font fonttime = docWriter.CreateFont();
                    fonttime.Size = 7;

                    TableBorderProperties borderProps = docWriter.CreateTableBorderProperties();
                    borderProps.Color = Colors.Black;
                    borderProps.Style = TableBorderStyle.Single;

                    TableProperties tableProps = docWriter.CreateTableProperties();
                    tableProps.Alignment = ParagraphAlignment.Center;
                    tableProps.BorderProperties.Color = borderProps.Color;
                    tableProps.BorderProperties.Style = borderProps.Style;

                    TableRowProperties rowProps = docWriter.CreateTableRowProperties();
                    rowProps.IsHeaderRow = true;

                    TableCellProperties cellProps = docWriter.CreateTableCellProperties();
                    cellProps.BackColor = Colors.White;
                    cellProps.TextDirection = TableCellTextDirection.LeftToRightTopToBottom;

                    docWriter.StartParagraph(paragraphProps);
                    docWriter.AddTextRun($"Журнал сформирован {DateTime.Now}", fonttime);
                    docWriter.EndParagraph();

                    docWriter.StartTable(8, tableProps);

                    //headerrows
                    docWriter.StartTableRow(rowProps);
                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Наименование СЗИ", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Тип СЗИ", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Номер знака соответствия", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Сертификат", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Номера аппаратных средств, к которым подключены СЗИ", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Дата подключения", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Дата изъятия", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun("Пользователь, ответственный за эксплуатацию СЗИ", fontheader);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.EndTableRow();

                    //export

                    foreach (JornalSZI sziitem in szilst)
                    {
                        docWriter.StartTableRow();
                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{sziitem.Name}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{sziitem.TypeSZI.Name}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{sziitem.Number}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{sziitem.Serificate}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{sziitem.HardwareNum}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{String.Format("{0:dd.MM.yyyy}", sziitem.DateConnect)}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{String.Format("{0:dd.MM.yyyy}", sziitem.DateEnd)}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.StartTableCell(cellProps);
                        docWriter.StartParagraph();
                        docWriter.AddTextRun($"{sziitem.Employee.FullName}", fontcell);
                        docWriter.EndParagraph();
                        docWriter.EndTableCell();

                        docWriter.EndTableRow();
                    }
                    docWriter.EndTable();

                    docWriter.EndDocument();
                    docWriter.Close();

                    Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document wordDocument = appWord.Documents.Open(saveFileDialog1.FileName);
                    wordDocument.PageSetup.Orientation = Microsoft.Office.Interop.Word.WdOrientation.wdOrientLandscape;
                    wordDocument.PageSetup.LeftMargin = 30;
                    wordDocument.PageSetup.RightMargin = 30;
                    wordDocument.PageSetup.TopMargin = 30;
                    wordDocument.Save();
                    wordDocument.Close();
                }
            }
            else
            {
                MessageBox.Show("Журнал пуст");
            }
        }

        private void DateSecondDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UsableSZICB.IsChecked = false;
            DateFirstDP.DisplayDateEnd = DateSecondDP.SelectedDate;
            if (DateFirstDP.SelectedDate > DateSecondDP.SelectedDate)
            {
                DateFirstDP.SelectedDate = null;
            }
            if (DateFirstDP.SelectedDate != null)
            {
                szilst = App.akbmeddbEntities.JornalSZI.Where(x => x.DateConnect >= DateFirstDP.SelectedDate && x.DateConnect <= DateSecondDP.SelectedDate).ToList();
            }
            else
            {
                szilst = App.akbmeddbEntities.JornalSZI.Where(x => x.DateConnect <= DateSecondDP.SelectedDate).ToList();
            }
            SZILogDG.ItemsSource = szilst;
        }

        private void DateFirstDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UsableSZICB.IsChecked = false;
            DateSecondDP.DisplayDateStart = DateFirstDP.SelectedDate;
            if (DateFirstDP.SelectedDate > DateSecondDP.SelectedDate)
            {
                DateSecondDP.SelectedDate = null;
            }
            if (DateSecondDP.SelectedDate != null)
            {
                szilst = App.akbmeddbEntities.JornalSZI.Where(x => x.DateConnect >= DateFirstDP.SelectedDate && x.DateConnect <= DateSecondDP.SelectedDate).ToList();
            }
            else
            {
                szilst = App.akbmeddbEntities.JornalSZI.Where(x => x.DateConnect >= DateFirstDP.SelectedDate).ToList();
            }
            SZILogDG.ItemsSource = szilst;
        }

        private void ClearDateBtn_Click(object sender, RoutedEventArgs e)
        {
            DateSecondDP.SelectedDate = null;
            DateFirstDP.SelectedDate = null;
            UsableSZICB.IsChecked = false;
            szilst = App.akbmeddbEntities.JornalSZI.ToList();
            SZILogDG.ItemsSource = szilst;
        }

        private void UsableSZICB_Click(object sender, RoutedEventArgs e)
        {
            DateSecondDP.SelectedDate = null;
            DateFirstDP.SelectedDate = null;
            UsableSZICB.IsChecked = true;
            szilst = App.akbmeddbEntities.JornalSZI.Where(x => x.DateEnd >= DateTime.Now).ToList();
            SZILogDG.ItemsSource = szilst;
        }
    }
}
