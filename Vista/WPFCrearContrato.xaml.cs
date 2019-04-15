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
            cboTipo.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cboTipo.SelectedIndex = 0;

            dao = new DaoContrato();
        }


        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String numero = DateTime.Now.ToString("yyyyMMddHHmm");
                String fechaCreacion = dpCreacion.Text;
                String vigente;
                String fechaTermino;
                if (rbSi.IsChecked == true)
                {
                    vigente = "Sí";
                    fechaTermino = DateTime.Now.ToString("DD/MM/YYYY");
                }
                else
                {
                    vigente = "No";
                    fechaTermino = "Aún vigente";

                }

                //EVENTO

                //inicio
                String fechaInicioEvento = dpFechaInicio.Text;
                int horaInicio = int.Parse(txtHoraInicio.Text);
                int minutoInicio = int.Parse(txtMinutoInicio.Text);
                //termino
                String fechaTerminoEvento = dpFechaTerminoEvento.Text;
                int horaTermino = int.Parse(txtHoraTermino.Text);
                int minutoTermino = int.Parse(txtMinutoTermino.Text);
                String direccion = txtDireccion.Text;
                int numeroAsistentes = int.Parse(txtNumeroAsistentes.Text);
                TipoEvento evento = (TipoEvento)cboTipo.SelectedItem;


                String observaciones = txtObservaciones.Text;

                Contrato con = new Contrato()
                {

                    Numero = numero,
                    FechaCreacion = fechaCreacion,
                    Vigente = vigente,
                    FechaTermino = fechaTermino,
                    FechaInicioEvento = fechaInicioEvento,
                    HoraInicio = horaInicio,
                    MinutoInicio = minutoInicio,
                    FechaTerminoEvento = fechaTerminoEvento,
                    HoraTermino = horaTermino,
                    MinutoTermino = minutoTermino,
                    Direccion = direccion,
                    NumeroAsistentes = numeroAsistentes,
                    Evento = evento,
                    Observaciones = observaciones

                };

                //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                bool resp = dao.Agregar(con);
                MessageBox.Show(resp ? "Guardado" : "No Guardado");


            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Todos los campos son obligatorios");
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
