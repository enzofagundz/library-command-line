using System;

namespace ConsoleApp1
{
    class Product(string name, double price, int quantity, Supplier supplier) : IController
    {
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public int Quantity { get; set; } = quantity;
        public Supplier Supplier { get; set; } = supplier;
    
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
        }

        private static void Read() {}

        private static void Update() {}
        
        private static void Delete() {}
    }
}