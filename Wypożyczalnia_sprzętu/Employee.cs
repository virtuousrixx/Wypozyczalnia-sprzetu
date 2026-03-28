namespace Wypożyczalnia_sprzętu;

public class Employee : Person
{
    public override int MaxActiveRentals => 5;
    public override string UserType => "Employee";
}