namespace FormulaAirLine.BookingProcessing.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PassenegerName { get; set; } = "";
        public string PassengerNb { get; set; } = "";
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public int Status { get; set; }
    }
}
