using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEnrollment
{
    internal static class AsignacionArchivo
    {
        //Vamos a grabar archivos de texto con una notación llamada
        //JSON utilizando una herramienta llamada Newtonsoft.Json
        //se dice "yaison"
        //se escribe JSON

        //ejemplo. Una persona:
        /*
        {
             "Apellido": "Perez",
             "Nombre": "Juan",
             "Telefonos": [ 
                { 
                    "Tipo": "Casa",
                    "Numero": 1131798888
                },
                {
                    "Tipo": "Trabajo",
                    "Numero": 1131798887
                }
             ]
        }
        */


        //internamente, maneja una coleccion de asignaciones.
        static List<CampusEnt> asignaciones;

        //Constructor estático:
        // - NO tiene modificador de acceso (public, private, etc.)
        // - NO puede tener parámetros.
        // - Se ejecuta UNA sola vez, justo antes del primer uso de
        //   una propiedad o método del módulo.
        static AsignacionArchivo()
        {
            //si existe el archivo...
            if (File.Exists("asignaciones.json"))
            {
                //lee TODO el contenido del archivo.
                string contenidoDelArchivo = File.ReadAllText("asignaciones.json");

                //esta linea convierte el texto
                //de vuelta a objetos de tipo PersonaEnt;

                asignaciones = JsonConvert.DeserializeObject<List<CampusEnt>>(contenidoDelArchivo);
            }
            else
            {
                asignaciones = new List<CampusEnt>();
            }
        }

        //Estilo 1: este modulo devuelve una lista de todas las asignaciones
        //y el resto del sistema trabaja con eso.
        public static List<CampusEnt> ObtenerAsignaciones()
        {
            return asignaciones.ToList();
        }

        public static bool ChequearLugar(int id, string lugar)
        {
            bool flag = false;
            int countComputacionLondres = 0;
            int countMedicinaLondres = 0;
            int countMarketingLondres = 0;
            int countArtesLondres = 0;
            int countComputacionLiverpool = 0;
            int countMedicinaLiverpool = 0;
            int countMarketingLiverpool = 0;
            int countArtesLiverpool = 0;
            int countComputacionManchester = 0;
            int countMedicinaManchester = 0;
            int countMarketingManchester = 0;
            int countArtesManchester = 0;
            foreach (var asignacion in asignaciones)
            {

                countComputacionLondres = asignaciones.Count(item => item.Computacion == true && item.Lugar == "Londres");
                countMedicinaLondres = asignaciones.Count(item => item.Medicina == true && item.Lugar == "Londres");
                countMarketingLondres = asignaciones.Count(item => item.Marketing == true && item.Lugar == "Londres");
                countArtesLondres = asignaciones.Count(item => item.Artes == true && item.Lugar == "Londres");
                countComputacionLiverpool = asignaciones.Count(item => item.Computacion == true && item.Lugar == "Liverpool");
                countMedicinaLiverpool = asignaciones.Count(item => item.Medicina == true && item.Lugar == "Liverpool");
                countMarketingLiverpool = asignaciones.Count(item => item.Marketing == true && item.Lugar == "Liverpool");
                countArtesLiverpool = asignaciones.Count(item => item.Artes == true && item.Lugar == "Liverpool");
                countComputacionManchester = asignaciones.Count(item => item.Computacion == true && item.Lugar == "Manchester");
                countMedicinaManchester = asignaciones.Count(item => item.Medicina == true && item.Lugar == "Manchester");
                countMarketingManchester = asignaciones.Count(item => item.Marketing == true && item.Lugar == "Manchester");
                countArtesManchester = asignaciones.Count(item => item.Artes == true && item.Lugar == "Manchester");
            }

            if (id == 1 && lugar == "Londres" && countComputacionLondres  < 1)
            {
                flag = true;
            }
            else if (id == 2 && lugar == "Londres" && countMedicinaLondres < 1)
            {
                flag = true;
            }
            if (id == 3 && lugar == "Londres" && countComputacionLondres < 1)
            {
                flag = true;
            }
            else if (id == 4 && lugar == "Londres" && countMedicinaLondres < 1)
            {
                flag = true;
            }
            if (id == 1 && lugar == "Liverpool" && countComputacionLiverpool < 1)
            {
                flag = true;
            }
            else if (id == 2 && lugar == "liverpool" && countMedicinaLiverpool < 1)
            {
                flag = true;
            }
            else if (id == 3 && lugar == "liverpool" && countMarketingLiverpool < 1)
            {
                flag = true;
            }
            else if (id == 4 && lugar == "liverpool" && countArtesLiverpool < 1)
            {
                flag = true;
            }
            else if (id == 1 && lugar == "Manchester" && countComputacionManchester < 3)
            {
                flag = true;
            }
            else if (id == 2 && lugar == "Manchester" && countComputacionManchester < 3)
            {
                flag = true;
            }
            else if (id == 3 && lugar == "Manchester" && countComputacionManchester < 3)
            {
                flag = true;
            }
            else if (id == 4 && lugar == "Manchester" && countComputacionManchester < 3)
            {
                flag = true;
            }

            return flag;
        }

        public static void AgregarAsignacion(CampusEnt asignacion)
        {
            asignaciones.Add(asignacion);
        }

        public static void AgregarListaAsignaciones(List<CampusEnt> asignaciones)
        {
            asignaciones.Concat(asignaciones);
        }

        //Estilo 2: todas las consultas van a este modulo.
        //En este caso, hay que tener en cuenta que talvez
        //muchos modulos del sistema van a compartir el uso de éste.

        /*
        public static List<PersonaEnt> LasQueEmpiezanCon(char primeraLetra)
        {
            var resultado = new List<PersonaEnt>();
            foreach (var persona in todas)
            {
                if (persona.Apellido.StartsWith(primeraLetra))
                {
                    resultado.Add(persona);
                }
            }
            return resultado;
        }
        */
        /*
        public static List<PersonaEnt> MayoresA(int edad)
        {
            var resultado = new List<PersonaEnt>();
            foreach (var persona in todas)
            {
                if (persona.Edad > edad)
                {
                    resultado.Add(persona);
                }
            }
            return resultado;
        }
        
        public static void Borrar(string apellido)
        {
            foreach (var persona in todas)
            {
                if (persona.Apellido == apellido)
                {
                    todas.Remove(persona);
                    return;
                }
            }
            //hay un problema, porque no la encontré.
            //Tirar un error, para que se note.
            throw new ApplicationException($"La persona {apellido} no existe.");
        }
        public static void Borrar(PersonaEnt ent)
        {
            todas.Remove(ent);
        }
        */
        public static void Grabar()
        {
            var contenido = JsonConvert.SerializeObject(asignaciones);
            File.WriteAllText("asignaciones.json", contenido);
        }
    }
}
