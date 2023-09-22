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

        public string ObtenerInformacionPedido()
        {
            string informacion = "";
            informacion += "\n --------------------------- \n";
            informacion += $"Numero de id del Pedido: {IdPedido}\n";
            informacion += $"Nombre del Pedido: {nombrePedido}\n";
            informacion += $"Estado del Pedido: {estado}\n";
            informacion += "Datos del Cliente\n";
            informacion += NombreCliente.ObtenerInformacionCliente() + "\n";
            if (cadeteAsignado == null)
            {
                informacion += "No hay asignado cadete\n";
            }
            else
            {
                informacion += $"Cadete Asignado: {cadeteAsignado.NombreCadete}\n";
            }
            informacion += "\n --------------------------- \n";
            return informacion;
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
                    // Eliminamos la llamada a Console.WriteLine
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
