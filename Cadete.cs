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
            if (pedido != null)
            {
                if (listaPedido == null)
                {
                    listaPedido = new List<Pedido>();
                }
                listaPedido.Add(pedido);
                cantEnvios += 1;
                cantGanado = (float)CalcularJornal();
            }
            else
            {
                Console.WriteLine("El pedido proporcionado es nulo.");
            }
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

        // public void Mostrar()
        // {
        //     int cont = 1;
        //     Console.WriteLine($"Nombre: {this.nombre}");
        //     Console.WriteLine($"Telefono: {this.telefono}");
        //     foreach (var item in listadoCadetes)
        //     {
        //         Console.WriteLine($"Cadete {cont}");
        //         if (item != null) // Verifica si el cadete no es null antes de mostrarlo
        //         {
        //             item.Mostrar();
        //         }
        //         cont += 1;
        //     }
        // }

        public void Mostrar()
        {
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Telefono: {this.telefono}");
            Console.WriteLine($"Dirección: {this.direccion}");
            Console.WriteLine($"Cantidad de Envíos: {this.cantEnvios}");
            Console.WriteLine($"Ganancias: {this.cantGanado}");
        }

    }
}
