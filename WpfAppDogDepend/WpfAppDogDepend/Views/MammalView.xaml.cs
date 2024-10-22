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

namespace WpfAppDog.Views
{
    /// <summary>
    /// Interaction logic for MammalView.xaml
    /// </summary>
    public partial class MammalView : UserControl
    {
        public MammalView()
        {
            InitializeComponent();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            tbAbout.Text = ((ViewModelMammal)this.DataContext).About;
        }
    }
}
