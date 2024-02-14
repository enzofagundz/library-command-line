using System;

namespace ConsoleApp1
{
    class Product(string name, double price, int quantity, string supplierCNPJ) : IController
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public int Quantity { get; set; } = quantity;
        public string SupplierCNPJ { get; set; } = supplierCNPJ;
    
        public static void ShowProductMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Voltar");
    
            string? opcao = Console.ReadLine();
            int opcaoInt = Convert.ToInt32(opcao);
    
            switch (opcaoInt)
            {
                case 1:
                    Console.WriteLine("Cadastrar produto");
                    Create();
                    break;
                case 2:
                    Console.WriteLine("Listar produtos");
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

        private static void Create() {
            // nome, preço, quantidade e fornecedor
            // TODO: criar uma classe util para validar os inputs

            Console.WriteLine("Digite o nome do produto:");
            string? name = Console.ReadLine();

            if (name == null || name.Length < 3 || name.Length > 50)
            {
                Console.WriteLine("Nome inválido");
                return;
            }

            Console.WriteLine("Digite o preço do produto:");
            string? price = Console.ReadLine();

            if (price == null || Convert.ToDouble(price) < 0)
            {
                Console.WriteLine("Preço inválido");
                return;
            }

            Console.WriteLine("Digite a quantidade do produto:");

            string? quantity = Console.ReadLine();

            if (quantity == null || Convert.ToInt32(quantity) < 0)
            {
                Console.WriteLine("Quantidade inválida");
                return;
            }

            Console.WriteLine("Digite o CNPJ do fornecedor:");
            string? cnpj = Console.ReadLine();

            if (cnpj == null || cnpj.Length != 14)
            {
                Console.WriteLine("CNPJ inválido");
                return;
            }

            Product product = new (name, Convert.ToDouble(price), Convert.ToInt32(quantity), cnpj);
            string content = $"id: {product.Id} - name: {product.Name} - price: {product.Price} - quantity: {product.Quantity} - supplierCNPJ: {product.SupplierCNPJ};";
            ManageFiles.Create("product", content);

            Console.WriteLine("Produto cadastrado com sucesso!");
            Menu.Show(false);
        }

        private static void Read() {
            string[] products = ManageFiles.Read("product");
            foreach (string product in products)
            {
                string[] productData = product.Split(" - ");
                Console.WriteLine($"Código: {productData[0]}");
                Console.WriteLine($"Nome: {productData[1]}");
                Console.WriteLine($"Preço: {productData[2]}");
                Console.WriteLine($"Quantidade: {productData[3]}");
                Console.WriteLine($"CNPJ do fornecedor: {productData[4]}");
                Console.WriteLine();
            }

            Menu.Show();
        }

        private static void Update() {}
        
        private static void Delete() {}
    }
}