namespace Wypożyczalnia_sprzętu;

class Program
{
    static void Main()
    {
        var app = new AppContext();
        app.Run();
    }
}

class AppContext
{
    private readonly RentManage rentalSvc = new RentManage();
    private readonly Report reportSvc = new Report();

    public void Run()
    {
        var items = InitializeEquipment();

        var student = new Student
        {
            FirstName = "John",
            LastName = "Smith"
        };

        PrintAllEquipment(items);
       

        var firstItem = items[0];
        var rent = rentalSvc.RentOutEquipment(student, firstItem, 2);

        TryRentAgain(student, firstItem);

        PrintUserRentals(student);

        items[1].MarkUnavailable();

        rent.Return(DateTime.Now.AddDays(5));
        firstItem.MarkAvailable();

        Console.WriteLine("\nKara: " + rent.Penalty);

        PrintOverdue();

        reportSvc.PrintReport(items, rentalSvc.GetAllRentals());
    }

    private List<Equipment> InitializeEquipment()
    {
        var list = new List<Equipment>();

        list.Add(new Laptop
        {
            Name = "Asus",
            Ram = 32,
            DiskSize = "1TB"
        });

        list.Add(new Projector
        {
            Name = "Epson",
            Size = "big",
            Resolution = "4K"
        });

        list.Add(new Camera
        {
            Name = "GoPro",
            MaxResolution = "4K",
            ScreenSize = "2\""
        });

        return list;
    }

    private void TryRentAgain(Student student, Equipment equipment)
    {
        try
        {
            rentalSvc.RentOutEquipment(student, equipment, 2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void PrintAllEquipment(List<Equipment> items)
    {
        Console.WriteLine("Lista sprzętu:");

        foreach (var e in items)
        {
            Console.WriteLine($"{e.Name} - {(e.IsAvailable ? "Dostępny" : "Niedostępny")}");
        }
    }
    

    private void PrintUserRentals(Person person)
    {
        Console.WriteLine($"\nUżytkownik {person.FirstName} wypożyczył:");

        var rentals = rentalSvc.GetActiveRentalsForUser(person);

        foreach (var r in rentals)
        {
            Console.WriteLine($"{r.Equipment.Name} do {r.DueDate}");
        }
    }

    private void PrintOverdue()
    {
        Console.WriteLine("\nPrzeterminowane wypożyczenia: \n");

        var overdue = rentalSvc.GetOverdueRentals();

        foreach (var r in overdue)
        {
            Console.WriteLine($"{r.Equipment.Name}, {r.Person.FirstName} do {r.DueDate}");
        }
    }
}