namespace Wypożyczalnia_sprzętu
{
    public class RentManage
    {
        private readonly List<Rent> rentalsList = new List<Rent>();

        public Rent RentOutEquipment(Person person, Equipment gear, int days)
        {
            if (!gear.IsAvailable)
                throw new Exception("Sprzęt nie jest dostępny");

            int currentActive = rentalsList.Count(r => r.Person == person && !r.IsReturned);

            if (currentActive >= person.MaxActiveRentals)
                throw new Exception("Nie możesz mieć więcej aktywnych wypożyczeń");

            var newRental = new Rent
            {
                Person = person,
                Equipment = gear,
                RentDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(days)
            };

            gear.MarkUnavailable();
            rentalsList.Add(newRental);

            return newRental;
        }

        public void ReturnGear(Rent rental)
        {
            rental.Return(DateTime.Now);
            rental.Equipment.MarkAvailable();
        }

        public IEnumerable<Rent> GetAllRentals()
        {
            return rentalsList;
        }

        public IEnumerable<Rent> GetActiveRentalsForUser(Person person)
        {
            return rentalsList.Where(r => r.Person == person && !r.IsReturned);
        }

        public IEnumerable<Rent> GetOverdueRentals()
        {
            return rentalsList.Where(r => !r.IsReturned && r.DueDate < DateTime.Now);
        }
    }
}