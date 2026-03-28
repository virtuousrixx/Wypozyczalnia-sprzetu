namespace Wypożyczalnia_sprzętu;

public class Report
{
    public void PrintReport(List<Equipment> equipment, IEnumerable<Rent> rentals)
    {
        Console.WriteLine("Raport:");

        Console.WriteLine($"Liczba sprzętu: {equipment.Count}");
        Console.WriteLine($"Dostępny sprzęt: {equipment.Count(e => e.IsAvailable)}");
        Console.WriteLine($"Liczba wypożyczonego sprzętu: {equipment.Count(e => !e.IsAvailable)}");
        Console.WriteLine($"Aktywne wypożyczenia: {rentals.Count(r => !r.IsReturned)}");
        Console.WriteLine($"Przeterminowane wypożyczenia: {rentals.Count(r => !r.IsReturned && r.DueDate < DateTime.Now)}");
    }
}