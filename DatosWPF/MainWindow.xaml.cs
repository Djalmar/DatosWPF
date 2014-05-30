using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatosWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += CuandolaVentanaCarga;
        }

        void CuandolaVentanaCarga(object sender, RoutedEventArgs e)
        {
            CargarDatos();
            //evento click del mouse
            btnCargarDatos.Click += btnCargarDatos_Click;
            //evento cuando selecciona un item
            listaEstudiantes.SelectionChanged += listaEstudiantes_SelectionChanged;
        }

        void listaEstudiantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Estudiante estudianteSeleccionado = listaEstudiantes.SelectedItem as Estudiante;
            if (estudianteSeleccionado != null)
            {
                MessageBox.Show(estudianteSeleccionado.Nombre + "  " + estudianteSeleccionado.Carrera);
                estudianteSeleccionado.Nombre +=" asjdsklajdskl";
                listaEstudiantes.Items.Clear();
                CargarDatosLista();
            }
           
        }
        //se ejecuta cuando el usuario le dio click
        void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            CargarDatosLista();
            Archivo = new ArchivoEstudiante();
            Archivo.GuardarEstudiantes();
        }
        //cargar datos a la lista
        private void CargarDatosLista()
        {
            for (int i = 0; i < Datos.CantidadEstudiantes; i++)
            {
                listaEstudiantes.Items.Add(Datos.Estudiantes[i]);
            }
        }

        private void CargarDatos()
        {
            if(Datos.Estudiantes==null)
            {
                Datos.Estudiantes = new Estudiante[1000];
                Archivo = new ArchivoEstudiante();
                Archivo.LeerEstudiantes();
                //Datos.CantidadEstudiantes = 0;
                //for (int i = 0; i < 900; i++)
                //{
                //    Estudiante e = new Estudiante();
                //    e.Carrera = "Informatica";
                //    e.Nombre = "Nombre " + i;
                //    e.Ci = i + 100000;
                //    e.Universidad = "UMSA";
                //    e.FechaNacimiento = DateTime.Now;
                //    Datos.Estudiantes[i] = e;
                //    Datos.CantidadEstudiantes++;
                //}
            }
        }

        public ArchivoEstudiante Archivo { get; set; }
    }
}
