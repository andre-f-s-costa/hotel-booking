using hotel_booking.models;

namespace hotel_booking.services
{
    class HotelService
    {
        private readonly List<Suite> suites = [];
        private readonly List<Reserva> reservas = [];

        public void criarSuite(Suite suite)
        {
            suites.Add(suite);
        }

        public void mostrarDetalhesReserva(string id)
        {
            var reserva = reservas.Find(r => r.Id != null && r.Id.Equals(id));
            if (reserva != null)
            {
                Console.WriteLine($"Id: {reserva.Id}");
                Console.WriteLine($"Nome vinculado: {reserva.Pessoa.Nome}");
                Console.WriteLine($"Email vinculado: {reserva.Pessoa.Email}");
                Console.WriteLine($"Número da suite: {reserva.Suite.Numero}");
                Console.WriteLine($"Capacidade da suite: {reserva.Suite.Capacidade}");
                Console.WriteLine($"Quantidade de dias da reserva: {reserva.Estadia}");
                Console.WriteLine($"Preço total: {reserva.ValorTotal}");
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.");
            }
        }

        public string criarReserva(int numeroDaSuite, Pessoa pessoa, int noites)
        {
            var suite = suites.Find(s => s.Numero.Equals(numeroDaSuite));
            if (suite != null)
            {
                if (reservas.Exists(r => r.Suite.Equals(suite))) throw new Exception("Quarto já está em uso.");
                string id = gerarIdReserva();
                decimal ValorFinal = suite.PrecoPorNoite * noites;
                if (noites > 10) ValorFinal -= ValorFinal * (decimal)0.1;
                Reserva reserva = new() { Pessoa = pessoa, Suite = suite, Id = id, Estadia = noites, ValorTotal = ValorFinal };
                reservas.Add(reserva);
                return id;
            }
            throw new Exception("Suite não encontrada.");
        }

        public void cancelarReserva(string id)
        {
            var reserva = reservas.Find(r => r.Id!=null && r.Equals(id));
            if (reserva!=null)
            {
                reservas.Remove(reserva);
            }
            throw new Exception("Reserva não encontrada.");
        }

        private string gerarIdReserva()
        {
            Random random = new();
            string[] letters = ["a","c","e","g","i","k","m","o","q","s","u","B","D","F","H","J","L","N","P","R","T","V"];
            random.Shuffle(letters);
            string id = $"{letters.GetValue(0)}{letters.GetValue(2)}{letters.GetValue(4)}{random.NextInt64(1000, 1999)}{letters.GetValue(1)}{letters.GetValue(3)}{letters.GetValue(5)}{random.NextInt64(100, 999)}";
            return id;
        }
    }
}