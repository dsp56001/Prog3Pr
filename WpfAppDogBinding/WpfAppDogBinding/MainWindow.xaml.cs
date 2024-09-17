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
using WpfAppDogBinding.Models;
using WpfAppDogBinding.ViewModels;

namespace WpfAppDogBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dog d;
        DogViewModel vm;

        public MainWindow()
        {
            
            
            InitializeComponent();
            d = new Dog();
            vm = new DogViewModel(d);

            this.DataContext = vm;

        }

        
    }
}
