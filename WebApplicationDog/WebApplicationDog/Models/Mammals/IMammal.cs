namespace WebApplicationDog.Models.Mammals
{
    public interface IMammal : IEntity
    {
        string Name { get; set; }
        int Weight { get; set; }
        int Age { get; set; }
        string Sound { get; set; }
        string MakeSound();
        void HappyBirthday();

    }
}
