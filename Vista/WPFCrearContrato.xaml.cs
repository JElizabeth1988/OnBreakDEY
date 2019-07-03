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

using System.Runtime.Caching;//para crear caché
using System.Xml.Serialization;//serializar objetos
using System.IO;//Entrada y salida de información

using BibliotecaNegocio;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using WpfControlLibrary1;
using System.Windows.Threading;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Crear_Contrato.xaml
    /// </summary>
    public partial class Crear_Contrato : MetroWindow
    {
        //PatronSingleton

        private static Crear_Contrato _instanciaCr;
        public static Crear_Contrato ObtenerinstanciaCr()
        {
            if (_instanciaCr == null )
            {
                _instanciaCr = new Crear_Contrato();
            }
            
            return _instanciaCr;
        }

        //Objeto que almacena los valores de caché
        private ObjectCache cacheName = MemoryCache.Default;

        //Método Timer para guardar cache
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblMensasje.Visibility = Visibility.Visible;
                String numero = lblNumero.Content.ToString();
                DateTime creacion = fechac;
                bool realizado;
                DateTime termino;
                if (rbSi.IsChecked == true)
                {
                    realizado = false;
                    termino = dpFechaTermino.recuperarFecha();

                }
                else
                {
                    realizado = true;
                    termino = dpFechaTermino.recuperarFecha();

                }


                //EVENTO

                //inicio
                DateTime fechaHoraInicio = dpFechaInicio1.recuperar();

                DateTime fechaHoraTermino = dpFechaTermino.recuperar();


                //////
                int asistentes = int.Parse(txtNumeroAsistentes.Text);
                /*int asistentes = 0;
                if (int.TryParse(txtNumeroAsistentes.Text, out asistentes))
                {

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese sólo números"));
                    txtNumeroAsistentes.Focus();
                    return;
                }*/
                int personalAdicional = int.Parse(txtPersonalAdicional.Text);
                /*int personalAdicional = 0;
                if (int.TryParse(txtPersonalAdicional.Text, out personalAdicional))
                {

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese sólo números"));
                    txtPersonalAdicional.Focus();
                    return;
                }*/

                //CB
                int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                String observaciones = txtObservaciones.Text;
                double valorc = double.Parse(lblTotal.Content.ToString());
                String rutCliente = txtBuscarCliente.Text;

                Contrato con = new Contrato()
                {

                    Numero = numero,
                    Creacion = creacion,
                    Termino = termino,
                    RutCliente = rutCliente,
                    IdModalidad = idMod,
                    IdTipoEvento = evento,
                    FechaHoraInicio = fechaHoraInicio,
                    FechaHoraTermino = fechaHoraTermino,
                    Asistentes = asistentes,
                    PersonalAdicional = personalAdicional,
                    Realizado = realizado,
                    ValorTotalContrato = calculo(),
                    Observaciones = observaciones,

                };

                CacheItemPolicy politica = new CacheItemPolicy();
                politica.Priority = CacheItemPriority.Default;
                politica.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5);//cada 5 minutos borra la politica (el cache)
                cacheName.Set("Contrato", con, politica);
                lblMensasje.Visibility = Visibility.Visible;
                lblMensasje.Content = "Almacenado en Cache";

            }
            catch (Exception ex)
            {
                // lblMensasje.Content = ex.Message;
                lblMensasje.Content = "No Guardado";

            }


        }


        double uf = new Servicios.Service1().Uf();
        //el constructor debe ser pasado a privado en el momento que se usa el patron singleton
        private Crear_Contrato()
        {
            // if (!IsPostBack)
            //{

                InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += timer_Tick;
            timer.Start();

            //PENDIENTE
            Contrato con = new Contrato();

                foreach (Contrato item in new Contrato().ReadAll())
                {
                    if (con.FechaHoraTermino >= DateTime.Now)
                    {

                        //MÉTODO TERMINAR
                        String numero = lblNumero.Content.ToString();
                        DateTime creacion = fechac;
                        bool realizado = true;
                        DateTime termino = DateTime.Now;


                        //EVENTO

                        //inicio
                        DateTime fechaHoraInicio = dpFechaInicio1.recuperar();

                        //termino
                        DateTime fechaFinTermino = dpFechaTermino.recuperar();


                        //////
                        int asistentes = int.Parse(txtNumeroAsistentes.Text);
                        int personalAdicional = int.Parse(txtPersonalAdicional.Text);

                        int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                        string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                        String observaciones = txtObservaciones.Text;
                        double valorc = double.Parse(lblTotal.Content.ToString());
                        String rutCliente = txtBuscarCliente.Text;

                        Contrato con_mod = new Contrato()
                        {


                            Numero = numero,
                            Creacion = creacion,
                            Termino = termino,
                            RutCliente = rutCliente,
                            IdModalidad = idMod,
                            IdTipoEvento = evento,
                            FechaHoraInicio = fechaHoraInicio,
                            FechaHoraTermino = fechaFinTermino,
                            Asistentes = asistentes,
                            PersonalAdicional = personalAdicional,
                            Realizado = realizado,
                            ValorTotalContrato = valorc,
                            Observaciones = observaciones,
                        };


                        //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                        bool resp = con_mod.Modificar();
                    }

                }

          
                lblNumero.Content = DateTime.Now.ToString("yyyyMMddHHmm");
                lblUf.Content = "$" + uf;
                this.cboTipo.SelectedItem = null;
                btnTerminar.Visibility = Visibility.Hidden;
                btnModificar.Visibility = Visibility.Hidden;

                cbVegetariana.IsEnabled = false;
                cbAmbientacion.IsEnabled = false;
                cbLocal.IsEnabled = false;
                cbMusica.IsEnabled = false;
                lbl_Arriendo.Visibility = Visibility.Hidden;
                txtArriendo.Visibility = Visibility.Hidden;

                cbVegetariana.Items.Add("Si");
                cbVegetariana.Items.Add("No");
                

                cbLocal.Items.Add("OnBreak");
                cbLocal.Items.Add("Otro");
               

                cbMusica.Items.Add("Ambiental");
                cbMusica.Items.Add("Cliente");
                

                //LLENAR COMBO BOX TIPO EVENTO
                foreach (TipoEvento item in new TipoEvento().ReadAll())
                {
                    comboBoxItem cb = new comboBoxItem();
                    cb.id = item.Id;
                    cb.descripcion = item.Descripcion;
                    cboTipo.Items.Add(cb);
                }
                //LLENAR COMBO BOX AMBIENTACION
                foreach (TipoAmbientacion item in new TipoAmbientacion().ReadAll())
                {
                    comboBoxItem cb = new comboBoxItem();
                    cb.id = item.IdTipoAmbientacion;
                    cb.descripcion = item.Descripcion;
                    cbAmbientacion.Items.Add(cb);
                }



                //LLENAR CB MODALIDAD SERVICIO

                foreach (ModalidadServicio item in new ModalidadServicio().ReadAll())
                {
                    comboBoxItem2 cb = new comboBoxItem2();
                    cb.id = item.Id;
                    cb.descripcion = item.Nombre;
                    cbModalidad.Items.Add(cb);
                }

                cboTipo.SelectedIndex = 0;
                cbModalidad.SelectedIndex = 0;
             
            // }
            //Falta timer!!!
            /*if (File.Exists(@"d:\copia.txt"))
             {

                 lblMensasje.Text = "Existe copia previa";
                 Timer1.Enabled = false;
                 XmlSerializer se = new XmlSerializer(typeof(ClPersona));
                 StringReader lector = new StringReader();
                 ClPersona p = (ClPersona)se.Deserialize(lector);
                 txtRut.Text = p.Rut;
                 txtNombre.Text = p.Nombre;
                 txtApellido.Text = p.Apellido;
                 txtEdad.Text = p.Edad.ToString();
                 cboEstadoCivil.Text = p.EstadoCivil;

             }*/

        }

        //METODO CALCULO
        public double calculo()
        {
           // ModalidadServicio mod = new ModalidadServicio();
            double valorc = double.Parse(lblValorBase.Content.ToString())
            + double.Parse(lblAsistentes.Content.ToString())
            + double.Parse(lblPersonalAdicional.Content.ToString());

            
            return valorc;
        }


    
        //BOTON CALCULO CONTRATO

        private async void btnCalculo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
 
                lblTotal.Content =calculo();
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Debe ingresar valor de asistentes"));
                Logger.Mensaje(ex.Message);
            }
           
        }

        //lblTotal.Content = calculo();

        //BORRAR ESTE DESPUÉS

        DateTime fechac = DateTime.Now;
        DateTime fechat = DateTime.Now;


        //CREAR CONTRATO
        private async void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (dpFechaInicio1.recuperar() >= DateTime.Now)
                {


                    if (dpFechaInicio1.recuperar() <= dpFechaTermino.recuperar())
                    {

                        if (dpFechaInicio1.recuperar() < DateTime.Now.AddMonths(10))
                        {

                            if (dpFechaTermino.recuperar() < dpFechaInicio1.recuperar().AddHours(24))
                            {



                                String numero = lblNumero.Content.ToString();
                                DateTime creacion = fechac;
                                bool realizado;
                                DateTime termino;
                                if (rbSi.IsChecked == true)
                                {
                                    realizado = false;
                                    termino = dpFechaTermino.recuperarFecha();

                                }
                                else
                                {
                                    realizado = true;
                                    termino = dpFechaTermino.recuperarFecha();

                                }


                                //EVENTO

                                //inicio
                                DateTime fechaHoraInicio = dpFechaInicio1.recuperar();

                                DateTime fechaHoraTermino = dpFechaTermino.recuperar();


                                //////

                                int asistentes = 0;
                                if (int.TryParse(txtNumeroAsistentes.Text, out asistentes))
                                {

                                }
                                else
                                {
                                    await this.ShowMessageAsync("Mensaje:",
                                      string.Format("Ingrese sólo números"));
                                    txtNumeroAsistentes.Focus();
                                    return;
                                }

                                int personalAdicional = 0;
                                if (int.TryParse(txtPersonalAdicional.Text, out personalAdicional))
                                {

                                }
                                else
                                {
                                    await this.ShowMessageAsync("Mensaje:",
                                      string.Format("Ingrese sólo números"));
                                    txtPersonalAdicional.Focus();
                                    return;
                                }

                                //CB
                                int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                                string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                                String observaciones = txtObservaciones.Text;
                                double valorc = double.Parse(lblTotal.Content.ToString());
                                String rutCliente = txtBuscarCliente.Text;

                                Contrato con = new Contrato()
                                {

                                    Numero = numero,
                                    Creacion = creacion,
                                    Termino = termino,
                                    RutCliente = rutCliente,
                                    IdModalidad = idMod,
                                    IdTipoEvento = evento,
                                    FechaHoraInicio = fechaHoraInicio,
                                    FechaHoraTermino = fechaHoraTermino,
                                    Asistentes = asistentes,
                                    PersonalAdicional = personalAdicional,
                                    Realizado = realizado,
                                    ValorTotalContrato = calculo(),
                                    Observaciones = observaciones,

                                };

                                //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                                bool resp = con.Grabar();
                                await this.ShowMessageAsync("Mensaje:",
                                      string.Format(resp ? "Guardado" : "No guardado"));
                                /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/
                            }

                            else
                            {
                                await this.ShowMessageAsync("Mensaje:",
                               string.Format("Error: Evento no puede durar más de 24 horas"));
                            }

                        }
                        else
                        {
                            await this.ShowMessageAsync("Mensaje:",
                          string.Format("Error: Fecha de Inicio no puede ser mayor a 10 meses desde fecha actual"));
                        }

                        }
                        else
                        {
                            await this.ShowMessageAsync("Mensaje:",
                              string.Format("Error: Fecha de Termino es menor a Fecha de Inicio"));
                        }

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                            string.Format("Error: Fecha y hora de inicio menor a fecha y hora actual"));
                    }
                
                    }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                await this.ShowMessageAsync("Mensaje:",string.Format((exa.Message)));
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
            btnCrear.Visibility = Visibility.Visible;
            btnModificar.Visibility = Visibility.Hidden;
            btnTerminar.Visibility = Visibility.Hidden;
            lblMensasje.Visibility = Visibility.Hidden;

            txtBuscarCliente.Clear();
            lblNombreCliente.Visibility = Visibility.Hidden;//desaparecer label
            //btnCrear.Visibility = Visibility.Visible;
            //btnModificar.Visibility = Visibility.Hidden;
            txtNumero.Clear();
            lblNumero.Content = DateTime.Now.ToString("yyyyMMddHHmm");
            txtBuscarCliente.Clear();
            //lblNombreCliente.Visibility = Visibility.Hidden;//no ver label
            cboTipo.SelectedIndex = 0;
            cbModalidad.SelectedIndex = 0;
            cbModalidad.IsEnabled = false;

            cbAmbientacion.SelectedIndex = 0;
            cbLocal.SelectedIndex = 0;
            cbMusica.SelectedIndex = 0;
            cbVegetariana.SelectedIndex = 0;
            //dpFechaInicio.SelectedDate = null;
            //dpFechaFinEvento.SelectedDate = null;
            //dpFechaInicio1.ClearValue(DatePicker);
            // dpFechaTermino.ClearValue(DatePicker);

            //MÉTODO LIMPIAR USERCONTROL
            dpFechaInicio1.limpiar();
            dpFechaTermino.limpiar();

            cboTipo.SelectedItem = 0;

            txtNumeroAsistentes.Clear();
            txtPersonalAdicional.Clear();

            txtObservaciones.Clear();
            txtBuscarCliente.Focus();
            rbSi.IsChecked = true;
            rbNo.IsChecked = false;

            ////DESBLOQUEAR EDITAR EL CONTRATO
            if (!txtBuscarCliente.IsEnabled)
            {
                btnCrear.Visibility = Visibility.Visible;
                btnModificar.Visibility = Visibility.Hidden;
                btnTerminar.Visibility = Visibility.Hidden;
                
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                txtNumero.IsEnabled = true;
                //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                lblNumero.IsEnabled = true;
                //EVENTO
                //inicio
                // dpFechaInicio.IsEnabled = true;
                // txtHoraInicio.IsEnabled = true;
                //txtMinutoInicio.IsEnabled = true;
                //termino
                //dpFechaFinEvento.IsEnabled = true;
                //txtHoraTermino.IsEnabled = true;
                //txtMinutoTermino.IsEnabled = true;
                //////

                //MÉTODO DESBLOQUEAR USERCONTROL
                dpFechaInicio1.desbloquear();
                dpFechaTermino.desbloquear();

                txtNumeroAsistentes.IsEnabled = true;
                txtPersonalAdicional.IsEnabled = true;
                cboTipo.IsEnabled = true;
                txtObservaciones.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
            }




        }

        //listar numero contrato
        private void btnListadoNum_Click(object sender, RoutedEventArgs e)
        {
            ListarContrato con = new ListarContrato(this);
            con.ShowDialog();
           // btnTerminar.Visibility = Visibility.Visible;


        }

        //listar cliente
        private void btnListadoCliente_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente cli = new wpfListadoCliente(this);
            cli.ShowDialog();

        }
        
        //salir
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ////DESBLOQUEAR EDITAR EL CONTRATO
            if (!txtBuscarCliente.IsEnabled)
            {
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                txtNumero.IsEnabled = true;
                //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                txtNumero.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;
                lblNumero.IsEnabled = true;
                //EVENTO
                //inicio
                // dpFechaInicio.IsEnabled = true;
                // txtHoraInicio.IsEnabled = true;
                //txtMinutoInicio.IsEnabled = true;
                //termino
                //dpFechaFinEvento.IsEnabled = true;
                // txtHoraTermino.IsEnabled = true;
                //txtMinutoTermino.IsEnabled = true;
                //////

                //MÉTODO DESBLOQUEAR USERCONTROL
                dpFechaInicio1.desbloquear();
                dpFechaTermino.desbloquear();

                txtNumeroAsistentes.IsEnabled = true;
                txtPersonalAdicional.IsEnabled = true;
                cboTipo.IsEnabled = true;
                txtObservaciones.IsEnabled = true;
                txtBuscarCliente.IsEnabled = true;

       
            }
            this.Close();
        }


   
        //BUSCAR CONTRATO de traspasar
        private async void btnBuscarContrato_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Contrato c = new Contrato();
                Cliente clie = new Cliente();
                c.Numero = txtNumero.Text;
                lblNombreCliente.Visibility = Visibility.Visible;//aparecer label
                bool buscar = c.Buscar();
                if (c.Realizado == true)
                {
                    rbSi.IsChecked = false;
                    rbNo.IsChecked = true;
                    //BLOQUEAR EDITAR EL CONTRATO
                    txtNumero.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    txtNumero.IsEnabled = false;
                    //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                    txtNumero.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    lblNumero.IsEnabled = false;
                    cbModalidad.IsEnabled = false;
                    cboTipo.IsEnabled = false;
                    txtObservaciones.IsEnabled = false;
                    txtNumeroAsistentes.IsEnabled = false;
                    txtPersonalAdicional.IsEnabled = false;
                    dpFechaInicio1.bloquear();
                    dpFechaTermino.bloquear();

                }
                else
                {
                    rbSi.IsChecked = true;
                    rbNo.IsChecked = false;
                    //BLOQUEAR EDITAR EL CONTRATO
                    txtNumero.IsEnabled = true;
                    txtBuscarCliente.IsEnabled = true;
                    txtNumero.IsEnabled = true;
                    //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                    txtNumero.IsEnabled = true;
                    txtBuscarCliente.IsEnabled = true;
                    lblNumero.IsEnabled = true;
                    cbModalidad.IsEnabled = true;
                    cboTipo.IsEnabled = true;
                    txtObservaciones.IsEnabled = true;
                    txtNumeroAsistentes.IsEnabled = true;
                    txtPersonalAdicional.IsEnabled = true;

                }


                if (buscar)
                {

                    txtBuscarCliente.Text = c.RutCliente;
                    //dpFechaInicio.Text = c.FechaHoraInicio.ToString();
                    //dpFechaFinEvento.Text = c.FechaHoraTermino.ToString();
                    //txtHoraInicio.Text = c.HoraInicio.ToString();
                    //txtMinutoInicio.Text = c.MinutoInicio.ToString();
                    //txtHoraTermino.Text = c.HoraTermino.ToString();
                    //txtMinutoTermino.Text = c.MinutoTermino.ToString();

                    dpFechaInicio1.datos(c.FechaHoraInicio);
                    dpFechaTermino.datos(c.FechaHoraTermino);

                    dpFechaInicio1.datos(c.FechaHoraInicio);
                    dpFechaTermino.datos(c.FechaHoraTermino);

                    txtNumeroAsistentes.Text = c.Asistentes.ToString();
                    txtPersonalAdicional.Text = c.PersonalAdicional.ToString();

                    TipoEvento tip = new TipoEvento();
                    tip.Id = c.IdTipoEvento;
                    tip.Read();
                    cboTipo.Text = tip.Descripcion;//Cambiar a descripción

                    //PASAR nombre modalidad no id
                    ModalidadServicio mod = new ModalidadServicio();
                    mod.Id = c.IdModalidad;
                    mod.Read();
                    cbModalidad.Text = mod.Nombre;//Cambiar a descripción

                    /*cboTipo.Text = c.IdTipoEvento.ToString();
                    cbModalidad.Text = c.IdModalidad.ToString();*/

                   // cbModalidad.Text = c.IdModalidad;
                    txtObservaciones.Text = c.Observaciones;
                    lblNumero.Content = txtNumero.Text; //IGUALAR CAMPOS 
                    lblNombreCliente.Visibility = Visibility.Visible;//aparecer label
                    lblTotal.Content= calculo();
                    btnModificar.Visibility = Visibility.Visible;
                    btnTerminar.Visibility = Visibility.Visible;
                    
                    btnCrear.Visibility = Visibility.Hidden;//Desaparece el btn crear
                    
                    
                    lblNombreCliente.Content = clie.RazonSocial;
                    
                    
                    
                    




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

        //MÉTODO BUSCAR CONTRATO botón buscar

        public async void BuscarContrato()
        {
            try
            {
                Contrato c = new Contrato();
                c.Numero = txtNumero.Text;
                lblNombreCliente.Visibility = Visibility.Visible;//aparecer label
                bool buscar = c.Buscar();
                if (buscar)
                {


                    txtBuscarCliente.Text = c.RutCliente;
                    //dpFechaInicio.Text = c.FechaHoraInicio.ToString();
                    //dpFechaFinEvento.Text = c.FechaHoraTermino.ToString();
                    //txtHoraInicio.Text = c.HoraInicio.ToString();
                    //txtMinutoInicio.Text = c.MinutoInicio.ToString();
                    //txtHoraTermino.Text = c.HoraTermino.ToString();
                    //txtMinutoTermino.Text = c.MinutoTermino.ToString();

                    dpFechaInicio1.datos(c.FechaHoraInicio);
                    dpFechaTermino.datos(c.FechaHoraTermino);

                    dpFechaInicio1.datos(c.FechaHoraInicio);
                    dpFechaTermino.datos(c.FechaHoraTermino);

                    txtNumeroAsistentes.Text = c.Asistentes.ToString();
                    txtPersonalAdicional.Text = c.PersonalAdicional.ToString();

                    TipoEvento tip = new TipoEvento();
                    tip.Id = c.IdTipoEvento;
                    tip.Read();
                    cboTipo.Text = tip.Descripcion;//Cambiar a descripción

                    //PASAR nombre modalidad no id
                    ModalidadServicio mod = new ModalidadServicio();
                    mod.Id = c.IdModalidad;
                    mod.Read();
                    cbModalidad.Text = mod.Nombre;//Cambiar a descripción
                    lblTotal.Content= calculo();
                    /*cboTipo.Text = c.IdTipoEvento.ToString();
                    cbModalidad.Text = c.IdModalidad.ToString();*/

                   // cbModalidad.Text = c.IdModalidad;
                    txtObservaciones.Text = c.Observaciones;
                    lblNumero.Content = txtNumero.Text; //IGUALAR CAMPOS 
                    btnModificar.Visibility = Visibility.Visible;
                    btnTerminar.Visibility = Visibility.Visible;
                    btnCrear.Visibility = Visibility.Hidden;

                    Cliente cl = new Cliente();
                    lblNombreCliente.Content = cl.RazonSocial;
                    lblNombreCliente.Visibility = Visibility.Visible;




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

        //BUSCAR CLIENTE
        private async void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtBuscarCliente.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {
                   
                    lblNombreCliente.Content = c.RazonSocial;

                    lblNombreCliente.Visibility = Visibility.Visible;//aparecer label

                    lblNombreCliente.Visibility = Visibility.Visible;//ver label

                    btnCrear.Visibility = Visibility.Visible;

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
        //Busca cliente en listado de clientes
        public async void Buscar()
        {
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtBuscarCliente.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {
                    lblNombreCliente.Content = c.RazonSocial;
                    lblNombreCliente.Visibility = Visibility.Visible;
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

               // if (dpFechaInicio.SelectedDate <= dpFechaFinEvento.SelectedDate)
                {
                    String numero = lblNumero.Content.ToString();
                    DateTime creacion = fechac;
                    bool realizado;
                    DateTime termino;
                    if (rbSi.IsChecked == true)
                    {
                        realizado = false;
                        termino = dpFechaTermino.recuperarFecha();

                    }
                    else
                    {
                        realizado = true;
                        termino = dpFechaTermino.recuperarFecha();



                    }


                    //////

                    int asistentes = 0;
                    if (int.TryParse(txtNumeroAsistentes.Text, out asistentes))
                    {

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Ingrese sólo números"));
                        txtNumeroAsistentes.Focus();
                        return;
                    }

                    int personalAdicional = 0;
                    if (int.TryParse(txtPersonalAdicional.Text, out personalAdicional))
                    {

                    }
                    else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Ingrese sólo números"));
                        txtPersonalAdicional.Focus();
                        return;
                    }

                    //CB
                    int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                    string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                    String observaciones = txtObservaciones.Text;
                    double valorc = double.Parse(lblTotal.Content.ToString());
                    String rutCliente = txtBuscarCliente.Text;

                    Contrato nuevo_con = new Contrato()
                    {

                        Numero = numero,
                        Creacion = creacion,
                        Termino = termino,
                        RutCliente = rutCliente,
                        IdModalidad =idMod,
                        IdTipoEvento = evento,
                        FechaHoraInicio = dpFechaInicio1.recuperar(),
                        FechaHoraTermino = dpFechaTermino.recuperar(),
                        Asistentes = asistentes,
                        PersonalAdicional = personalAdicional,
                        Realizado = realizado,
                        ValorTotalContrato = valorc,
                        Observaciones = observaciones,
                    };

                    //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                    bool resp = nuevo_con.Modificar();
                    await this.ShowMessageAsync("Mensaje:",
                          string.Format(resp ? "Contrato Modificado" : "Contrato No Modificado"));
                    /*MessageBox.Show(resp ? "Contrato Modificado" : "Contrato No Modificado");*/


                }
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

        //TERMINAR CONTRATO
        private async void btnTerminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var x =
             await this.ShowMessageAsync("Advertencia", "¿Desea Dar Término al Contrato?",
                     MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                   
                    String numero = lblNumero.Content.ToString();
                    DateTime creacion = fechac;
                    bool realizado = true;
                    DateTime termino = DateTime.Now;
                    rbNo.IsChecked = true;
                    rbSi.IsChecked = false;

                    

                    //EVENTO

                    //inicio
                    DateTime fechaHoraInicio= dpFechaInicio1.recuperar();

                    //termino
                    DateTime fechaFinTermino = dpFechaTermino.recuperar();
                    

                    //////
                    int asistentes = int.Parse(txtNumeroAsistentes.Text);
                    int personalAdicional = int.Parse(txtPersonalAdicional.Text);

                    int evento = ((comboBoxItem)cboTipo.SelectedItem).id;
                    string idMod = ((comboBoxItem2)cbModalidad.SelectedItem).id;

                    String observaciones = txtObservaciones.Text;
                    double valorc = double.Parse(lblTotal.Content.ToString());
                    String rutCliente = txtBuscarCliente.Text;

                    Contrato con_mod = new Contrato()
                    {


                        Numero = numero,
                        Creacion = creacion,
                        Termino = termino,
                        RutCliente = rutCliente,
                        IdModalidad = idMod,
                        IdTipoEvento = evento,
                        FechaHoraInicio = fechaHoraInicio,
                        FechaHoraTermino = fechaFinTermino,
                        Asistentes = asistentes,
                        PersonalAdicional = personalAdicional,
                        Realizado = realizado,
                       ValorTotalContrato = valorc,
                        Observaciones = observaciones,
                    };

                    //BLOQUEAR EDITAR EL CONTRATO
                    txtNumero.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    txtNumero.IsEnabled = false;
                    //Convert.ToDateTime(txtNumero).ToString("dd/MM/yyyy HH:mm")
                    txtNumero.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    lblNumero.IsEnabled = false;
                    cbModalidad.IsEnabled = false;
                    cboTipo.IsEnabled = false;
                    txtObservaciones.IsEnabled = false;
                    txtNumeroAsistentes.IsEnabled = false;
                    txtPersonalAdicional.IsEnabled = false;
                    dpFechaInicio1.bloquear();
                    dpFechaTermino.bloquear();

                    /*EVENTO

                    //inicio
                    dpFechaInicio.IsEnabled = false;
                    txtHoraInicio.IsEnabled = false;
                    txtMinutoInicio.IsEnabled = false;
                    //termino
                    dpFechaFinEvento.IsEnabled = false;
                    txtHoraTermino.IsEnabled = false;
                    txtMinutoTermino.IsEnabled = false;

                    //////
                    txtNumeroAsistentes.IsEnabled = false;
                    txtPersonalAdicional.IsEnabled = false;
                    cboTipo.IsEnabled = false;
                    txtObservaciones.IsEnabled = false;
                    txtBuscarCliente.IsEnabled = false;
                    */


                    //METODO AGREGAR DEVUELVE BOOLEAN POR ESO SE CREA VARIABLE BOOLEANA resp
                    bool resp = con_mod.Modificar();

                    /*MessageBox.Show(resp ? "Contrato Terminado" : "Contrato No Terminado");*/
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Contrato Terminado" : "Contrato No Terminado"));
                    btnTerminar.Visibility = Visibility.Hidden;
                    btnModificar.Visibility = Visibility.Hidden;
                    btnCrear.Visibility = Visibility.Hidden;
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
        



        //valor evento base

        //Valor asistentes
        private async void txtNumeroAsistentes_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            //try
            //{
            if (txtNumeroAsistentes.Text != null)
            {
                Servicios.Service1 WS = new Servicios.Service1();
                double uf = WS.Uf();

             
                double asi = 0;
                if (double.TryParse(txtNumeroAsistentes.Text, out asi))
                {

                }
                else
                {
                    
                    txtNumeroAsistentes.Focus();
                    return;
                }

                double n = 0;

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
                    double c = asi - 50;
                    n = 5;
                    double r = (c / 20);
                    n = n + r;

                }
                double v = (n * uf);
               lblAsistentes.Content = v.ToString();
            }
            else
            {
                txtNumeroAsistentes.Text = "0";
            }
            //}
            //catch (ArgumentException exa) //catch excepciones hechas por el usuario
            //{
            //    MessageBox.Show(exa.Message);
            //}
            //catch (Exception ex)
            //{
            //    await this.ShowMessageAsync("Mensaje:",
            //          string.Format("Error ingreso de datos"));
            //    MessageBox.Show("Error");
            //    Logger.Mensaje(ex.Message);
            //}
        }



        //valor personal adicional
        private async void txtPersonalAdicional_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtPersonalAdicional.Text != null)
            {
                ModalidadServicio mod = new ModalidadServicio();
                double personal = 0;
                if (double.TryParse(txtPersonalAdicional.Text, out personal))
                {

                }
                else
                {
                    
                    txtPersonalAdicional.Focus();
                    return;
                }
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
                if (personal > mod.PersonalBase)
                {
                    double cantidad = personal - mod.PersonalBase;
                    cant_uf = 3.5;

                    double extra = (cantidad * 0.5);
                    cant_uf = cant_uf + extra;

                }

                double v = (double)(cant_uf * uf);
                lblPersonalAdicional.Content = v.ToString();
            }
            //else
            //{
            //    await this.ShowMessageAsync("Mensaje", "Debe crear un contrato");
            //}
        }

        private void cboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int contenido = ((comboBoxItem)cboTipo.SelectedItem).id;

            ModalidadServicio mod = new ModalidadServicio();
            cbModalidad.Items.Clear();
            cbModalidad.IsEnabled = true;
            foreach (var item in mod.ReadAll().Where(con => con.IdtipoEvento == contenido).ToList())
            {
                comboBoxItem2 cb = new comboBoxItem2();
                cb.id = item.Id;
                cb.descripcion = item.Nombre;
                cbModalidad.Items.Add(cb);
            }
            cbModalidad.SelectedIndex = 0;

            //Si es Coffe Break
            if (contenido.Equals(10))
            {
                cbVegetariana.IsEnabled = true;
                cbAmbientacion.IsEnabled = false;
                cbLocal.IsEnabled = false;
                cbMusica.IsEnabled = false;
            }

            //Si es Cocktail
            if (contenido.Equals(20))
            {
                cbAmbientacion.IsEnabled = true;
                cbMusica.IsEnabled = true;

                cbVegetariana.IsEnabled = false;
                cbLocal.IsEnabled = false;

            }

            //si es Cenas
            if (contenido.Equals(30))
            {


                cbVegetariana.IsEnabled = false;
                cbAmbientacion.IsEnabled = true;
                cbMusica.IsEnabled = true;
                cbLocal.IsEnabled = true;

                lbl_Arriendo.Visibility = Visibility.Hidden;
                txtArriendo.Visibility = Visibility.Hidden;

                var item = cbLocal.SelectedItem = "Otro";
                if (item != null)
                {
                    lbl_Arriendo.Visibility = Visibility.Visible;
                    txtArriendo.Visibility = Visibility.Visible;


                }



            }



        }



        private void btnMasHoraInicio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbModalidad_LostFocus(object sender, SelectionChangedEventArgs e)
        {
            if (cbModalidad.SelectedItem != null)
            {
                string moda = ((comboBoxItem2)cbModalidad.SelectedItem).id;
                int cant = 0;

                if (moda.Equals("CB001"))
                {
                    cant = 3;
                }
                if (moda.Equals("CB002"))
                {
                    cant = 8;
                }
                if (moda.Equals("CB003"))
                {
                    cant = 12;
                }
                if (moda.Equals("CE001"))
                {
                    cant = 25;
                }
                if (moda.Equals("CE002"))
                {
                    cant = 35;
                }
                if (moda.Equals("CO001"))
                {
                    cant = 6;
                }
                if (moda.Equals("CO002"))
                {
                    cant = 10;
                }

                double valor = (double)(cant * uf);
                lblValorBase.Content = valor.ToString();
            }   

        }


        protected void btnRecuperar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblMensasje.Visibility = Visibility.Visible;
                Contrato c = cacheName["Contrato"] as Contrato;
                lblNumero.Content = c.Numero;
                //txtNumero.Text = c.Numero;
                txtBuscarCliente.Text = c.RutCliente;
                dpFechaInicio1.datos(c.FechaHoraInicio);
                dpFechaTermino.datos(c.FechaHoraTermino);
                dpFechaInicio1.datos(c.FechaHoraInicio);
                dpFechaTermino.datos(c.FechaHoraTermino);
                txtNumeroAsistentes.Text = c.Asistentes.ToString();
                txtPersonalAdicional.Text = c.PersonalAdicional.ToString();
                TipoEvento tip = new TipoEvento();
                tip.Id = c.IdTipoEvento;
                tip.Read();
                cboTipo.Text = tip.Descripcion;//Cambiar a descripción

                //PASAR nombre modalidad no id
                ModalidadServicio mod = new ModalidadServicio();
                mod.Id = c.IdModalidad;
                mod.Read();
                cbModalidad.Text = mod.Nombre;//Cambiar a descripción

                // cbModalidad.Text = c.IdModalidad;
                txtObservaciones.Text = c.Observaciones;

                lblNombreCliente.Visibility = Visibility.Visible;//aparecer label
                lblTotal.Content = calculo();


                Cliente clie = new Cliente();
                lblNombreCliente.Content = clie.RazonSocial;

                lblMensasje.Content = "Cache Recuperado";

            }
            catch (Exception ex)
            {
                lblMensasje.Content = "Error al Cargar el cache";

            }

        }

        protected void btnLimpiarCache_Click(object sender, RoutedEventArgs e)
        {
            lblMensasje.Visibility = Visibility.Visible;
            cacheName.Remove("Contrato", null);
            lblMensasje.Content = "Eliminó cache";
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            _instanciaCr = null;
        }
    }
    
}
