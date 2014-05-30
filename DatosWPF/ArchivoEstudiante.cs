using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosWPF
{
    public class ArchivoEstudiante
    {
        public string Path { get; set; }
        public ArchivoEstudiante()
        {
            Path=@"D:\estudiantes.dat";
        }
        public void LeerEstudiantes()
        {
            int i=0;
            Stream file=File.Open(Path,FileMode.OpenOrCreate);
            BinaryReader reader = new BinaryReader(file);
            try
            {
                while (true)
                {
                    Estudiante e = new Estudiante();
                    e.Lector(reader);
                    Datos.Estudiantes[i] = e;
                    i++;
                }
                
            }
            catch (Exception)
            {
                
                    
            }
            finally
            {
                Datos.CantidadEstudiantes = i;
                reader.Close();
                file.Close();
            }
        }
        public void GuardarEstudiantes()
        {
            Stream file=File.Open(Path,FileMode.OpenOrCreate);
            BinaryWriter writer=new BinaryWriter(file);
            for (int i = 0; i < Datos.CantidadEstudiantes; i++)
            {
                Datos.Estudiantes[i].Escritor(writer);
            }
            writer.Close();
            file.Close();
        }
    }
}
