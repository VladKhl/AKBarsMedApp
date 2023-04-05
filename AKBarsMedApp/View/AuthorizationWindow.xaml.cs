using AKBarsMedApp.View;
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

namespace AKBarsMedApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AutorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = App.akbmeddbEntities.User.Where(x => x.Login == LoginTB.Text && x.Password == PassPB.Password).FirstOrDefault();
                if (user != null)
                {
                    new HomeWindow().Show();
                    MessageBox.Show("Вы успешно авторизованы");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message); 
            }
        }
    }
}
