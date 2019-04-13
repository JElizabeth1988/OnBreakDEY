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
using System.Windows.Shapes;

using BibliotecaClase;
using BibliotecaControlador;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Crear_Contrato.xaml
    /// </summary>
    public partial class Crear_Contrato : MetroWindow
    {
        DaoContrato dao;
        public RoutedEventHandler btnBuscarContrato_Click { get; private set; }

        public Crear_Contrato()
        {

            InitializeComponent();
            dao = new DaoContrato();
        }


        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String numero = DateTime.Now.ToString("yyyyMMddHHmm");
                String fechaCreacion = dpCreacion.Text;
                string vigente;
                if (rbSi.IsChecked == true)
                {
                   vigente = "Sí";
                }
                else
                {
                    vigente = "No";
                }
               
                String observaciones = txtObservaciones.Text;

                Contrato con = new Contrato() 
                {
                    
                    Numero = numero,
                    FechaCreacion = fechaCreacion,
                    Vigente = vigente,
                    Observaciones = observaciones
                    
                };

                //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                bool resp = dao.Agregar(con);
                 MessageBox.Show(resp ? "Guardado" : "No Guardado");
                

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error de ingreso de datos");
            }




        }

        private void btnAgregarEvento_Click(object sender, RoutedEventArgs e)
        {
            WpfEvento evento = new WpfEvento();
            evento.Show();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Clear();
            txtBuscarCliente.Clear();
            txtNombre.Clear();
            txtObservaciones.Clear();
            txtNumero.Focus();



        }

        private void btnListadoNum_Click(object sender, RoutedEventArgs e)
        {
            ListarContrato con = new ListarContrato(this);
            con.Show();
            
        }

        private void btnListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente cli = new wpfListadoCliente();
            cli.Show();

        }
    }
}
