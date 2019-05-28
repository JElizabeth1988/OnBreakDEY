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
    /// Lógica de interacción para ListarContrato.xaml
    /// </summary>
    public partial class ListarContrato : MetroWindow
    {
        Crear_Contrato cc;//recibir a crear contrato
        WpfCliente cl;//recibir al Mantenedor de Cliente

        private WpfCliente cli = new WpfCliente();

        public ListarContrato()
        {
            InitializeComponent();
            btnPasar.Visibility = Visibility.Hidden;

            //COMBOBOX EVENTO
            foreach (TipoEvento item in new TipoEvento().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbofilTipoContrato.Items.Add(cb);
            }

            //LLENAR CB MODALIDAD SERVICIO

            foreach (ModalidadServicio item in new ModalidadServicio().ReadAll())
            {
                comboBoxItem2 cb = new comboBoxItem2();
                cb.id = item.Id;
                cb.descripcion = item.Nombre;
                cbFiltroModalidad.Items.Add(cb);
            }


            try
            {
                Contrato co = new Contrato();
                dgvLista.ItemsSource = co.ReadAll2();//LLamar al Listar Todo
                dgvLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error!" + ex.Message);
                Logger.Mensaje(ex.Message);
            }

            
        }

        //Llamado Ventana Contrato
        public ListarContrato(Crear_Contrato origen)
        {
            InitializeComponent();
            cc = origen;

            //COMBO BOX////////////////////////////////////////
            foreach (TipoEvento item in new TipoEvento().ReadAll())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id;
                cb.descripcion = item.Descripcion;
                cbofilTipoContrato.Items.Add(cb);
            }
         

            try
            {

                Contrato co = new Contrato();
                dgvLista.ItemsSource = co.ReadAll2();
                dgvLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Listar");
            }
            //////////////////////////////////////////////////////
        }

        //THIS
        public ListarContrato(WpfCliente cli)
        {
            this.cli = cli;
        }

        //salir
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
           
            if (btnPasar.Visibility == Visibility.Hidden)
            {
                btnPasar.Visibility = Visibility.Visible;
            }
            else {
                btnPasar.Visibility = Visibility.Hidden;
            }

        }






        //NÚMERO
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string numero = txtfiltroNumero.Text;

                List<ListaContratos> lcon = new Contrato().FiltroNumeroContrato(numero);
                dgvLista.ItemsSource = lcon;


            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje","error al Filtrar Información");
                Logger.Mensaje(ex.Message);
                dgvLista.Items.Refresh();
            }
        }


        //CLIENTE
        private async void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string rut = txtfiltroRut.Text;

                List<ListaContratos> lcl = new Contrato().FiltroRut(rut);
                dgvLista.ItemsSource = lcl;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje","error al Filtrar Información");
                Logger.Mensaje(ex.Message);
                dgvLista.Items.Refresh();

            }

        }
        //TIPOEVENTO
        private async void btnFiltrarTipo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                comboBoxItem tipoE = (comboBoxItem)cbofilTipoContrato.SelectedItem;

                List<ListaContratos> lf = new Contrato().FiltroTipoEvento(tipoE.descripcion);
                dgvLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje","error al Filtrar Información");
                Logger.Mensaje(ex.Message);
                dgvLista.Items.Refresh();
            }

        }

        private void btnPasar_Click_1(object sender, RoutedEventArgs e)
        {

            if (btnPasar.Visibility == Visibility.Hidden)
            {
                btnPasar.Visibility = Visibility.Hidden;

            }


            if (cc==null)
            {
                ListaContratos con = (ListaContratos)dgvLista.SelectedItem;
                cc.txtNumero.Text = con.Numero;
                cc.BuscarContrato();
            }
            else
            {
                ListaContratos con = (ListaContratos)dgvLista.SelectedItem;
                cc.txtNumero.Text = con.Numero;
                cc.BuscarContrato();
            }
            Close();

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente cli = new wpfListadoCliente(this);
            cli.Show();

        }

        //FILTRAR MODALIDAD
        private async void btnFiltrarModalidad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                comboBoxItem2 mod = (comboBoxItem2)cbFiltroModalidad.SelectedItem;

                List<ListaContratos> lf = new Contrato().FiltroModalidad(mod.descripcion);
                dgvLista.ItemsSource = lf;
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje", "error al Filtrar Información");
                Logger.Mensaje(ex.Message);
                dgvLista.Items.Refresh();
            }
        }
    }
}
