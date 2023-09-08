using ClienteClass; // Asegúrate de incluir los namespaces adecuados
using PedidosClass;
using CadeteClass;
using ArchivoClass;
using CadeteriaClass;

internal partial class Program
{
    private static void Main(string[] args)
    {
        var listaCadeterias = new List<Cadeteria>();
        var listaCadetes = new List<Cadete>();
        listaCadetes = CargarCadetes("Cadetes.csv");
        listaCadeterias = CargarCadeterias("Cadeteria.csv", listaCadetes);

        Console.WriteLine("Ingrese el nombre de la cadeteria con la que desea trabajar");
        var nombreCadeteria = Console.ReadLine();
        Cadeteria? cadeteriaSeleccionada = listaCadeterias.FirstOrDefault(l => l.Nombre == nombreCadeteria);
        if (cadeteriaSeleccionada != null)
        {
            var ingresar = "";
            var nroDePedido = 0;
            Pedido pedidotomado = new Pedido();
            var cadeteAsignado = new Cadete();
            cadeteriaSeleccionada.Mostrar();

            while (ingresar != "e")
            {
                Console.WriteLine("Seleccione una opcion:");
                Console.WriteLine("a) Dar de alta el pedido");
                Console.WriteLine("b) Asignarlo a un cadete");
                Console.WriteLine("c) Cambiarlo de estado");
                Console.WriteLine("d) Reasignar el pedido a otro cadete");
                Console.WriteLine("e) Salir");
                ingresar = Console.ReadLine();
                switch (ingresar)
                {
                    case "a":
                        pedidotomado = DarDeAlta(nroDePedido);
                        nroDePedido += 1;
                        pedidotomado.VerDatosCliente();
                        cadeteriaSeleccionada.ListadoPedidos.Add(pedidotomado);
                        break;
                    case "b":
                        if (pedidotomado != null)
                        {
                            cadeteAsignado = AsignarCadete(listaCadetes, pedidotomado);
                        }
                        break;
                    case "c":
                        if (pedidotomado != null)
                        {
                            CambiarEstadoPedido(pedidotomado, cadeteriaSeleccionada);
                        }
                        break;
                    case "d":
                        cadeteAsignado.QuitarPedido(pedidotomado);
                        var CambiarCadete = AsignarCadete(listaCadetes, pedidotomado);
                        break;
                }
            }
            cadeteriaSeleccionada.Informe();
        }
        else
        {
            Console.WriteLine("No se encontró la cadeteria");
        }


    }
    private static void CambiarEstadoPedido(Pedido pedido, Cadeteria cadeteriaSeleccionada)
    {
        Console.WriteLine("Seleccione el estado en que desea colocar el pedido");
        Console.WriteLine("1. Rechazado");
        Console.WriteLine("2. Pendiente");
        var ingresarEstado = Console.ReadLine();
        if (ingresarEstado == "1")
        {
            pedido.CambiarDeEstado(EstadoPedido.Rechazado);
            // Remover el pedido de la lista de pedidos de la cadeteria seleccionada
            cadeteriaSeleccionada.ListadoPedidos.Remove(pedido);
        }
        else
        {
            pedido.CambiarDeEstado(EstadoPedido.Pendiente);
        }
    }
    private static Cadete AsignarCadete(List<Cadete> listaCadetes, Pedido pedidotomado)
    {
        Console.WriteLine("Elige el cadete que desea asignar");
        int cont = 0;
        int opcion = 0;
        foreach (var item in listaCadetes)
        {
            Console.WriteLine(cont + $" {item.Nombre}");
            cont += 1;
        }
        var cadeteAsignar = Console.ReadLine();
        if (int.TryParse(cadeteAsignar, out opcion))
        {
            var cadeteselecionado = listaCadetes[opcion];
            cadeteselecionado.AsignarPedido(pedidotomado);
            pedidotomado.AceptarPedido();
            cadeteselecionado.Mostrar();
            return cadeteselecionado;
        }
        else
        {
            Console.WriteLine("No existe dicho Cadete");
            return null;
        }
    }

    public static List<Cadeteria> CargarCadeterias(string ruta, List<Cadete> listaCad)
    {
        var ListaCadeterias = new List<Cadeteria>();
        var Archivos = new Archivos();
        var datos = Archivos.Leer(ruta);
        if (datos != null && datos.Any())
        {
            foreach (var Cadeteria in datos)
            {
                if (Cadeteria == null)
                {
                    break;
                }
                var nuevacadeteria = new Cadeteria(Cadeteria[0], Cadeteria[1], listaCad, 0, 0.0f, 0.0);
                ListaCadeterias.Add(nuevacadeteria);
            }
        }
        return ListaCadeterias;
    }

    public static List<Cadete> CargarCadetes(string ruta)
    {
        var Archivos = new Archivos();
        Cadete nuevoCadete;
        var nuevaLista = new List<Cadete>();
        var listaCsv = Archivos.Leer(ruta);

        if (listaCsv != null && listaCsv.Any())
        {
            int id = 0;
            foreach (var cadete in listaCsv)
            {
                if (cadete == null)
                    break;
                nuevoCadete = new Cadete(id, cadete[0], cadete[1], cadete[2], null, 0, 0.0f);
                nuevaLista.Add(nuevoCadete);
                id += 1;
            }
        }
        else
        {
            Console.WriteLine("\n(no se encontraron cadetes para cargar)");
        }
        return nuevaLista;
    }

    public static Pedido DarDeAlta(int nroDePedido)
    {
        Console.WriteLine("Ingrese el nombre del cliente");
        var nombreCliente = Console.ReadLine();
        Console.WriteLine("Ingrese la direccion donde vive");
        var direccionCliente = Console.ReadLine();
        Console.WriteLine("Ingrese el telefono del cliente");
        var telefonoCliente = Console.ReadLine();
        Console.WriteLine("Ingrese los datos de Referencia");
        var datosReferencia = Console.ReadLine();
        var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
        Console.WriteLine("Ingrese las observaciones que tenga del pedido");
        var observaciones = Console.ReadLine();
        var PedidoTomado = new Pedido(nroDePedido, observaciones, datosCliente, null, EstadoPedido.Pendiente);
        return PedidoTomado;
    }
}