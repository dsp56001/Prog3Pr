using DogLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDog;
using WpfAppDog.Models;

namespace WpfAppDogDepend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Private nullable field to hold the collection of mammals
        private static ObservableCollection<ViewModelMammal>? mammals;

        public static ObservableCollection<ViewModelMammal> Mammals
        {
            get
            {
                if (App.mammals == null)
                    App.mammals = InitMammals();
                return mammals;
            }
        }

        private static ObservableCollection<ViewModelMammal> InitMammals()
        {
            return new ObservableCollection<ViewModelMammal>()
                    {
                        new ViewModelMammal(new Dog { BarkSound = "woof!", Name = "fido" }),
                        new ViewModelMammal(new Dog { BarkSound = "arf!", Name = "rover" }),
                        new ViewModelMammal(new Dog { BarkSound = "arf!", Name = "milo" }),
                        new ViewModelMammal(new Dog { BarkSound = "arf!", Name = "spot" })
                    };
        }

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

        }
    }
}
