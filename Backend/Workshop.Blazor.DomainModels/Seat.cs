namespace Workshop.Blazor.DomainModels
{
    public class Seat : EntityBase
    {
        public decimal Price { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }

        public Event Event { get; set; }

    }
}