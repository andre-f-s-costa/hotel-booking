# Hotel Booking

Este projeto é um sistema básico de reservas de suítes de hotel, desenvolvido em C#. Ele permite cadastrar reservas, aplicar descontos e gerenciar informações de hóspedes e acomodações.

## Lógica de negócio

- Se a estadia for superior a 10 dias, aplica-se um desconto de 10% no valor da diária.
- O preço com desconto é calculado no momento da reserva, sem alterar o valor original da suíte.
- Cada reserva contém: hóspede, suíte, número de dias, ID da reserva e o valor final.

## Tecnologias utilizadas

- Linguagem: C#
- Estrutura de dados: List<T>
- Paradigma: Programação orientada a objetos

## Execução

1. Clone o repositório
2. Acesse a raiz do projeto com ```cd hotel-booking```
3. Execute o programa principal com ```dotnet run```
