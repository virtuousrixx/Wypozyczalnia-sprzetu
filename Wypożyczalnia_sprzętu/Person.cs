namespace Wypożyczalnia_sprzętu;

public abstract class Person
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public abstract int MaxActiveRentals { get; }
    public abstract string UserType { get; }
}