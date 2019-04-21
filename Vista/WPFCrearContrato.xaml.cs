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
            txtNumero.Text =  DateTime.Now.ToString("yyyyMMddHHmm");
            lblUf.Content = "" + uf;
            cboTipo.ItemsSource = Enum.GetValues(typeof(TipoEvento));
            cboTipo.SelectedIndex = 0;

            dao = new DaoContrato();
        }

        //CREAR CONTRATO
        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String numero = txtNumero.Text;
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
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No guardado"));
                /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/


            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);
            }




        }

       
        //limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Clear();
            txtBuscarCliente.Clear();
            //LImpiar lbl cliente
            //lblNombreCliente;

            //dpFechaInicio;
            //dpFechaFinEvento;
            txtDireccion.Clear();
            txtHoraInicio.Clear();
            txtMinutoInicio.Clear();
            txtHoraTermino.Clear();
            txtMinutoTermino.Clear();
            cboTipo.SelectedItem = 0;
            //txtNumeroAsistentes.Clear();
            //txtPersonalAdicional.Clear();
            txtObservaciones.Clear();
            txtBuscarCliente.Focus();



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
        private async void btnBuscarContrato_Click_2(object sender, RoutedEventArgs e)
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
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Contrato no encontrado"));
                    /*MessageBox.Show("Contrato no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }

        }

        //BUSCAR CONTRATO

        public async void BuscarContrato()
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
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Contrato no Encontrado"));
                    MessageBox.Show("Contrato No encontrado");
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Buscar"));
                Logger.Mensaje(ex.Message);

            }
        }



        //BUSCAR CLIENTE
        private async void btnCliente_Click(object sender, RoutedEventArgs e)
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
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Cliente no encontrado"));
                    /*MessageBox.Show("Cliente no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        public async void Buscar()
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
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("Cliente no encontrado"));
                    /*MessageBox.Show("Cliente no Encontrado");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al Buscar"));
                /*MessageBox.Show("Error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        //MODIFICAR
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String numero = txtNumero.Text;
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
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Contrato Modificado" : "Contrato No Modificado"));
                /*MessageBox.Show(resp ? "Contrato Modificado" : "Contrato No Modificado");*/


            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error"));
                /*MessageBox.Show("Error");*/
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

        //TERMINAR CONTRATO
        private async void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // if ()
                //{
               //     MessageBox.Show("Debe crear un contrato");
                //}
               // else
                //{

                    if (rbNo.IsChecked == true)
                    {
                        await this.ShowMessageAsync("Mensaje","Contrato Ya terminado");
                    }
                    else
                    {
                        String numero = txtNumero.Text;
                        String fechaCreacion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        String vigente = "No";
                        String fechaTermino = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                        rbNo.IsChecked = true;
                        rbSi.IsChecked = false;

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

                        Contrato con_mod = new Contrato()
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
                        bool resp = dao.ModificarEstado(con_mod);
                        await this.ShowMessageAsync("Mensaje:",
                              string.Format(resp ? "Contrato Terminado" : "Contrato No Terminado"));
                        /*MessageBox.Show(resp ? "Contrato Terminado" : "Contrato No Terminado");*/

                    }
                
            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                MessageBox.Show(exa.Message);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Guardado"));
                MessageBox.Show("Error");
                Logger.Mensaje(ex.Message);
            }


        }



        //valor total
    }
}
