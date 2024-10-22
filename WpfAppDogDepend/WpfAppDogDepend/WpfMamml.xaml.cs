using DogLibrary;
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
using WpfAppDog.Models;
using WpfAppDog.ViewModels;
using WpfAppDogDepend;

namespace WpfAppDog
{
    /// <summary>
    /// Interaction logic for WpfDog.xaml
    /// </summary>
    public partial class WpfMammal : Window
    {

        int mammalIndex;
        ViewModelMammals viewControl;


        public WpfMammal()
        {
            InitializeComponent();
            mammalIndex = 0;
        }

        private void MammalViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            viewControl = new WpfAppDog.ViewModels.ViewModelMammals(App.mammals);
            viewControl.LoadMammals();
            UpdateDataContext();

        }

        private void UpdateDataContext()
        {
            this.DataContext = viewControl.Mammals[mammalIndex];
            MammalView1.DataContext = viewControl.Mammals[mammalIndex];
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (mammalIndex < viewControl.Mammals.Count -1)
            { mammalIndex++; }
            else
            { mammalIndex = 0; }
            UpdateDataContext();
        }
    }
}
