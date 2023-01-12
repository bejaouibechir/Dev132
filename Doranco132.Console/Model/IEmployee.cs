namespace Doranco132.Console.Model
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Nom { get; set; }
        decimal Salaire { get; set; }
    }
}