using System;

namespace CadeteClass
{
    public class Cadete
    {
        private int idCadete;
        private string nombreCadete;
        private string direccionCadete;
        private string telefonoCadete;
        private int cantidadPedidosEntregados;
        private double montoGanado;

        public int IdCadete { get => idCadete; set => idCadete = value; }
        public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }
        public string DireccionCadete { get => direccionCadete; set => direccionCadete = value; }
        public string TelefonoCadete { get => telefonoCadete; set => telefonoCadete = value; }
        public int CantidadPedidosEntregados { get => cantidadPedidosEntregados; set => cantidadPedidosEntregados = value; }
        public double MontoGanado { get => montoGanado; set => montoGanado = value; }

        public Cadete(int idCadete, string nombreCadete, string direccionCadete, string telefonoCadete)
        {
            IdCadete = idCadete;
            NombreCadete = nombreCadete;
            TelefonoCadete = telefonoCadete;
            DireccionCadete = direccionCadete;
        }

        public void MostrarCadete()
        {
            Console.WriteLine($"Id del Cadete: {idCadete}");
            Console.WriteLine($"Nombre  del Cadete: {nombreCadete}");
            Console.WriteLine($"Telefono  del Cadete: {telefonoCadete}");
            Console.WriteLine($"Dirección  del Cadete: {direccionCadete}\n");
        }
    }
}
