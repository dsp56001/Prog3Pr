namespace NinjectDemo
{
    public interface IWeapon
    {
        string Name { get; }
        string Hit(string target);
    }
}