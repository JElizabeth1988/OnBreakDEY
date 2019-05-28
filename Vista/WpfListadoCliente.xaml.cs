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

using BibliotecaNegocio;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para wpfListadoCliente.xaml
    /// </summary>
    public partial class wpfListadoCliente : MetroWindow
    {
        WpfCliente cl;//recibir a cliente
        
        Crear_Contrato cc;//Recibe al Contrato

        //Llamado desde menú principal
        public wpfListadoCliente()
        {
            InitializeComponent();

            btnPasar.Visibility = Visibility.Hidden;//el botón traspasar no se ve

            //llenar el combo box con los datos del enumerador
            foreach (ActividadEmpresa item in new ActividadEmpresa().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbActiv.Items.Add(cb);
            }
            foreach (TipoEmpresa item in new TipoEmpresa().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbTipoEmp.Items.Add(cb);
            }

            try
            {
                Cliente cl = new Cliente();
                dgLista.ItemsSource = cl.ReadAll2();//No sé si este bien
                dgLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                Logger.Mensaje(ex.Message);
            }
        }
        //Llamado desde Contrato
        public wpfListadoCliente(Crear_Contrato origen)
        {
            InitializeComponent();

            btnPasar.Visibility = Visibility.Visible;//el botón traspasar se ve
            btnEliminar.Visibility = Visibility.Hidden;//Botón eliminar no se ve
            //llenar el combo box con los datos del enumerador
            foreach(ActividadEmpresa item in new ActividadEmpresa().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbActiv.Items.Add(cb);
            }
            foreach (TipoEmpresa item in new TipoEmpresa().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbTipoEmp.Items.Add(cb);
            }

            try
            {
                Cliente cl = new Cliente();
                dgLista.ItemsSource = cl.ReadAll2();//No sé si este bien
                dgLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
            }
            cc = origen;
        }

        //Llamado desde el modulo administrar Cliente
        public  wpfListadoCliente(WpfCliente origen)
        {
            InitializeComponent();
            cl = origen;
            btnPasar.Visibility = Visibility.Visible;//Botón pasar es visible
            btnEliminar.Visibility = Visibility.Hidden;//Botón Eliminar no se ve
                                                       
            //llenar el combo box con los datos del enumerador
            foreach (ActividadEmpresa item in new ActividadEmpresa().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbActiv.Items.Add(cb);
            }
            foreach (TipoEmpresa item in new TipoEmpresa().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbTipoEmp.Items.Add(cb);
            }
            
            try
            {
                Cliente cl = new Cliente();
                dgLista.ItemsSource = cl.ReadAll2();//No sé si este bien
                dgLista.Items.Refresh();

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al Listar!" + ex.Message);
            }

        }



        //Botón Salir
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Botón Pasar
        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            btnPasar.Visibility = Visibility.Visible;

            if (cl==null)
            {
                ListaClientes cli = (ListaClientes)dgLista.SelectedItem;
                cc.txtBuscarCliente.Text = cli.Rut;
                cc.Buscar();
            }
            else
            {
                ListaClientes cli = (ListaClientes)dgLista.SelectedItem;
                string rutbuscar;
                rutbuscar = cl.txtRut+"-"+cl.txtDV;
                cl.txtRut.Text = cli.Rut;
                cl.Buscar();
                
            }
            Close();

        }

        //Botón Filtrar rut
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string rut = txtFiltroRut.Text;

                List<ListaClientes> lc = new Cliente().FiltroRut(rut);
                dgLista.ItemsSource = lc;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);

                dgLista.Items.Refresh();
            }
        }
        //Botón filtrar tipoEmpresa
        private async void btnFiltrarTipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                comboBoxItem tipo = (comboBoxItem)cbTipoEmp.SelectedItem;
                List<ListaClientes> lf = new Cliente().FiltroEmp(tipo.descripcion);
                dgLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
                dgLista.Items.Refresh();
            }

        }

        //Botón filtrar Actividad Empresa
        private async void btnFiltrarAct_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                
                comboBoxItem act = (comboBoxItem)cbActiv.SelectedItem;
                List<ListaClientes> lf = new Cliente().FiltroAct(act.descripcion);
                dgLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
                dgLista.Items.Refresh();
            }

        }

        //Botón Eliminar
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                           
                    ListaClientes cli = (ListaClientes)dgLista.SelectedItem;
                var x = await this.ShowMessageAsync("Eliminar Datos de Cliente" + cli.Rut,
                         "¿Desea eliminar al Cliente?",
                        MessageDialogStyle.AffirmativeAndNegative);
                if (x == MessageDialogResult.Affirmative)
                {
                    Cliente cl = new Cliente();
                    cl.RutCliente = cli.Rut;
                    bool resp = cl.Eliminar();
                    if (resp)
                    {
                        await this.ShowMessageAsync("Mensaje:",
                          string.Format("Cliente Eliminado"));
                        /*MessageBox.Show("Cliente eliminado"); */
                        dgLista.ItemsSource =
                        cl.ReadAll2();
                        dgLista.Items.Refresh();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Lo Sentimos:",
                          string.Format("No se puede eliminar al Cliente porque tiene contratos asociados"));
                        /*MessageBox.Show("No se eliminó al Cliente");*/
                    }
                }
                else
                    {
                        await this.ShowMessageAsync("Mensaje:",
                              string.Format("Operación Cancelada"));
                        /*MessageBox.Show("Operación Cancelada");*/
                    }
            }
            catch (Exception ex)
            {

                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al Eliminar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }

        }
    }
}