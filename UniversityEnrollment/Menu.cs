using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEnrollment
{
    internal static class Menu
    {
        public static void Mostrar()
        {

            while (true) {


                string nombre;
                string apellido;
                string campus;

                Console.WriteLine("Elije un programa");
                Console.WriteLine("1-Ciencias de la computacion");
                Console.WriteLine("2-Medicina");
                Console.WriteLine("3-Marketing");
                Console.WriteLine("4-Artes");

                string ingreso = Console.ReadLine();
            
                var valido = int.TryParse(ingreso, out int id);
                if(!valido)
                {
                    Console.WriteLine("Ingrese un numero entero de 1 a 4");
                }
                else if (id < 1 || id > 4)
                {
                    Console.WriteLine("Ingrese un número entre 1 y 4");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese su nomnbre");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese su apellido");
                    apellido = Console.ReadLine();
                    Console.WriteLine("Elija el campus: Londrés, Manchester, Liverpool");
                    campus = Console.ReadLine();
                    bool chk = Enrollamiento.enrolar(nombre, apellido, id, campus);
                    if (chk)
                    {
                        Console.WriteLine("Asignacion correcta");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Sin lugares disponibles. Desea intentar de nuevo? y/n");
                        string resp = Console.ReadLine();
                        if (resp == "y")
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
        }
    }
}
