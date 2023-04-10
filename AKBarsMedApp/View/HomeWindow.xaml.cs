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
using System.Windows.Shapes;

namespace AKBarsMedApp.View
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            HomeLogoIm.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            HomeLogoIm.Visibility = Visibility.Hidden;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewMenu.SelectedIndex == 0)
            {
                GridMain.Content = new EmployeePage();
            }
            else if (ListViewMenu.SelectedIndex == 1)
            {
                GridMain.Content = new TechSupEmployeePage();
            }
            else if (ListViewMenu.SelectedIndex == 2)
            {
                GridMain.Content = new ECPLogPage();
            }
            else if (ListViewMenu.SelectedIndex == 3)
            {
                GridMain.Content = new SZILogPage();
            }
        }
    }
}
