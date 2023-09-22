namespace ClienteClass
{
    public class Cliente
    {
        private string nombreCliente;
        private string direccionCliente;
        private string telefonoCliente;
        private string datosReferenciaDireccionCliente;


        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string DireccionCliente { get => direccionCliente; set => direccionCliente = value; }
        public string TelefonoCliente { get => telefonoCliente; set => telefonoCliente = value; }
        public string DatosReferenciaDireccionCliente { get => datosReferenciaDireccionCliente; set => datosReferenciaDireccionCliente = value; }

        public Cliente(string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente)
        {
            this.nombreCliente = nombreCliente;
            this.direccionCliente = direccionCliente;
            this.telefonoCliente = telefonoCliente;
            this.datosReferenciaDireccionCliente = datosReferenciaDireccionCliente;
        }

        public Cliente()
        {
            nombreCliente = "";
            telefonoCliente = "";
            datosReferenciaDireccionCliente = "";
            direccionCliente = "";
        }

        public void MostrarCliente()
        {
            Console.WriteLine($"Nombre del Cliente: {nombreCliente}");
            Console.WriteLine($"Direccion del Cliente: {direccionCliente}");
            Console.WriteLine($"Telefono del Cliente: {telefonoCliente}");
            Console.WriteLine($"Datos Referencia Direccion: {datosReferenciaDireccionCliente}");
        }
    }
}