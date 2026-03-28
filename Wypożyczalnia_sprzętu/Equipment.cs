namespace Wypożyczalnia_sprzętu;

    public abstract class Equipment
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public bool IsAvailable { get; private set; } = true;

        public void MarkUnavailable() => IsAvailable = false;
        public void MarkAvailable() => IsAvailable = true;
    }