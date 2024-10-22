using DogLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppDog.Models;
using WpfAppDogDepend;

namespace WpfAppDog.ViewModels
{
    public class ViewModelMammals
    {

        

        public ObservableCollection<ViewModelMammal> Mammals
        {
            get;
            set;
        }

        public ViewModelMammals(ObservableCollection<ViewModelMammal> mammals)
        {
            Mammals = mammals;
        }

        public void LoadMammals()
        {
            if (Mammals == null)
            {
                Mammals = new ObservableCollection<ViewModelMammal>()
                {
                    new ViewModelMammal ( new Dog{ BarkSound="woof!", Name="fido"}),
                    new ViewModelMammal ( new Dog{ BarkSound="arf!", Name="rover"}),
                    new ViewModelMammal ( new Dog{ BarkSound="arf!", Name="milo"}),
                    new ViewModelMammal ( new Dog{ BarkSound="arf!", Name="spot"})
                };
            }

            
        }
    }
}
