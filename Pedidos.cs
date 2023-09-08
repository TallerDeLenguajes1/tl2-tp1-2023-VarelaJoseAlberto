namespace PedidosClass
{
    using ClienteClass;
    using CadeteClass;

    public enum EstadoPedido
    {
        Pendiente,
        Aceptado,
        Rechazado,
        Entregado
    }
    public class Pedido
    {
        // public Cadete cadete;//agrego
        private int id;
        private string? nombre;
        private Cliente? nombreCliente;
        private string? observacion;
        private EstadoPedido estado;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public Cliente? NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public EstadoPedido Estado { get => estado; set => estado = value; }


        public Pedido(int id, string? nombre, Cliente? nombreCliente, string? observacion, EstadoPedido estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.nombreCliente = nombreCliente;
            this.observacion = observacion;
            this.estado = EstadoPedido.Pendiente;
        }

        public Pedido()
        {
            this.id = 0;
            this.nombre = "";
            this.nombreCliente = new Cliente();
            this.estado = EstadoPedido.Pendiente;
        }

        public void VerDatosCliente()
        {
            Console.WriteLine($"Numero de id: {this.id}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Observacion: {this.observacion}");
            Console.WriteLine("Datos del Cliente");
            NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");

        }
        public void AceptarPedido()
        {
            estado = EstadoPedido.Aceptado;
        }

        public void RechazarPedido()
        {
            estado = EstadoPedido.Rechazado;
        }
        // Método para cambiar el estado del pedido
        public void CambiarDeEstado(EstadoPedido nuevoEstado)
        {
            Estado = nuevoEstado;
        }

    }
}