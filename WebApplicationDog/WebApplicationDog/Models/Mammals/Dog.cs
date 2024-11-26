namespace WebApplicationDog.Models.Mammals
{
    public class Dog : Mammal
    {
        
        public Dog()
        {
            this.Name = "Fido";
            this.Sound = "Woof!";
           
        }

        public string Bark()
        {
            return this.MakeSound();
        }

    }
}
