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
using System.Windows.Threading;

namespace Vista
{
    /// <summary>
    /// Lógica de C:\Users\Hitachiin-Sama\Documents\GitHub\UnBreakable\BibliotecaControlador\Logger.csinteracción para WpfCliente.xaml
    /// </summary>
    public partial class WpfCliente : MetroWindow
    {

        //PatronSingleton
        private static WpfCliente _instancia;


        public static WpfCliente ObtenerinstanciaCLI()
        {
            if (_instancia == null)
            {
                _instancia = new WpfCliente();
            }
            
            return _instancia;
        }

        private ObjectCache cacheName = MemoryCache.Default;
        //Método Timer para guardar cache
        void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer se = new XmlSerializer(typeof(Cliente));
                StringWriter escritor = new StringWriter();
                String rut = txtRut.Text + "-" + txtDV.Text;
                if (rut.Length == 11)
                {
                    rut = "0" + txtRut.Text + "-" + txtDV.Text;
                }
                Cliente p = new Cliente()
                {
                    RutCliente = rut,
                    NombreContacto = txtNombre.Text,
                    RazonSocial = txtRazon.Text,

                    MailContacto = txtEmail.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    IdActividadEmpresa = ((comboBoxItem)cbActividad.SelectedItem).id,
                    IdTipoEmpresa = ((comboBoxItem)cbTipo.SelectedItem).id,


                };
                CacheItemPolicy politica = new CacheItemPolicy();
                politica.Priority = CacheItemPriority.Default;
                politica.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5);//cada 5 minutos borra la politica (el cache)
                cacheName.Set("Cliente", p, politica);
                label2.Visibility = Visibility.Visible;
                //label2.Content = "Almacenada en cache";

                se.Serialize(escritor, p);
                try
                {
                    File.Delete(@"d:\copiaCliente.txt");//Borra copia anterior

                    File.AppendAllText(@"d:\copiaCliente.txt", escritor.ToString());//Guarda copia automaticamente en el disco d
                    label2.Content = "Datos Respaldados!";
                }
                catch (Exception ex)
                {
                    label2.Content = ex.Message;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Errorsillo");
            }

        }

        //el constructor debe ser pasado a privado en el momento que se usa el patron singleton
        private WpfCliente()
        {
           
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Tick += timer_Tick;
            timer.Start();

            if (!IsLoaded)
            {
                txtDV.IsEnabled = false;
                btnModificar.Visibility = Visibility.Hidden;//el botón Modificar no se ve

                //llenar el combo box con los datos del enumerador
                foreach (ActividadEmpresa item in new ActividadEmpresa().ReadAll())
                {
                    comboBoxItem cb = new comboBoxItem();
                    cb.id = item.Id;
                    cb.descripcion = item.Descripcion;
                    cbActividad.Items.Add(cb);
                }
                foreach (TipoEmpresa item in new TipoEmpresa().ReadAll())
                {
                    comboBoxItem cb = new comboBoxItem();
                    cb.id = item.Id;
                    cb.descripcion = item.Descripcion;
                    cbTipo.Items.Add(cb);
                }
                cbActividad.SelectedIndex = 0;
                cbTipo.SelectedIndex = 0;
                txtTelefono.Text = "0";

           }
            if (File.Exists(@"d:\copiaCliente.txt") )
            {
                try
                {
                    string xml = @"d:\copiaCliente.txt";

                    label2.Content = "Existe copia previa";
                    timer.IsEnabled = false;
                    XmlSerializer se = new XmlSerializer(typeof(Cliente));

                    TextReader lector = new StreamReader(xml);
                    Cliente c = (Cliente)se.Deserialize(lector);
                    txtRut.Text = c.RutCliente.Substring(0, 10);
                    txtDV.Text = c.RutCliente.Substring(11, 1);
                    txtRazon.Text = c.RazonSocial;
                    txtNombre.Text = c.NombreContacto;
                    txtEmail.Text = c.MailContacto;
                    txtDireccion.Text = c.Direccion;
                    txtTelefono.Text = c.Telefono;
                    ActividadEmpresa ac = new ActividadEmpresa();
                    ac.Id = c.IdActividadEmpresa;
                    ac.Read();
                    cbActividad.Text = ac.Descripcion;//Cambiar a descripción
                    TipoEmpresa te = new TipoEmpresa();
                    te.Id = c.IdTipoEmpresa;
                    te.Read();
                    cbTipo.Text = te.Descripcion;//Cambiar a descripción

                }
                catch (Exception ex)
                {

                    label2.Content =ex;
                }
               

            }
            else
            {
                StringWriter escritor = new StringWriter();
                File.AppendAllText(@"d:\copiaCliente.txt", escritor.ToString());
            }
        }


        private void Recuperar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                label2.Visibility = Visibility.Visible;
                Cliente c = cacheName["Cliente"] as Cliente;

                txtRut.Text = c.RutCliente.Substring(0, 10);
                txtDV.Text = c.RutCliente.Substring(11, 1);
                txtRazon.Text = c.RazonSocial;
                txtNombre.Text = c.NombreContacto;
                txtEmail.Text = c.MailContacto;
                txtDireccion.Text = c.Direccion;
                txtTelefono.Text = c.Telefono;
                ActividadEmpresa ac = new ActividadEmpresa();
                ac.Id = c.IdActividadEmpresa;
                ac.Read();
                cbActividad.Text = ac.Descripcion;//Cambiar a descripción
                TipoEmpresa te = new TipoEmpresa();
                te.Id = c.IdTipoEmpresa;
                te.Read();
                cbTipo.Text = te.Descripcion;//Cambiar a descripción

                label2.Content = "Cache Recuperado";

            }
            catch (Exception ex)
            {
                label2.Content = "Error al Cargar el cache";

            }

        }

        private void LimpiarCache_Click(object sender, RoutedEventArgs e)
        {
            cacheName.Remove("Cliente", null);
            label2.Content = "Eliminó cache";
            try
            {
                File.Delete(@"d:\copiaCliente.txt");
                

            }
            catch (Exception ex)
            {
                label2.Content = ex.Message;
            }
        }


        //Botón limpiar
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtDV.Clear();
            txtRut.Clear();
            txtRut.IsEnabled = true;
            txtRazon.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Text = "0";
            cbActividad.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;//Para que en el ComboBox no quede seleccionado nada
            txtRut.Focus();//Mover el cursor a la poscición Rut
            label2.Visibility = Visibility.Hidden;
            btnModificar.Visibility = Visibility.Hidden;//botón modificar desaparece
            btnGuardar.Visibility = Visibility.Visible;//botón guardar aparece
            txtRut.IsEnabled = true;

        }

        //Botón '?'
        //llama el listado de clientes
        private void btnPregunta_Click(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente list = new wpfListadoCliente(this);
            list.ShowDialog();
            


        }

        //Botón Cancelar/Cerrar
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Botón Guardar
        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text+"-"+txtDV.Text;
                if (rut.Length == 11)
                {
                    rut = "0"+txtRut.Text + "-" + txtDV.Text;
                }
                String razonSocial = txtRazon.Text;
                String nombreContacto = txtNombre.Text;
                String mail = txtEmail.Text;
                String direccion = txtDireccion.Text;
                int telefono = 0;
                if (int.TryParse(txtTelefono.Text, out telefono))
                {

                }
                else
                {
                    //await this.ShowMessageAsync("Mensaje:",
                    //  string.Format("Ingrese un número de 9 dígitos"));
                    //txtTelefono.Focus();
                    return;
                }
                int Actividad = ((comboBoxItem)cbActividad.SelectedItem).id;
                int Tipo = ((comboBoxItem)cbTipo.SelectedItem).id;
                Cliente c = new Cliente()
                {
                    RutCliente = rut,
                    RazonSocial = razonSocial,
                    NombreContacto = nombreContacto,
                    MailContacto = mail,
                    Direccion = direccion,
                    Telefono = telefono.ToString(),
                    IdActividadEmpresa = Actividad,
                    IdTipoEmpresa = Tipo

                };
                bool resp = c.Grabar();
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Guardado" : "No Guardado"));
                /*MessageBox.Show(resp ? "Guardado" : "No Guardado");*/


                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES
                if (resp==false)//If para que no muestre mensaje en blanco en caso de éxito
                {
                    DaoErrores de = c.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format(li));
                }
                
                
                //-----------------------------------------------------------------------------------------------


            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error de ingreso de datos"));
                /*MessageBox.Show("Error de ingreso de datos");*/
                Logger.Mensaje(ex.Message);

            }
        }



        //Llamado del botón traspasar
        public async void Buscar()
        {
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtRut.Text;
                bool buscar = c.Buscar();
                
                if (buscar)
                {
                    txtRut.Text = c.RutCliente.Substring(0, 10);
                    txtDV.Text = c.RutCliente.Substring(11, 1);
                    txtRut.IsEnabled = false;
                    txtDV.IsEnabled = false;
                    txtRazon.Text = c.RazonSocial;
                    txtNombre.Text = c.NombreContacto;
                    txtEmail.Text = c.MailContacto;
                    txtDireccion.Text = c.Direccion;
                    txtTelefono.Text = c.Telefono.ToString();
                    ActividadEmpresa ac = new ActividadEmpresa();
                    ac.Id = c.IdActividadEmpresa;
                    ac.Read();
                    cbActividad.Text = ac.Descripcion;//Cambiar a descripción
                    TipoEmpresa te = new TipoEmpresa();
                    te.Id = c.IdTipoEmpresa;
                    te.Read();
                    cbTipo.Text = te.Descripcion;//Cambiar a descripción


                    btnModificar.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Hidden;

                    txtRut.IsEnabled = false;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("No se encontraron resultados!"));
                    /*MessageBox.Show("No se encontraron resultados!");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Buscar Información"));
                /*MessageBox.Show("error al buscar");*/
                Logger.Mensaje(ex.Message);


            }
        }

        //Botón Buscar (de administrar cliente)
        private async void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Cliente c = new Cliente();
                c.RutCliente = txtRut.Text +"-"+ txtDV.Text;
                bool buscar = c.Buscar();
                if (buscar)
                {
                    txtRut.Text = c.RutCliente.Substring(0, 10);
                    txtDV.Text = c.RutCliente.Substring(11, 1);
                    txtRut.IsEnabled = false;
                    txtDV.IsEnabled = false;
                    txtRazon.Text = c.RazonSocial;
                    txtNombre.Text = c.NombreContacto;
                    txtEmail.Text = c.MailContacto;
                    txtDireccion.Text = c.Direccion;
                    txtTelefono.Text = c.Telefono.ToString();
                    ActividadEmpresa ac = new ActividadEmpresa();
                    ac.Id = c.IdActividadEmpresa;
                    ac.Read();
                    cbActividad.Text = ac.Descripcion;//Cambiar a descripción
                    TipoEmpresa te = new TipoEmpresa();
                    te.Id = c.IdTipoEmpresa;
                    te.Read();
                    cbTipo.Text = te.Descripcion;//Cambiar a descripción

                    btnModificar.Visibility = Visibility.Visible;
                    btnGuardar.Visibility = Visibility.Hidden;

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                     string.Format("No se encontraron resultados!"));
                    /*MessageBox.Show("No se encontraron resultados!");*/
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Buscar Información! "));
                /*MessageBox.Show("error al buscar");*/
                Logger.Mensaje(ex.Message);

            }
        }

        //Botón modificar
        private async void btnModificar_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                String rut = txtRut.Text+"-"+txtDV.Text;
                String razonSocial = txtRazon.Text;
                String nombreContacto = txtNombre.Text;
                String mail = txtEmail.Text;
                String direccion = txtDireccion.Text;
                int telefono = 0;
                if (int.TryParse(txtTelefono.Text, out telefono))
                {

                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Ingrese un número de 9 dígitos"));
                    txtTelefono.Focus();
                    return;
                }
                int Actividad = ((comboBoxItem)cbActividad.SelectedItem).id;
                int Tipo = ((comboBoxItem)cbTipo.SelectedItem).id;
                Cliente c = new Cliente()
                {
                    RutCliente = rut,
                    RazonSocial = razonSocial,
                    NombreContacto = nombreContacto,
                    MailContacto = mail,
                    Direccion = direccion,
                    Telefono = telefono.ToString(),
                    IdActividadEmpresa = Actividad,
                    IdTipoEmpresa = Tipo

                };
                bool resp = c.Modificar();
                await this.ShowMessageAsync("Mensaje:",
                     string.Format(resp ? "Actualizado" : "No Actualizado"));
                /*MessageBox.Show(resp ? "Actualizado" : "No Actualizado, (El rut no se debe modificar)");*/

                //-----------------------------------------------------------------------------------------------
                //MOSTRAR LISTA DE ERRORES
                if (resp == false)//If para que no muestre mensaje en blanco en caso de éxito
                {

                    DaoErrores de = c.retornar();
                    string li = "";
                    foreach (string item in de.ListarErrores())
                    {
                        li += item + " \n";
                    }
                    await this.ShowMessageAsync("Mensaje:",
                        string.Format(li));
                }
                

                //-----------------------------------------------------------------------------------------------

            }
            catch (ArgumentException exa)//mensajes de reglas de negocios
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Actualizar Datos"));
                /*MessageBox.Show("Error al Actualizar");*/
                Logger.Mensaje(ex.Message);

            }
        }


        //añadir formato al rut

        private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtRut.Text.Length>=7 && txtRut.Text.Length<=8)
            {
                string v = new Verificar().ValidarRut(txtRut.Text);
                txtDV.Text = v;
                try
                {
                    string rutSinFormato = txtRut.Text;

                    //si el rut ingresado tiene "." o "," o "-" son ratirados para realizar la formula 
                    rutSinFormato = rutSinFormato.Replace(",", "");
                    rutSinFormato = rutSinFormato.Replace(".", "");
                    rutSinFormato = rutSinFormato.Replace("-", "");
                    string rutFormateado = String.Empty;

                    //obtengo la parte numerica del RUT
                    //string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);
                    string rutTemporal = rutSinFormato;
                    //obtengo el Digito Verificador del RUT
                    //string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

                    Int64 rut;

                    //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
                    if (!Int64.TryParse(rutTemporal, out rut))
                    {
                        rut = 0;
                    }

                    //este comando es el que formatea con los separadores de miles
                    rutFormateado = rut.ToString("N0");

                    if (rutFormateado.Equals("0"))
                    {
                        rutFormateado = string.Empty;
                    }
                    else
                    {
                        //si no hubo problemas con el formateo agrego el DV a la salida
                        // rutFormateado += "-" + dv;

                        //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
                        rutFormateado = rutFormateado.Replace(",", ".");
                    }

                    //se pasa a mayuscula si tiene letra k
                    rutFormateado = rutFormateado.ToUpper();

                    //la salida esperada para el ejemplo es 99.999.999-K
                    txtRut.Text = rutFormateado;
                }
                catch (Exception)
                {

                }
            }
            else
            {
                txtRut.Text = "";
            }
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            _instancia = null;
        }





        ////Dar formato al rut

        //private void txtRut_LostFocus(object sender, RoutedEventArgs e)
        //{

        //    try
        //    {
        //        string rutSinFormato = txtRut.Text;

        //        //si el rut ingresado tiene "." o "," o "-" son ratirados para realizar la formula 
        //        rutSinFormato = rutSinFormato.Replace(",", "");
        //        rutSinFormato = rutSinFormato.Replace(".", "");
        //        rutSinFormato = rutSinFormato.Replace("-", "");
        //        string rutFormateado = String.Empty;

        //        //obtengo la parte numerica del RUT
        //        string rutTemporal = rutSinFormato.Substring(0, rutSinFormato.Length - 1);

        //        //obtengo el Digito Verificador del RUT
        //        string dv = rutSinFormato.Substring(rutSinFormato.Length - 1, 1);

        //        Int64 rut;

        //        //aqui convierto a un numero el RUT si ocurre un error lo deja en CERO
        //        if (!Int64.TryParse(rutTemporal, out rut))
        //        {
        //            rut = 0;
        //        }

        //        //este comando es el que formatea con los separadores de miles
        //        rutFormateado = rut.ToString("N0");

        //        if (rutFormateado.Equals("0"))
        //        {
        //            rutFormateado = string.Empty;
        //        }
        //        else
        //        {
        //            //si no hubo problemas con el formateo agrego el DV a la salida
        //            rutFormateado += "-" + dv;

        //            //y hago este replace por si el servidor tuviese configuracion anglosajona y reemplazo las comas por puntos
        //            rutFormateado = rutFormateado.Replace(",", ".");
        //        }

        //        //se pasa a mayuscula si tiene letra k
        //        rutFormateado = rutFormateado.ToUpper();

        //        //la salida esperada para el ejemplo es 99.999.999-K
        //        txtRut.Text = rutFormateado;
        //    }
        //    catch (Exception)
        //    {

        //    }

        //}
    }

}
