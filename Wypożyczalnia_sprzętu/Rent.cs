namespace Wypożyczalnia_sprzętu;

public class Rent
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public Equipment Equipment { get; set; }
    public Person Person { get; set; }

    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; private set; }

    public decimal Penalty { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;

    public void Return(DateTime returnDate)
    {
        ReturnDate = returnDate;
        Penalty = CalculatePenalty();
    }

    private decimal CalculatePenalty()
    {
        if (!ReturnDate.HasValue || ReturnDate <= DueDate)
            return 0;

        int daysLate = (ReturnDate.Value - DueDate).Days;
        return daysLate * 10;
    }
}