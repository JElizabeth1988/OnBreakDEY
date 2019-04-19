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
        double uf = new Servicios.Service1().Uf();
        public RoutedEventHandler btnBuscarContrato_Click { get; private set; }

        public Crear_Contrato()
        {

            InitializeComponent();
            lblUf.Content = "" + uf;
            cboTipo.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cboTipo.SelectedIndex = 0;

            dao = new DaoContrato();
        }

        //crear contrato
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

                //EVENTO

                //inicio
                String fechaInicioEvento = dpFechaInicio.Text;
                int horaInicio = int.Parse(txtHoraInicio.Text);
                int minutoInicio = int.Parse(txtMinutoInicio.Text);
                //termino
                String fechaFinEvento = dpFechaFinEvento.Text;
                int horaTermino = int.Parse(txtHoraTermino.Text);
                int minutoTermino = int.Parse(txtMinutoTermino.Text);
                
                //////
                String direccion = txtDireccion.Text;
                int numeroAsistentes = int.Parse(txtNumeroAsistentes.Text);
                int personalAdicional = int.Parse(txtPersonalAdicional.Text);
                TipoEvento evento = (TipoEvento)cboTipo.SelectedItem;


                String observaciones = txtObservaciones.Text;
                String rutCliente = txtBuscarCliente.Text;

                Contrato con = new Contrato()
                {

                    Numero = numero,
                    FechaCreacion = fechaCreacion,
                    Vigente = vigente,
                    FechaTermino = fechaTermino,
                    FechaInicioEvento = fechaInicioEvento,
                    HoraInicio = horaInicio,
                    MinutoInicio = minutoInicio,
                    FechaFinEvento = fechaFinEvento,
                    HoraTermino = horaTermino,
                    MinutoTermino = minutoTermino,
                    Direccion = direccion,
                    NumeroAsistentes = numeroAsistentes,
                    PersonalAdicional=personalAdicional,
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

                MessageBox.Show("Error de ingreso de datos");
                Logger.Mensaje(ex.Message);
            }




        }

       
        //limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Clear();
            txtBuscarCliente.Clear();
            txtObservaciones.Clear();
            txtNumero.Focus();



        }

        //listar numero contrato
        private void btnListadoNum_Click(object sender, RoutedEventArgs e)
        {
            ListarContrato con = new ListarContrato(this);
            con.Show();
            
        }

        //listar cliente
        private void btnListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente cli = new wpfListadoCliente(this);
            cli.Show();

        }
        
        //salir
        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


   
        //BUSCAR CONTRATO
        private void btnBuscarContrato_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato c = new DaoContrato().
                    BuscarContrato(txtNumero.Text);
                if (c != null)
                {
                  
                    txtDireccion.Text = c.Direccion;
                    dpFechaInicio.Text = c.FechaInicioEvento;
                    txtHoraInicio.Text = c.HoraInicio.ToString();
                    txtMinutoInicio.Text = c.MinutoInicio.ToString();
                    txtHoraTermino.Text = c.HoraTermino.ToString();
                    txtMinutoTermino.Text = c.MinutoTermino.ToString();
                    txtNumeroAsistentes.Text = c.NumeroAsistentes.ToString();
                    txtPersonalAdicional.Text = c.PersonalAdicional.ToString();
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
                Logger.Mensaje(ex.Message);

            }

        }

        //BUSCAR CLIENTE
        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new DaoCliente().
                    BuscarCliente(txtBuscarCliente.Text);
                if (c != null)
                {
                    lblNombreCliente.Content = c.NombreContacto;
                }
                else
                {
                    MessageBox.Show("Cliente no Encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar");
                Logger.Mensaje(ex.Message);

            }
        }

        public void Buscar()
        {
            try
            {
                Cliente c = new DaoCliente().
                    BuscarCliente(txtBuscarCliente.Text);
                if (c != null)
                {
                    lblNombreCliente.Content = c.NombreContacto;
                }
                else
                {
                    MessageBox.Show("Cliente no Encontrado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar");
                Logger.Mensaje(ex.Message);

            }
        }

        //MODIFICAR
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

                //EVENTO

                //EVENTO

                //inicio
                String fechaInicioEvento = dpFechaInicio.Text;
                int horaInicio = int.Parse(txtHoraInicio.Text);
                int minutoInicio = int.Parse(txtMinutoInicio.Text);
                //termino
                String fechaFinEvento = dpFechaFinEvento.Text;
                int horaTermino = int.Parse(txtHoraTermino.Text);
                int minutoTermino = int.Parse(txtMinutoTermino.Text);

                //////
                String direccion = txtDireccion.Text;
                int numeroAsistentes = int.Parse(txtNumeroAsistentes.Text);
                int personalAdicional = int.Parse(txtPersonalAdicional.Text);
                TipoEvento evento = (TipoEvento)cboTipo.SelectedItem;


                String observaciones = txtObservaciones.Text;
                String rutCliente = txtBuscarCliente.Text;

                Contrato nuevo_con = new Contrato()
                {

                    Numero = numero,
                    FechaCreacion = fechaCreacion,
                    Vigente = vigente,
                    FechaTermino = fechaTermino,
                    FechaInicioEvento = fechaInicioEvento,
                    HoraInicio = horaInicio,
                    MinutoInicio = minutoInicio,
                    FechaFinEvento = fechaFinEvento,
                    HoraTermino = horaTermino,
                    MinutoTermino = minutoTermino,
                    Direccion = direccion,
                    NumeroAsistentes = numeroAsistentes,
                    PersonalAdicional = personalAdicional,
                    Evento = evento,
                    Observaciones = observaciones,
                    RutCliente = rutCliente
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
                Logger.Mensaje(ex.Message);
            }

        }


        //MOSTRAR VALORES EVENTO

            //valor evento base

            //Valor asistentes
        private void txtNumeroAsistentes_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtNumeroAsistentes.Text != null)
            {
                Servicios.Service1 WS = new Servicios.Service1();
                double uf = WS.Uf();
                int asi = int.Parse(txtNumeroAsistentes.Text);
                int n = 0;

                if (asi >= 1 && asi <= 20)
                {
                    n = 3;
                }
                if (asi >= 21 && asi <= 50)
                {
                    n = 5;
                }
                if (asi > 50)
                {
                    int c = asi - 50;
                    n = 5;
                    int r = (c / 20);
                    n = n + r;

                }
                int v = (int)(n * uf);
                lblAsistentes.Content = v.ToString();
            }
        }

            //valor personal adicional
        private void txtPersonalAdicional_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtPersonalAdicional.Text != null)
            {
                
                int personal = int.Parse(txtPersonalAdicional.Text);
                double cant_uf = 0;


                if (personal == 2)
                {
                    cant_uf = 2;
                }
                if (personal == 3)
                {
                    cant_uf = 3;
                }
                if (personal == 4)
                {
                    cant_uf = 3.5;
                }
                if (personal > 4)
                {
                    int cantidad = personal - 4;
                    cant_uf = 3.5;

                    double extra = (cantidad * 0.5);
                    cant_uf = cant_uf + extra;

                }

                int v = (int)(cant_uf * uf);
                lblPersonalAdicional.Content = v.ToString();
            }
        }



        //valor total
    }
}
