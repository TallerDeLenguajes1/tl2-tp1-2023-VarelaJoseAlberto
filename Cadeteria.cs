using ClienteClass;
using CadeteClass;
using PedidosClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadeteriaClass
{
    public class Cadeteria
    {
        private string nombreCadeteria;
        private string telefonoCadeteria;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;

        public string NombreCadeteria { get => nombreCadeteria; set => nombreCadeteria = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
        public string TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value; }

        public Cadeteria(string nombreCadeteria, string telefonoCadeteria, List<Cadete> listadoCadetes, List<Pedido> listadoPedidos)
        {
            this.nombreCadeteria = nombreCadeteria;
            this.telefonoCadeteria = telefonoCadeteria;
            this.listadoCadetes = listadoCadetes;
            this.listadoPedidos = listadoPedidos;
        }

        public Cadeteria()
        {
            nombreCadeteria = "";
            telefonoCadeteria = "";
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedido>();
        }

        public void MostrarCadeteria()
        {
            Console.WriteLine(" --------------------------- \n");
            Console.WriteLine($"Nombre de la Cadeteria: {nombreCadeteria}");
            Console.WriteLine($"Telefono de la Cadeteria: {telefonoCadeteria}");
            Console.WriteLine("\nDatos de Cadetes:");
            foreach (var cadete in listadoCadetes)
            {
                cadete.MostrarCadete();
            }
            Console.WriteLine(" --------------------------- \n");
        }

        public Pedido CrearPedido(int idPedido)
        {
            Console.WriteLine("\n -------------- Pedido -------------- \n");
            Console.WriteLine("Ingrese el nombre del cliente");
            var nombreCliente = Console.ReadLine();
            Console.WriteLine("Ingrese la dirección del cliente");
            var direccionCliente = Console.ReadLine();
            Console.WriteLine("Ingrese el teléfono del cliente");
            var telefonoCliente = Console.ReadLine();
            Console.WriteLine("Ingrese los datos de Referencia");
            var datosReferencia = Console.ReadLine();
            var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
            Console.WriteLine("Ingrese las observaciones que tenga del pedido");
            var observaciones = Console.ReadLine();
            var PedidoTomado = new Pedido(idPedido, observaciones, datosCliente);
            Console.WriteLine("\n --------------------------- \n");
            return PedidoTomado;
        }

        public void TomarPedido(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
        }

        public void AceptarPedido(int idPedido)
        {
            var pedido = listadoPedidos.FirstOrDefault(l => l.IdPedido == idPedido);
            if (pedido != null)
            {
                pedido.AceptarPedido();
            }
        }

        public void MostrarPedidosPendientes()
        {
            Console.WriteLine("Pedidos Pendientes:");
            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Estado == EstadoPedido.Pendiente)
                {
                    Console.WriteLine($"ID Pedido: {pedido.IdPedido}");
                    Console.WriteLine($"Cliente: {pedido.NombreCliente.NombreCliente}");
                    Console.WriteLine($"Dirección: {pedido.NombreCliente.DireccionCliente}");
                    Console.WriteLine($"Teléfono: {pedido.NombreCliente.TelefonoCliente}");
                    Console.WriteLine($"Observaciones: {pedido.NombreCliente.DatosReferenciaDireccionCliente}");
                    Console.WriteLine(" --------------------------- ");
                }
            }
        }


        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            var cadete = listadoCadetes.FirstOrDefault(l => l.IdCadete == idCadete);
            var pedido = listadoPedidos.FirstOrDefault(l => l.IdPedido == idPedido);
            if (cadete != null && pedido != null)
            {
                pedido.AsignarCadete(cadete);
            }
            else
            {
                Console.WriteLine("No se encuentra el cliente");
            }
        }

        public void CambiarEstadoPedido(Cadeteria cadeteria)
        {
            Console.WriteLine("Seleccione el pedido al que desea cambiar el estado:");
            for (int i = 0; i < cadeteria.ListadoPedidos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Pedido ID: {cadeteria.ListadoPedidos[i].IdPedido}");
            }

            if (int.TryParse(Console.ReadLine(), out int pedidoSeleccionado) && pedidoSeleccionado >= 1 && pedidoSeleccionado <= cadeteria.ListadoPedidos.Count)
            {
                var pedido = cadeteria.ListadoPedidos[pedidoSeleccionado - 1];
                Console.WriteLine("Seleccione el estado en que desea colocar el pedido:");
                Console.WriteLine("1. Pendiente");
                Console.WriteLine("2. Rechazado");
                Console.WriteLine("3. Entregado");

                if (int.TryParse(Console.ReadLine(), out int estadoSeleccionado) && estadoSeleccionado >= 1 && estadoSeleccionado <= 3)
                {
                    switch (estadoSeleccionado)
                    {
                        case 1:
                            pedido.Estado = EstadoPedido.Pendiente;
                            Console.WriteLine("El estado del pedido ha sido cambiado a Pendiente.");
                            break;
                        case 2:
                            pedido.Estado = EstadoPedido.Rechazado;
                            Console.WriteLine("El estado del pedido ha sido cambiado a Rechazado.");
                            break;
                        case 3:
                            pedido.Estado = EstadoPedido.Entregado;
                            Console.WriteLine("El estado del pedido ha sido cambiado a Entregado.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Selección de estado inválida.");
                }
            }
            else
            {
                Console.WriteLine("Selección de pedido inválida.");
            }
        }

        public void ConsultarJornal(Cadeteria cadeteria)
        {
            Console.WriteLine("Seleccione el cadete para consultar el jornal:");
            for (int i = 0; i < cadeteria.ListadoCadetes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Cadete: {cadeteria.ListadoCadetes[i].NombreCadete}");
            }

            if (int.TryParse(Console.ReadLine(), out int cadeteSeleccionado) && cadeteSeleccionado >= 1 && cadeteSeleccionado <= cadeteria.ListadoCadetes.Count)
            {
                var cadete = cadeteria.ListadoCadetes[cadeteSeleccionado - 1];
                double jornal = cadeteria.JornalACobrar(cadete.IdCadete);
                Console.WriteLine($"El jornal a cobrar para el cadete '{cadete.NombreCadete}' seleccionado es: ${jornal}");
            }
            else
            {
                Console.WriteLine("Selección de cadete inválida.");
            }
        }

        public void CalcularJornal()
        {
            foreach (var cadete in listadoCadetes)
            {
                int cantidadPedidosEntregados = 0;
                double montoGanado = 0.0;

                foreach (var pedido in listadoPedidos)
                {
                    if (pedido.CadeteAsignado == cadete && pedido.Estado == EstadoPedido.Entregado)
                    {
                        cantidadPedidosEntregados++;
                        montoGanado += 500.0;
                    }
                }

                // Actualiza la información del cadete con los valores calculados
                cadete.CantidadPedidosEntregados = cantidadPedidosEntregados;
                cadete.MontoGanado = montoGanado;
            }
        }

        public double JornalACobrar(int idCadete)
        {
            var cadete = listadoCadetes.FirstOrDefault(l => l.IdCadete == idCadete);
            if (cadete != null)
            {
                int cantidadPedidosEntregados = listadoPedidos.Count(p => p.CadeteAsignado == cadete && p.Estado == EstadoPedido.Entregado);
                double tarifaPorPedido = 500.0;
                double jornal = cantidadPedidosEntregados * tarifaPorPedido;
                return jornal;
            }
            else
            {
                Console.WriteLine("Cadete no encontrado");
                return 0.0;
            }
        }

        public void InformeAlFinalDelJornal()
        {
            Console.WriteLine("\n ----------- Informe ---------------- \n");
            foreach (var cadete in listadoCadetes)
            {
                int cantidadPedidosEntregados = listadoPedidos.Count(p => p.CadeteAsignado == cadete && p.Estado == EstadoPedido.Entregado);
                double montoGanado = cantidadPedidosEntregados * 500.0;

                Console.WriteLine("Datos de Cadetes");
                Console.WriteLine($"Cadete: {cadete.NombreCadete}");
                Console.WriteLine($"Cantidad de pedidos entregados: {cantidadPedidosEntregados}");
                Console.WriteLine($"Monto Ganado: {montoGanado}");
                Console.WriteLine(" --------------------------- ");
            }
            int totalEnvios = listadoPedidos.Count(p => p.Estado == EstadoPedido.Entregado);
            double promedioEnvios = totalEnvios / listadoCadetes.Count;
            Console.WriteLine($"Cantidad de envíos promedio por cadete: {promedioEnvios}");
            Console.WriteLine("\n --------------------------- \n");
        }

        public Pedido ObtenerPedidoParaEliminar()
        {
            Console.WriteLine("Seleccione el pedido que desea eliminar:");
            for (int i = 0; i < listadoPedidos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Pedido ID: {listadoPedidos[i].IdPedido}");
            }

            if (int.TryParse(Console.ReadLine(), out int pedidoSeleccionado) && pedidoSeleccionado >= 1 && pedidoSeleccionado <= listadoPedidos.Count)
            {
                return listadoPedidos[pedidoSeleccionado - 1];
            }
            else
            {
                Console.WriteLine("Selección de pedido inválida.");
                return null;
            }
        }

        public void QuitarPedido(Pedido pedido)
        {
            if (listadoPedidos.Contains(pedido))
            {
                listadoPedidos.Remove(pedido);
                pedido.Estado = EstadoPedido.Rechazado;
                Console.WriteLine("Pedido eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Pedido no encontrado en la lista.");
            }
        }
    }
}
