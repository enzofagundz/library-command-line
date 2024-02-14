using System;
using System.Security.Principal;

namespace ConsoleApp1 {
    class Purchase(string productId, string costumerEmail, string supplierCnpj, double total) : IController
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProductId { get; set; } = productId;
        public DateTime Date { get; set; } = DateTime.Now;
        public string CostumerEmail { get; set; } = costumerEmail;
        public string SupplierCnpj { get; set; } = supplierCnpj;
        public double Total { get; set; } = total;
        
        private static void Create() {
            Console.WriteLine("Digite o código do produto:");
            string? productId = Console.ReadLine();

            if (productId == null || productId.Length < 3 || productId.Length > 50)
            {
                Console.WriteLine("Código inválido");
                return;
            }

            Console.WriteLine("Digite o email do cliente:");
            string? costumerEmail = Console.ReadLine();

            if (costumerEmail == null || !costumerEmail.Contains('@') || !costumerEmail.Contains('.') || costumerEmail.Length < 5 || costumerEmail.Length > 50 || costumerEmail.Contains(' '))
            {
                Console.WriteLine("Email inválido");
                return;
            }

            Console.WriteLine("Digite o CNPJ do fornecedor:");
            string? supplierCnpj = Console.ReadLine();

            if (supplierCnpj == null || supplierCnpj.Length != 14)
            {
                Console.WriteLine("CNPJ inválido");
                return;
            }

            Console.WriteLine("Digite o total da compra:");
            var total = Console.ReadLine();
            double totalDouble = Convert.ToDouble(total);

            if (totalDouble < 0)
            {
                Console.WriteLine("Total inválido");
                return;
            }

            Purchase purchase = new (productId, costumerEmail, supplierCnpj, totalDouble);
            string content = $"id: {purchase.Id} - productId: {purchase.ProductId} - date: {purchase.Date} - costumerEmail: {purchase.CostumerEmail} - supplierCnpj: {purchase.SupplierCnpj} - total: {purchase.Total};";

            ManageFiles.Create("purchase", content);
            Console.WriteLine("Compra realizada com sucesso!");
            Menu.Show(false);
        }

        private static void Read() {
            string[] purchases = ManageFiles.Read("purchase");
            foreach (string purchase in purchases)
            {
                string[] purchaseData = purchase.Split(" - ");
                Console.WriteLine($"Id: {purchaseData[0]}");
                Console.WriteLine($"Produto: {purchaseData[1]}");
                Console.WriteLine($"Data: {purchaseData[2]}");
                Console.WriteLine($"Cliente: {purchaseData[3]}");
                Console.WriteLine($"Fornecedor: {purchaseData[4]}");
                Console.WriteLine($"Total: {purchaseData[5]}");
                Console.WriteLine();
            }

            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
            Menu.Show();
        }

        private static void Update() {}
        
        private static void Delete() {}

        public static void ShowPurchaseMenu()
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Comprar");
            Console.WriteLine("2 - Listar compras");
            Console.WriteLine("3 - Voltar");
            string? opcao = Console.ReadLine();
            int opcaoInt = Convert.ToInt32(opcao);
            switch (opcaoInt)
            {
                case 1:
                    Console.WriteLine("Comprar");
                    Create();
                    break;
                case 2:
                    Console.WriteLine("Listar compras");
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
    }
}