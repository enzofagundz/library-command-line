using System;
using Service;
using Repository;

namespace Entities
{
    class Supplier(string name, string city, string phone, string email, string cnpj) : IRepository
    {
        public string Name { get; set; } = name;
        public string City { get; set; } = city;
        public string Phone { get; set; } = phone;
        public string Email { get; set; } = email;
        public string Cnpj { get; set; } = cnpj;

        public static void ShowSupplierMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar fornecedor");
            Console.WriteLine("2 - Listar fornecedores");
            Console.WriteLine("3 - Atualizar fornecedor");
            Console.WriteLine("4 - Voltar");

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
                    Console.WriteLine("Atualizar fornecedor");
                    Update();
                    break;
                case 4:
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

            Console.WriteLine("Digite o CNPJ do fornecedor:");
            string? cnpj = Console.ReadLine();

            if (cnpj == null || cnpj.Length != 14)
            {
                Console.WriteLine("CNPJ inválido");
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

            Supplier supplier = new(name, city, phone, email, cnpj);
            string supllierString = $"{supplier.Name} - {supplier.City} - {supplier.Phone} - {supplier.Email} - {supplier.Cnpj};";

            ManageFiles.Create("supplier", supllierString);

            Console.WriteLine("Fornecedor cadastrado com sucesso!");
            Menu.Show(false);
        }

        private static void Read()
        {
            string[] costumers = ManageFiles.Read("supplier");
            foreach (string costumer in costumers)
            {
                string[] costumerData = costumer.Split(" - ");
                Console.WriteLine($"Nome: {costumerData[0]}");
                Console.WriteLine($"Cidade: {costumerData[1]}");
                Console.WriteLine($"Telefone: {costumerData[2]}");
                Console.WriteLine($"Email: {costumerData[3]}");
                Console.WriteLine($"CNPJ: {costumerData[4]}");
                Console.WriteLine();
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Menu.Show();
        }

        private static void Update()
        {
            // recebe o cnpj do fornecedor
            // verifica se o fornecedor existe
            // se não existir, retorna
            // se existir, retorna os dados atuais do fornecedor
            // pergunta qual dado deseja alterar
            // recebe o novo dado
            // altera o dado
            // salva o novo fornecedor

            Console.WriteLine("Digite o CNPJ do fornecedor:");
            string? cnpj = Console.ReadLine();

            if (cnpj == null || cnpj.Length != 14)
            {
                Console.WriteLine("CNPJ inválido");
                return;
            }

            // send the filename and the cnpj to the ManageFiles.Update method, and put his return in a variable 
            string[] supplierData = ManageFiles.Update("supplier", cnpj, 4);
            if (supplierData.Length == 0)
            {
                Console.WriteLine("Fornecedor não encontrado");
                return;
            }

            Supplier oldSupplier = new(supplierData[0], supplierData[1], supplierData[2], supplierData[3], supplierData[4]);

            Console.WriteLine($"Nome: {oldSupplier.Name}");
            Console.WriteLine($"Cidade: {oldSupplier.City}");
            Console.WriteLine($"Telefone: {oldSupplier.Phone}");
            Console.WriteLine($"Email: {oldSupplier.Email}");
            Console.WriteLine($"CNPJ: {oldSupplier.Cnpj}");

            Console.WriteLine("Digite qual dado deseja alterar:");
            Console.WriteLine("1 - Nome");
            Console.WriteLine("2 - Cidade");
            Console.WriteLine("3 - Telefone");
            Console.WriteLine("4 - Email");

            string? option = Console.ReadLine();
            int optionInt = Convert.ToInt32(option);

            Console.WriteLine("Digite o novo dado:");
            string? newField = Console.ReadLine();

            if (newField == null || newField.Length < 3 || newField.Length > 50)
            {
                return;
            }

            switch (optionInt)
            {
                case 1:
                    oldSupplier.Name = newField;
                    break;
                case 2:
                    oldSupplier.City = newField;
                    break;
                case 3:
                    oldSupplier.Phone = newField;
                    break;
                case 4:
                    oldSupplier.Email = newField;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            string newSupplierString = $"{oldSupplier.Name} - {oldSupplier.City} - {oldSupplier.Phone} - {oldSupplier.Email} - {oldSupplier.Cnpj};";
            // delete the old supplier
            // create the new supplier

            // ManageFiles.Delete("supplier");
            // ManageFiles.Create("supplier", newSupplierString);
        }

        private static void Delete()
        {
        }
    }
}