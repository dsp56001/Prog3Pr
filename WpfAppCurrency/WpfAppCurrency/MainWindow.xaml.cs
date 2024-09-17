using Currency.US;
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

namespace WpfAppCurrency
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static USCurrencyRepo repo;
        public static USCurrencyRepo Repo
        {
            get
            {
               
                return repo;
            }
            set { repo = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            repo = new USCurrencyRepo() { Coins = new List<Currency.ICoin>() { new Penny() } };

        }

        private void ButtonRepo_Click(object sender, RoutedEventArgs e)
        {
            WindowRepo window = new WindowRepo(repo);
            window.Show();
        }

        private void ButtonMakeChange_Click(object sender, RoutedEventArgs e)
        {
            WindowMakeChange window = new WindowMakeChange(repo);
            window.Show();
        }

        
    }
}
