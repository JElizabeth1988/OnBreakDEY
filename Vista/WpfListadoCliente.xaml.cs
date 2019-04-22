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
    /// Lógica de interacción para wpfListadoCliente.xaml
    /// </summary>
    public partial class wpfListadoCliente : MetroWindow
    {
        WpfCliente cl;//recibir a cliente
        
        Crear_Contrato cc;
        //Llamado desde menú principal
        public wpfListadoCliente()
        {
            InitializeComponent();

            btnPasar.Visibility = Visibility.Hidden;//el botón traspasar no se ve

            //llenar el combo box con los datos del enumerador
            cbActiv.ItemsSource = Enum.GetValues(typeof
                (ActividadEmpresa));
            cbActiv.SelectedIndex = 0;

            cbTipoEmp.ItemsSource = Enum.GetValues(typeof
                (TipoEmpresa));
            cbTipoEmp.SelectedIndex = 0;

            try
            {
                DaoCliente dao = new DaoCliente();
                dgLista.ItemsSource = dao.Listar();
                dgLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                Logger.Mensaje(ex.Message);
            }
        }

        public wpfListadoCliente(Crear_Contrato origen)
        {
            InitializeComponent();

            btnPasar.Visibility = Visibility.Visible;//el botón traspasar no se ve

            //llenar el combo box con los datos del enumerador
            cbActiv.ItemsSource = Enum.GetValues(typeof
                (ActividadEmpresa));
            cbActiv.SelectedIndex = 0;

            cbTipoEmp.ItemsSource = Enum.GetValues(typeof
                (TipoEmpresa));
            cbTipoEmp.SelectedIndex = 0;

            try
            {
                DaoCliente dao = new DaoCliente();
                dgLista.ItemsSource = dao.Listar();
                dgLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
            }
            cc = origen;
        }

        //Llamado desde el modulo administrar Cliente
        public wpfListadoCliente(WpfCliente origen)
        {
            InitializeComponent();
            cl = origen;
            btnPasar.Visibility = Visibility.Visible;

            //llenar el combo box con los datos del enumerador
            cbActiv.ItemsSource = Enum.GetValues(typeof
                (ActividadEmpresa));
            cbActiv.SelectedIndex = 0;

            cbTipoEmp.ItemsSource = Enum.GetValues(typeof
                (TipoEmpresa));
            cbTipoEmp.SelectedIndex = 0;

            try
            {
                DaoCliente dao = new DaoCliente();
                dgLista.ItemsSource = dao.Listar();
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
            if (btnPasar.Visibility == Visibility.Hidden)
            {
                btnPasar.Visibility = Visibility.Hidden;//hacer visible el botón

            }
            /*else
            {
                btnPasar.Visibility = Visibility.Hidden;//hacer que vuelva a desaparecer, en este caso no lo necesitamos
            }*/
            if (cl==null)
            {
                Cliente cli = (Cliente)dgLista.SelectedItem;
                cc.txtBuscarCliente.Text = cli.Rut;
                cc.Buscar();
            }
            else
            {
                Cliente cli = (Cliente)dgLista.SelectedItem;
                cl.txtRut.Text = cli.Rut;
                cl.Buscar();
            }
            

        }

        //Botón Filtrar rut
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string rut = txtFiltroRut.Text;

                List<Cliente> lc = new DaoCliente()
                    .FiltroRut(rut);
                dgLista.ItemsSource = lc;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }
        //Botón filtrar tipo
        private async void btnFiltrarTipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TipoEmpresa tipo = (TipoEmpresa)cbTipoEmp.SelectedItem;
                List<Cliente> lf = new DaoCliente()
                    .FiltroEmp(tipo);
                dgLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }
        }

        //Botón filtrar tipo
        private async void btnFiltrarAct_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                
                ActividadEmpresa act = (ActividadEmpresa)cbActiv.SelectedItem;
                List<Cliente> lf = new DaoCliente()
                    .FiltroAct(act);
                dgLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                     string.Format("Error al filtrar la Información"));
                /*MessageBox.Show("error al Filtrar Información");*/
                Logger.Mensaje(ex.Message);
            }

        }

        //Botón Eliminar
        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            /*ntrato co = new Contrato();
            Cliente cl = new Cliente();
            //falta validar que no tenga contratos asociados!!!!
            if (co.RutCliente != cl.Rut)
            {*/

            Cliente cli = (Cliente)dgLista.SelectedItem;
            MessageBoxResult respuesta =
                /*await this.ShowMessageAsync("Mensaje:",
                      string.Format("¿Desea eliminar al Cliente?", "Eliminar",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning));*/
            MessageBox.Show(
                    "¿Desea eliminar al Cliente?",
                    "Eliminar",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
            if (respuesta == MessageBoxResult.Yes)
            {
                bool resp = new DaoCliente().Eliminar(cli.Rut);
                if (resp)
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("Cliente Eliminado"));
                    /*MessageBox.Show("Cliente eliminado");*/
                    dgLista.ItemsSource =
                        new DaoCliente().Listar();
                }
                else
                {
                    await this.ShowMessageAsync("Mensaje:",
                      string.Format("No se eliminó al Cliente"));
                    /*MessageBox.Show("No se eliminó al Cliente");*/
                }
            }
            else
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Operación Cancelada"));
                /*MessageBox.Show("Operación Cancelada");*/
            }
            /* }
              else
              {
                  MessageBox.Show("No se puede eliminar al Cliente, púes tiene contratos asociados!");
              }*/
        }
    }
}