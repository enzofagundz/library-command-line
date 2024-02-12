using System;

namespace ConsoleApp1
{
    class Menu
    {
        public static void Show(bool clear = true)
        {

            if (clear) 
                Console.Clear();
            
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Produto");
            Console.WriteLine("2 - Fornecedor");
            Console.WriteLine("3 - Cliente");
            Console.WriteLine("4 - Sair");

            string? opcao = Console.ReadLine();
            int opcaoInt = Convert.ToInt32(opcao);

            switch (opcaoInt)
            {
                case 1:
                    Console.WriteLine("Acessar área de produtos");
                    Product.ShowProductMenu();
                    break;
                case 2:
                    Console.WriteLine("Acessar área de fornecedores");
                    Supplier.ShowSupplierMenu();
                    break;
                case 3:
                    Console.WriteLine("Acessar área de clientes");
                    Costumer.ShowCostumerMenu();
                    break;
                case 4:
                    Console.WriteLine("Sair");
                    Console.WriteLine("Obrigado por usar nosso sistema!");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }
}