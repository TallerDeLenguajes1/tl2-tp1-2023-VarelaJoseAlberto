namespace CadeteClass
{
    using PedidosClass;
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string telefono;
        private List<Pedido>? listaPedido;//quito para agregar en cadeteria
        private int cantEnvios;
        private float cantGanado;


        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido>? ListaPedido { get => listaPedido; set => listaPedido = value; }
        public int CantEnvios { get => cantEnvios; set => cantEnvios = value; }
        public float CantGanado { get => cantGanado; set => cantGanado = value; }

        public Cadete(int id, string? nombre, string? direccion, string telefono, List<Pedido>? listaPedido, int cantEnvios, float cantGanado)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listaPedido = listaPedido;
            this.cantEnvios = 0;
            this.cantGanado = 0.0f;
        }

        public Cadete()
        {
            this.id = 0;
            this.nombre = "";
            this.direccion = "";
            this.telefono = "";
            this.listaPedido = new List<Pedido>();
            this.CantEnvios = 0;
            this.CantGanado = 0;
        }


        public void TomarPedido(Pedido nuevoPedido)
        {
            this.listaPedido?.Add(nuevoPedido);
        }

        public void AsignarPedido(Pedido pedido)
        {
            this.listaPedido.Add(pedido);
            this.cantEnvios += 1;
            this.cantGanado = (float)CalcularJornal();
        }
        public double CalcularJornal()
        {
            int cantidadPedidosEntregados = listaPedido.Count(p => p.Estado == EstadoPedido.Entregado);
            double tarifaPorPedido = 500;
            double jornal = cantidadPedidosEntregados * tarifaPorPedido;
            return jornal;
        }
        // Método para cambiar el estado de un pedido de Pendiente a Entregado

        public void QuitarPedido(Pedido pedido)
        {
            if (listaPedido.Contains(pedido))
            {
                listaPedido.Remove(pedido);
                cantEnvios -= 1;
                CalcularJornal();
                Console.WriteLine("Pedido eliminado");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado");
            }
        }

        public void Mostrar()
        {
            int cont = 1;
            Console.WriteLine($"id: {this.id}");
            Console.WriteLine($"nombre: {this.nombre}");
            Console.WriteLine($"Direccion: {this.direccion}");
            Console.WriteLine("Pedidos.\n");
            foreach (var item in this.listaPedido)
            {
                Console.Write($"{cont}. ");
                item.VerDatosCliente();
                cont += 1;
            }
        }
    }
}
