using ClienteClass;
using CadeteClass;

namespace PedidosClass
{
    public enum EstadoPedido
    {
        Pendiente,
        Aceptado,
        Rechazado,
        Entregado
    }
    public class Pedido
    {
        private int idPedido;
        private string nombrePedido;
        private Cliente nombreCliente;
        private EstadoPedido estado;
        private Cadete cadeteAsignado;


        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string NombrePedido { get => nombrePedido; set => nombrePedido = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }
        public Cadete CadeteAsignado { get => cadeteAsignado; set => cadeteAsignado = value; }

        public Pedido(int idPedido, string nombrePedido, Cliente nombreCliente)
        {
            this.idPedido = idPedido;
            this.nombrePedido = nombrePedido;
            this.nombreCliente = nombreCliente;
            estado = EstadoPedido.Pendiente;
            cadeteAsignado = null;
        }

        public Pedido()
        {
            IdPedido = 0;
            nombrePedido = "";
            nombreCliente = new Cliente();
            estado = EstadoPedido.Pendiente;
            cadeteAsignado = null;
        }

        public void MostrarPedidos()
        {
            Console.WriteLine("\n --------------------------- \n");
            Console.WriteLine($"Numero de id del Pedido: {IdPedido}");
            Console.WriteLine($"Nombre del Pedido: {nombrePedido}");
            Console.WriteLine($"Estado del Pedido: {estado}");
            Console.WriteLine("Datos del Cliente");
            NombreCliente.MostrarCliente();
            if (cadeteAsignado == null)
            {
                Console.WriteLine("No hay asignado cadete");
            }
            else
            {
                Console.WriteLine($"Cadete Asignado: {cadeteAsignado.NombreCadete}");
            }
            Console.WriteLine("\n --------------------------- \n");
        }

        public void AsignarCadete(Cadete cadete)
        {
            cadeteAsignado = cadete;
        }

        public void AceptarPedido()
        {
            if (estado == EstadoPedido.Pendiente)
            {
                estado = EstadoPedido.Aceptado;
                if (estado == EstadoPedido.Rechazado)
                {
                    Console.WriteLine("Pedido Rechazado");
                }
            }
        }

        public void RechazarPedido()
        {
            estado = EstadoPedido.Rechazado;
            cadeteAsignado = null;
        }
    }
}