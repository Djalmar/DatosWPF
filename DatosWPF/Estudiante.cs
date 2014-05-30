using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DatosWPF
{
    public class Estudiante : Persona
    {
        public string Carrera { get; set; }
        public string Universidad { get; set; }
        public Estudiante()
        {

        }
        public void Lector(BinaryReader reader)
        {
            base.Lector(reader);
            Carrera = reader.ReadString();
            Universidad = reader.ReadString();
        }
        public void Escritor(BinaryWriter writer)
        {
            base.Escritor(writer);
            writer.Write(Carrera);
            writer.Write(Universidad);
        }
    }
}
