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

                docWriter.StartTable(2, tableProps);

                //headerrows
                docWriter.StartTableRow(rowProps);
                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("Серийные номера СКЗИ");
                docWriter.EndParagraph();
                docWriter.EndTableCell();

                docWriter.StartTableCell(cellProps);
                docWriter.StartParagraph();
                docWriter.AddTextRun("От кого получены");
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
                    docWriter.AddTextRun($"{sziitem.NumberECP}");
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();

                    docWriter.StartTableCell(cellProps);
                    docWriter.StartParagraph();
                    docWriter.AddTextRun($"{sziitem.Sender}");
                    docWriter.EndParagraph();
                    docWriter.EndTableCell();
                    docWriter.EndTableRow();
                }

                docWriter.EndTable();
                docWriter.EndDocument();
                docWriter.Close();
            }
        }
    }
}
