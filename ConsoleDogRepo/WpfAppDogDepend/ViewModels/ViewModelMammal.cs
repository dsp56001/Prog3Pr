using DogLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfAppDog.Models
{
    public class ViewModelMammal : BaseViewModel
    {
        IMammal mammal; //conatining base object POCO

        public ICommand HappyBirthday { get; set; }

        //Constructor dependent on the Model class
        public ViewModelMammal(IMammal mammal)
        {
            this.mammal = mammal;
            this.HappyBirthday = new WPFMammalCommand(ExecuteCommandHappyBirthday, CanExecuteCommandHappyBirthday);
        }

        private bool CanExecuteCommandHappyBirthday(object parameter)
        {
            return true ;
        }

        private void ExecuteCommandHappyBirthday(object parameter)
        {
            this.mammal.HappyBirthday();
            RaisePropertyChangedEvent("Age");
        }


        public int Age
        {
            get
            {
                return mammal.Age;
            }
        }

        public string Name
        {
            get
            {
                return mammal.Name;
            }
            set
            {
                if (Name != value)
                {
                    mammal.Name = value;
                    //OLD way
                    //RaisePropertyChanged("Name");
                    //New way PropertyName is optional
                    RaisePropertyChangedEvent("Name");
                }
            }
        }

        public int Weight
        {
            get
            {
                return mammal.Weight;
            }

        }

        public string  About
        {
            get { return mammal.About(); }
        }
        
    }

    public class WPFMammalCommand : ICommand
    {
        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public WPFMammalCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        #region ICommand Members

        public event EventHandler ?CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object ?parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }
            _execute.Invoke(parameter);
        }

        #endregion
    }
}
