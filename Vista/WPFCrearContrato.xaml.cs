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
                String fechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                String vigente;
                String fechaTermino;
                if (rbSi.IsChecked == true)
                {
                    vigente = "Sí";
                    fechaTermino = "Aún Vigente";
                   
                }
                else
                {
                    vigente = "No";
                    fechaTermino = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); ;



                }

                //EVENTO

                //inicio
                //termino
                String direccion = txtDireccion.Text;
                int numeroAsistentes = int.Parse(txtNumeroAsistentes.Text);
                TipoEvento evento = (TipoEvento)cboTipo.SelectedItem;


                String observaciones = txtObservaciones.Text;
                String rutCliente = txtBuscarCliente.Text;

                Contrato con = new Contrato()
                {

                    Numero = numero,
                    FechaCreacion = fechaCreacion,
                    Vigente = vigente,
                    FechaTermino = fechaTermino,
                    Direccion = direccion,
                    NumeroAsistentes = numeroAsistentes,
                    Evento = evento,
                    Observaciones = observaciones,
                    RutCliente = rutCliente
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

                MessageBox.Show(":(");
            }




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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //BUSCAR CONTRATO---------------------------------------------------------------------


        public void BuscarContrato()
        {
            try
            {
                Contrato c = new DaoContrato().
                    BuscarContrato(txtNumero.Text);
                if (c != null)
                {
                    txtDireccion.Text = c.Direccion;
                    txtNumeroAsistentes.Text = c.NumeroAsistentes.ToString();
                    cboTipo.Text = c.Evento.ToString();
                    txtObservaciones.Text = c.Observaciones;
                }
                else
                {
                    MessageBox.Show("Contrato No encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar");
                //Logger.Mensaje(ex.Message);

            }
        }

       
        //BOTON
        private void btnBuscarContrato_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new DaoContrato().
                    BuscarContrato(txtNumero.Text);
                if (c != null)
                {
                  
                    txtDireccion.Text = c.Direccion;
                    txtNumeroAsistentes.Text = c.NumeroAsistentes.ToString();
                    cboTipo.Text = c.Evento.ToString();
                    txtObservaciones.Text = c.Observaciones;
                }
                else
                {
                    MessageBox.Show("Contrato no Encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar");
                //Logger.Mensaje(ex.Message);

            }

        }

        //BUSCAR CLIENTE
        public void BuscarCliente()
        {
            try
            {
                Cliente c = new DaoCliente().
                    BuscarCliente(txtBuscarCliente.Text);
                if (c != null)
                {
                    txtNombre.Text = c.NombreContacto;
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar");
                //Logger.Mensaje(ex.Message);

            }
        }


        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new DaoCliente().
                    BuscarCliente(txtBuscarCliente.Text);
                if (c != null)
                {
                    txtNombre.Text = c.NombreContacto;
                }
                else
                {
                    MessageBox.Show("Cliente no Encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar");
                //Logger.Mensaje(ex.Message);

            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String numero = DateTime.Now.ToString("yyyyMMddHHmm");
                String fechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                String vigente;
                String fechaTermino;
                if (rbSi.IsChecked == true)
                {
                    vigente = "Sí";
                    fechaTermino = "Aún Vigente";

                }
                else
                {
                    vigente = "No";
                    fechaTermino = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); ;



                }


                String direccion = txtDireccion.Text;
                int numeroAsistentes = int.Parse(txtNumeroAsistentes.Text);
                TipoEvento evento = (TipoEvento)cboTipo.SelectedItem;


                String observaciones = txtObservaciones.Text;

                Contrato nuevo_con = new Contrato()
                {


                    Numero = numero,
                    FechaCreacion = fechaCreacion,
                    Vigente = vigente,
                    FechaTermino = fechaTermino,
                    Direccion = direccion,
                    NumeroAsistentes = numeroAsistentes,
                    Evento = evento,
                    Observaciones = observaciones

                };

                //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                bool resp = dao.Modificar(nuevo_con);
                MessageBox.Show(resp ? "Contrato Modificado" : "Contrato No Modificado");


            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error");
            }

        }
    }
}
