namespace CadeteriaClass
{
    using CadeteClass;
    using PedidosClass;

    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private int totalEnvios;
        private float totalGanado;
        private double cantPromedioEnvios;
        public List<Pedido> ListadoPedidos { get; set; } = new List<Pedido>();

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
        public float TotalGanado { get => totalGanado; set => totalGanado = value; }
        public double CantPromedioEnvios { get => cantPromedioEnvios; set => cantPromedioEnvios = value; }

        // private List<Pedido> listadoPedidos;//agrego
        public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes, int totalEnvios, float totalGanado, double cantPromedioEnvios)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.listadoCadetes = listadoCadetes;
            this.totalEnvios = 0;
            this.totalGanado = 0.0f;
            this.cantPromedioEnvios = 0.0f;
        }

        public void Mostrar()
        {
            int cont = 1;
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Telefono: {this.telefono}");
            foreach (var item in listadoCadetes)
            {
                Console.WriteLine($"Clietn {cont}");
                item.Mostrar();
                cont += 1;
            }
        }

        public void Total()
        {
            if (listadoCadetes != null && listadoCadetes.Any())
            {
                this.TotalEnvios = listadoCadetes.Sum(l => l.CantEnvios);
                this.TotalGanado = listadoCadetes.Sum(l => l.CantGanado);
                this.CantPromedioEnvios = this.totalEnvios / listadoCadetes.Count;
            }
            else
            {
                Console.WriteLine("esta vacio la lista");
            }
        }

        public void Informe()
        {
            Total();
            Console.WriteLine("MOSTRAR INFORME");
            Console.WriteLine("Datos Cadetes");
            foreach (var item in listadoCadetes)
            {
                Console.WriteLine($"{item.Nombre}: {item.CantEnvios} {item.CantGanado}");
            }
            Console.WriteLine("Datos de Cadeteria");
            Console.WriteLine($"Total Ganado: {this.TotalGanado}");
            Console.WriteLine($"Total Envios: {this.TotalEnvios}");
            Console.WriteLine($"Promedio de Envios: {this.CantPromedioEnvios}");
            Console.WriteLine("Listado de Pedidos:");
            foreach (var pedido in this.ListadoPedidos)
            {
                Console.WriteLine($"Pedido Nombre: {pedido.Nombre}, Estado: {pedido.Estado}");
            }
        }
    }
}
