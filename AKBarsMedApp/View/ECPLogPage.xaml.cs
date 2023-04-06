using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Infragistics.Documents.Word;
using AKBarsMedApp.Database;

namespace AKBarsMedApp.View
{
    /// <summary>
    /// Логика взаимодействия для ECPLogPage.xaml
    /// </summary>
    public partial class ECPLogPage : System.Windows.Controls.Page
    {
        public ECPLogPage()
        {
            InitializeComponent();
            ECPLogDG.ItemsSource = App.akbmeddbEntities.JournalECP.ToList();
        }

        private void CreateLogBtn_Click(object sender, RoutedEventArgs e)
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
                docWriter.AddTextRun("Серийные номера СКЗИ", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("От кого получены", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("Дата получения", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("ФИО пользователя СКЗИ", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("Дата подключения", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("ФИО сотрудника, произведшего подключение", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("Номера аппаратных средств, к которым подключены СКЗИ", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("Дата изьятия", fontheader);
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.EndTableRow();

                //export
                List<JournalECP> szilst = App.akbmeddbEntities.JournalECP.ToList();
                foreach (JournalECP sziitem in szilst)
                {
                    docWriter.StartTableRow();
                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{sziitem.NumberECP}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{sziitem.Sender}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{String.Format("{0:dd.MM.yyyy}", sziitem.DateReceipt)}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{sziitem.Employee.FullName}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{String.Format("{0:dd.MM.yyyy}", sziitem.DateConnect)}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{sziitem.TechnicalSupEmployee.FullName}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{sziitem.HardwareNum}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{String.Format("{0:dd.MM.yyyy}", sziitem.DateEnd)}", fontcell);
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.EndTableRow();
                }
                docWriter.EndTable();

                SectionProperties secProperties = docWriter.CreateSectionProperties();
                secProperties.PageOrientation = PageOrientation.Landscape;
                secProperties.PageMargins = new Padding(30, 30, 30, 0);
                docWriter.DefineSection(secProperties);

                docWriter.EndDocument();
                docWriter.Close();
            }
        }
    }
}
