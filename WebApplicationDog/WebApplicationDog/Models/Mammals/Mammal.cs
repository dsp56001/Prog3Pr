namespace WebApplicationDog.Models.Mammals
{
    public class Mammal : IMammal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public string Sound { get; set; }

        protected static int count = 0;

        public Mammal()
        {
            this.Id = count++;
            this.Name = "Mammal";
            this.Age = 1;
            this.Sound = "Sound";
            this.Weight = 10;
        }

        public virtual void HappyBirthday()
        {
            this.Age++;
        }

        public virtual string MakeSound()
        {
            return Sound;
        }
    }
}
