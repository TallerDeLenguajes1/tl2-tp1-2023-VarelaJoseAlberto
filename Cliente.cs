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
        public string ObtenerInformacionCliente()
        {
            string informacion = "";
            informacion += $"Nombre del Cliente: {nombreCliente}\n";
            informacion += $"Direccion del Cliente: {direccionCliente}\n";
            informacion += $"Telefono del Cliente: {telefonoCliente}\n";
            informacion += $"Datos Referencia Direccion: {datosReferenciaDireccionCliente}\n";
            return informacion;
        }
    }

}