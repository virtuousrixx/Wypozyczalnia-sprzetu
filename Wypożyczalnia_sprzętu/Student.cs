namespace Wypożyczalnia_sprzętu;

public class Student : Person
{
    public override int MaxActiveRentals => 2;
    public override string UserType => "Student";
}