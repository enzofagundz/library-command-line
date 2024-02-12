using System;

namespace ConsoleApp1
{
    class Supplier(string name, string city, string phone, string email) : IController
    {
        public string Name { get; set; } = name;
        public string City { get; set; } = city;
        public string Phone { get; set; } = phone;
        public string Email { get; set; } = email;

        public static void ShowSupplierMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar fornecedor");
            Console.WriteLine("2 - Listar fornecedores");
            Console.WriteLine("3 - Voltar");

            string? opcao = Console.ReadLine();
            int opcaoInt = Convert.ToInt32(opcao);

            switch (opcaoInt)
            {
                case 1:
                    Console.WriteLine("Cadastrar fornecedor");
                    Create();
                    break;
                case 2:
                    Console.WriteLine("Listar fornecedores");
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
            Console.WriteLine("Digite o nome do fornecedor:");
            string? name = Console.ReadLine();

            if (name == null || name.Length < 3 || name.Length > 50)
            {
                Console.WriteLine("Nome inválido");
                return;
            }

            Console.WriteLine("Digite a cidade do fornecedor:");
            string? city = Console.ReadLine();

            if (city == null || city.Length < 3 || city.Length > 50)
            {
                Console.WriteLine("Cidade inválida");
                return;
            }

            Console.WriteLine("Digite o telefone do fornecedor:");
            string? phone = Console.ReadLine();

            if (phone == null || phone.Length < 8 || phone.Length > 15)
            {
                Console.WriteLine("Telefone inválido");
                return;
            }

            Console.WriteLine("Digite o email do fornecedor:");
            string? email = Console.ReadLine();

            if (email == null || !email.Contains('@') || !email.Contains('.') || email.Length < 5 || email.Length > 50 || email.Contains(' '))
            {
                Console.WriteLine("Email inválido");
                return;
            }

            Supplier supplier = new(name, city, phone, email);
            string supllierString = $"{supplier.Name} - {supplier.City} - {supplier.Phone} - {supplier.Email};";
            ManageFiles.Create("supplier", supllierString);

            Console.WriteLine("Fornecedor cadastrado com sucesso!");
            Menu.Show();
        }

        private static void Read()
        {
            string[] suppliers = ManageFiles.Read("supplier");
            foreach (string supplier in suppliers)
            {
                string[] supplierData = supplier.Split(" - ");
                if (supplierData.Length >= 4)
                {
                    Console.WriteLine($"Nome: {supplierData[0]}");
                    Console.WriteLine($"Cidade: {supplierData[1]}");
                    Console.WriteLine($"Telefone: {supplierData[2]}");
                    Console.WriteLine($"Email: {supplierData[3]}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Dados do fornecedor incompletos.");
                }
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            Menu.Show();
        }

        private static void Update() { }

        private static void Delete() {
        }
    }
}