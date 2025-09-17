namespace hotel_booking.models
{
    public class Reserva
    {
        public string? Id { get; set; }
        public required Pessoa Pessoa { get; set; }
        public required Suite Suite { get; set; }
        public required int Estadia { get; set; }
        public required decimal ValorTotal { get; set; }
    }
}