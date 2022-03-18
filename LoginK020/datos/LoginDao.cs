using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginK020.datos
{
    internal class LoginDao
    {//mock up
        private const string NOMBRE_ARCHIVO = "c:\\escritorio\\usuarios.txt";

     
        public Usuario ReadFile(string username, string password)
        {
            
            Usuario user = null;
            try     
            {
                StreamReader sr = new StreamReader(NOMBRE_ARCHIVO);
                string line = sr.ReadLine();
                int contador = 1;
                user = new Usuario();
                while (line != null)
                {
                    if(contador == 1)
                    {
                        user.Username = line;
                    }
                    if(contador == 2)
                    {
                        user.Password = line; 
                    }
                    line = sr.ReadLine();
                    contador++;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return user;
        }

        internal Usuario ReadFile()
        {
            throw new NotImplementedException();
        }
    }
}
