using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WpfAppDogBinding.Models;

namespace WpfAppDogBinding.ViewModels
{
    public class DogViewModel : BaseViewModel
    {
        Dog dog;

        public ICommand HappyBirthdayCommand { get; set; }

        public DogViewModel(Dog d)
        {
            this.dog = d;
            HappyBirthdayCommand = new BasicCommand(ExecuteHappyBirthday, CanExecuteHappyBirthday); ;
        }

        public bool CanExecuteHappyBirthday(object parameter)
        {
            return true;
        }

        public void ExecuteHappyBirthday(object parameter)
        {
            this.dog.HappyBirthDay();
            //let dog call happy birthaty then set the age to the 
            //post happy birthday dog age
            this.Age = this.dog.Age; 
        }

        public string Name
        {
            get => dog.Name;
            set
            {
                this.dog.Name = value;
                OnPropertyChanged();
                OnPropertyChanged("AboutString");
            }
        }

        public int Age
        {
            get => dog.Age;
            set
            {
                this.dog.Age = value;
                OnPropertyChanged();
                OnPropertyChanged("AboutString");
            }
        }

        public int Weight
        {
            get => dog.Weight;
            set
            {
                this.dog.Weight = value;
                OnPropertyChanged();
                OnPropertyChanged("AboutString");
            }
        }

        public string AboutString { get=>dog.AboutString;}

        
    }
}
