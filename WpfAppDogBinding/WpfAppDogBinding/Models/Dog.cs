using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfAppDogBinding.Models
{
    public class Dog
    {
        public int Age { get; set; }

        protected int weight;
        public int Weight { 
            get => weight; 
            set
            {
                weight = value;
                
                
            } 
        }

        protected string name;

        public string Name {
            get => name;
            set
            {
                name = value;
            }
        }

        public void HappyBirthDay()
        {
            this.Age++;
        }

        public string AboutString
        {
            get
            {
                return About();
            }
        }

        public string About()
        {
            return $"Hello My name is {this.Name} I weigh {this.Weight} I'm {this.Age} years old.";
        }

        public Dog()
        {
            this.Name = "Fido";
            this.Age = 2;
            this.Weight = 7;
        }

        

        
    }
}
