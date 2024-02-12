using System;

namespace ConsoleApp1 {
    class Purchase(Product product, int quantity, Costumer costumer, Supplier supplier) : IController
    {
        public Product Product { get; set; } = product;
        public int Quantity { get; set; } = quantity;
        public double TotalPrice { get; set; } = product.Price * quantity;
        public DateTime Date { get; set; } = DateTime.Now;
        public Costumer Costumer { get; set; } = costumer;
        public Supplier Supplier { get; set; } = supplier;
        
        private static void Create() {}

        private static void Read() {}

        private static void Update() {}
        
        private static void Delete() {}
    }
}