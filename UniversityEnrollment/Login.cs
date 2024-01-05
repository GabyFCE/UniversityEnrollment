using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityEnrollment
{
    public static class Login
    {

        public static void Ingresar()
        {
            List<UsuarioEnt> usuarios = new List<UsuarioEnt>();
            UsuarioEnt user1 = new UsuarioEnt();
            user1.Username = "User1";
            user1.Password = "User1";
            usuarios.Add(user1);
            int prueba = 0;
            while (prueba < 3)
            {
                Console.WriteLine("(Ingresar con User1/User1");
                Console.WriteLine("Ingrese su username");
                string username = Console.ReadLine();
                Console.WriteLine("Ingrese su password");
                string password = Console.ReadLine();

                if (usuarios.Any(x => x.Username == "User1" && x.Password == "User1"))
                {
                    Console.Clear();
                    Console.WriteLine("Login Exitoso");
                    Menu.Mostrar();
                    return;
                }
                else
                {
                    prueba++;
                }
            }
        }
    }
}
