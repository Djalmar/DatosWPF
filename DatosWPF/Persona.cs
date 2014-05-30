using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DatosWPF
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Persona()
        {
            
        }
        public void Lector(BinaryReader reader)
        {
            Nombre = reader.ReadString();
            Ci = reader.ReadInt32();
        }
        public void Escritor(BinaryWriter writer)
        {
            writer.Write(Nombre);
            writer.Write(Ci);
        }
    }
}
