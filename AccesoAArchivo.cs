using AccesoADatosClass;
using CadeteClass;
using CadeteriaClass;
using PedidosClass;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace AccesoAArchivoClass
{
    public class ArchivosAArchivo
    {
        public static List<string[]> LeerArchivocsv(string nombreArchivo)
        {
            var Lectura = new List<string[]>();
            if (File.Exists(nombreArchivo))
            {
                var archivo = new FileStream(nombreArchivo, FileMode.Open);
                var strReader = new StreamReader(archivo);
                var linea = "";
                while ((linea = strReader.ReadLine()) != null)
                {
                    string[] arregloLinea = linea.Split(';');
                    Lectura.Add(arregloLinea);
                }
                strReader.Close();
            }
            else
            {
                Console.WriteLine("Archivo no encontrado: {0}", nombreArchivo);
                return null;
            }
            return Lectura;
        }

        public List<Cadeteria> CargarDatosCadeterias(string nombreArchivo, List<Cadete> listadoCadete)
        {
            var ListaCadeterias = new List<Cadeteria>();
            var datos = LeerArchivocsv(nombreArchivo);
            if (datos != null && datos.Any())
            {
                foreach (var cadeteriaInfo in datos)
                {
                    if (cadeteriaInfo == null || cadeteriaInfo.Length < 2)
                        continue;

                    // Obtener los datos del CSV
                    string nombreCadeteria = cadeteriaInfo[0];
                    string telefonoCadeteria = cadeteriaInfo[1];

                    // Crear una instancia de Cadeteria y agregarla a la lista
                    var nuevacadeteria = new Cadeteria(nombreCadeteria, telefonoCadeteria, listadoCadete, new List<Pedido>());
                    ListaCadeterias.Add(nuevacadeteria);
                }
            }
            return ListaCadeterias;
        }

        public List<Cadete> CargarDatosCadetes(string nombreArchivo)
        {
            Cadete nuevoCadete;
            var nuevaLista = new List<Cadete>();
            var listaCsv = LeerArchivocsv(nombreArchivo);

            if (listaCsv != null && listaCsv.Any())
            {
                int id = 0;
                foreach (var cadeteInfo in listaCsv)
                {
                    if (cadeteInfo == null || cadeteInfo.Length < 3)
                        continue;

                    // Obtener los datos del CSV
                    string nombre = cadeteInfo[0];
                    string telefono = cadeteInfo[1];
                    string direccion = cadeteInfo[2];

                    // Crear una instancia de Cadete y agregarla a la lista
                    nuevoCadete = new Cadete(nombre, direccion, telefono);
                    nuevaLista.Add(nuevoCadete);
                    id++;
                }
            }
            else
            {
                Console.WriteLine("\n(no se encontraron cadetes para cargar)");
            }
            return nuevaLista;
        }

        public void GuardarDatosCadetes(string nombreArchivo, List<Cadete> cadetes)
        {
            // Convierte la lista de cadetes a un formato adecuado para guardar en el archivo
            List<string[]> datosCadetes = new List<string[]>();
            foreach (var cadete in cadetes)
            {
                string[] lineaCadete = { cadete.NombreCadete, cadete.TelefonoCadete, cadete.DireccionCadete };
                datosCadetes.Add(lineaCadete);
            }

            // Llama al método GuardarDatos para guardar los datos de los cadetes en el archivo
            GuardarDatos(nombreArchivo, datosCadetes);
        }

        public void GuardarDatosCadeterias(string nombreArchivo, List<Cadeteria> cadeterias)
        {
            // Convierte la lista de cadeterías a un formato adecuado para guardar en el archivo
            List<string[]> datosCadeterias = new List<string[]>();
            foreach (var cadeteria in cadeterias)
            {
                string[] lineaCadeteria = { cadeteria.NombreCadeteria, cadeteria.TelefonoCadeteria };
                datosCadeterias.Add(lineaCadeteria);
            }

            // Llama al método GuardarDatos para guardar los datos de las cadeterías en el archivo
            GuardarDatos(nombreArchivo, datosCadeterias);
        }
        public void GuardarDatos(string ruta, List<string[]> datos)
        {
            try
            {
                using (var writer = new StreamWriter(ruta))
                {
                    foreach (var fila in datos)
                    {
                        var linea = string.Join(",", fila);
                        writer.WriteLine(linea);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en archivo CSV: {ex.Message}");
            }
        }
    }
}
