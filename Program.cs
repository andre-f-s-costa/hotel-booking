// See https://aka.ms/new-console-template for more information
using hotel_booking.models;
using hotel_booking.services;

HotelService hotelService = new();
Random random = new();

for (int i = 1; i < 51; i++)
{
    int cap = random.Next(1, 4);
    Suite suite = new()
    {
        Capacidade = random.Next(1, 4),
        Numero = i,
        PrecoPorNoite = cap > 2 ? 85 : 50
    };
    hotelService.criarSuite(suite);
}

Pessoa? pessoa = null;

while (true)
{
    Console.WriteLine("Bem vindo ao hotel DIO\n--------------Menu--------------");
    if (pessoa != null)
    {
        Console.WriteLine("1. Recadastrar");
    }
    else
    {
        Console.WriteLine("1. Cadastrar");
    }
    Console.WriteLine("2. Criar reserva");
    Console.WriteLine("3. Ver detalhes da reserva");
    Console.WriteLine("4. Cancelar reserva");
    Console.WriteLine("5. Sair");
    Console.Write("Selecione uma opção: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Digite seu primeiro nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite seu sobrenome: ");
            string sobrenome = Console.ReadLine();
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();
            if (nome == null || nome.Trim().Length==0 || sobrenome == null || sobrenome.Trim().Length==0 || email == null || email.Trim().Length==0)
            {
                Console.WriteLine("Todos os dados devem ser preenchidos");
                break;
            }
            pessoa = new()
            {
                Email = email,
                Nome = nome,
                Sobrenome = sobrenome
            };
            break;
        case "2":
            if (pessoa == null) break;
            Console.Write("Escolha uma suite por numero (de 1 a 50): ");
            bool parsedSuite = int.TryParse(Console.ReadLine(), out int numeroDaSuite);
            Console.Write("Quantas noites? ");
            bool parsedNoites = int.TryParse(Console.ReadLine(), out int noites);
            if (!parsedNoites && !parsedSuite)
            {
                Console.WriteLine("Valores não digitados ou com tipo incorreto.");
            }
            var idReserva = hotelService.criarReserva(numeroDaSuite, pessoa, noites);
            Console.WriteLine($"Reserva criada, anote: {idReserva}.");
            break;
        case "3":
            if (pessoa == null) break;
            Console.Write("Digite o numero da reserva: ");
            string id = Console.ReadLine();
            if (id == null || id.Trim().Length == 0)
            {
                Console.WriteLine("Id da reserva não foi digitada.");
                break;
            }
            Console.WriteLine("-----------------------------------");
            hotelService.mostrarDetalhesReserva(id);
            Console.WriteLine("-----------------------------------");
            break;
        case "4":
            if (pessoa == null) break;
            Console.Write("Digite o numero da reserva: ");
            string reserva = Console.ReadLine();
            if (reserva == null || reserva.Trim().Length == 0)
            {
                Console.WriteLine("Id da reserva não foi digitada.");
                break;
            }
            hotelService.cancelarReserva(reserva);
            Console.WriteLine("Reserva cancelada.");
            break;
        case "5":
            Console.WriteLine("Saindo...");
            return;
        default:
            Console.WriteLine("Opção inválida, tente novamente.");
            break;
    }
}