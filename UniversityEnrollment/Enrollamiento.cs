using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEnrollment
{
    internal static class Enrollamiento
    {
        
       public static bool enrolar( string nombre, string apellido, int materia, string lugar)
        {
 
                CampusEnt asignacion = new CampusEnt();
                asignacion.Lugar = lugar;
                asignacion.Nombre = nombre;
                asignacion.Apellido = apellido;
                switch (materia)
                {
                    case 1:
                        asignacion.Computacion = true;
                        break;
                    case 2:
                        asignacion.Medicina = true;
                        break;
                    case 3:
                        asignacion.Marketing = true;
                        break;
                    case 4:
                        asignacion.Artes = true;
                        break;
                }

            bool check =AsignacionArchivo.ChequearLugar(materia, lugar);
            if (check) 
            {
                AsignacionArchivo.AgregarAsignacion(asignacion);
                return true;
            }
            else
            {
                return false; 
            }

        }
    }
}
