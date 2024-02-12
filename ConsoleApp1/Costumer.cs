using System;

namespace ConsoleApp1
{
    class Costumer(string name, string email, DateTime birthDate) : IController
    {
        public string Name { get; set; } = name;
        public string Email { get; set; } = email;
        public DateTime BirthDate { get; set; } = birthDate;

        public static void ShowCostumerMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Listar clientes");
            Console.WriteLine("3 - Voltar");

            string? opcao = Console.ReadLine();
            int opcaoInt = Convert.ToInt32(opcao);

            switch (opcaoInt)
            {
                case 1:
                    Console.WriteLine("Cadastrar cliente");
                    Create();
                    break;
                case 2:
                    Console.WriteLine("Listar clientes");
                    Read();
                    break;
                case 3:
                    Console.WriteLine("Voltar");
                    Menu.Show();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        private static void Create()
        {
            Console.WriteLine("Digite o nome do cliente:");
            string? name = Console.ReadLine();

            if (name == null || name.Length < 3 || name.Length > 50)
            {
                Console.WriteLine("Nome inválido");
                return;
            }

            Console.WriteLine("Digite o email do cliente:");
            string? email = Console.ReadLine();

            if (email == null || !email.Contains('@') || !email.Contains('.') || email.Length < 5 || email.Length > 50 || email.Contains(' '))
            {
                Console.WriteLine("Email inválido");
                return;
            }

            Console.WriteLine("Digite a data de nascimento do cliente:");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

            if (birthDate > DateTime.Now)
            {
                Console.WriteLine("Data de nascimento inválida");
                return;
            }

            Costumer costumer = new Costumer(name, email, birthDate);
            string costumerString = costumer.Name + " - " + costumer.Email + " - " + costumer.BirthDate;
            ManageFiles.Create("costumer", costumerString);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        private static void Delete()
        {
            throw new NotImplementedException();
        }

        private static void Read()
        {
            ManageFiles.Read("costumer");
        }

        private static void Update()
        {
            throw new NotImplementedException();
        }
    }
}