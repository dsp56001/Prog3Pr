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
using WpfAppDog.ViewModels;
using WpfAppDogDepend;

namespace WpfAppDog
{
    /// <summary>
    /// Interaction logic for WpfMammals.xaml
    /// </summary>
    public partial class WpfMammals : Window
    {
        public WpfMammals()
        {
            InitializeComponent();
        }

        private void MammalViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelMammals viewControl = new WpfAppDog.ViewModels.ViewModelMammals(App.Mammals);
            viewControl.LoadMammals();



            MammalView1.DataContext = viewControl;


        }
    }
}
