using System;
using System.Collections.Generic;

namespace V01
{
    // Classe que representa um pedido
    public class Order
    {
        public int OrderId { get; set; } // ID do pedido
        public string CustomerName { get; set; } // Nome do cliente
        public List<string> Items { get; set; } // Itens do pedido
        public OrderStatus Status { get; set; } // Status do pedido
    }

    // Enumeração que representa o status do pedido
    public enum OrderStatus
    {
        Pending, // Pendente
        Preparing, // Preparando
        Served // Servido
    }

    // Classe responsável por gerenciar os pedidos
    public class OrderManager
    {
        private List<Order> orders; // Lista de pedidos

        public OrderManager()
        {
            orders = new List<Order>(); // Inicializa a lista de pedidos
        }

        // Método para realizar um novo pedido
        public void PlaceOrder(string customerName, List<string> items)
        {
            var newOrder = new Order
            {
                OrderId = orders.Count + 1, // Atribui um novo ID para o pedido
                CustomerName = customerName,
                Items = items,
                Status = OrderStatus.Pending // Define o status inicial como Pendente
            };

            orders.Add(newOrder); // Adiciona o pedido à lista de pedidos
            Console.WriteLine($"Order {newOrder.OrderId} placed for {customerName}");
        }

        // Método para atualizar o status de um pedido existente
        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = orders.Find(o => o.OrderId == orderId); // Procura o pedido pelo ID
            if (order != null)
            {
                order.Status = status; // Atualiza o status do pedido
                Console.WriteLine($"Order {order.OrderId} status updated to {status}");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found");
            }
        }

        // Método para exibir os detalhes de um pedido
        public void DisplayOrderDetails(int orderId)
        {
            var order = orders.Find(o => o.OrderId == orderId); // Procura o pedido pelo ID
            if (order != null)
            {
                Console.WriteLine($"Order ID: {order.OrderId}");
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine("Items:");
                foreach (var item in order.Items)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Status: {order.Status}");
            }
            else
            {
                Console.WriteLine($"Order {orderId} not found");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            var orderManager = new OrderManager();

            // Realiza um pedido
            orderManager.PlaceOrder("John Doe", new List<string> { "Burger", "Fries", "Coke" });

            // Realiza outro pedido
            orderManager.PlaceOrder("Jane Smith", new List<string> { "Pizza", "Salad", "Water" });

            // Atualiza o status de um pedido
            orderManager.UpdateOrderStatus(1, OrderStatus.Preparing);

            // Exibe os detalhes do pedido
            orderManager.DisplayOrderDetails(1);
            orderManager.DisplayOrderDetails(2);
        }
    }
}
