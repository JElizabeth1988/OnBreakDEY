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

            //COMBOBOX
            cbofilTipoContrato.ItemsSource = Enum.GetValues(typeof
                (TipoEvento));
            this.cbofilTipoContrato.SelectedItem = null;


            try
            {
                DaoContrato dao = new DaoContrato(); 
                dgvLista.ItemsSource = dao.Listar(); 
                dgvLista.Items.Refresh(); 

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Listar");
            }
            
        }

        //Llamado Ventana Principal
        public ListarContrato(Crear_Contrato origen)
        {
            InitializeComponent();
            cc = origen;

            //COMBO BOX
            cbofilTipoContrato.ItemsSource = Enum.GetValues(typeof
                (TipoEvento));
            this.cbofilTipoContrato.SelectedItem = null;

            try
            {

                DaoContrato dao = new DaoContrato();
                dgvLista.ItemsSource = dao.Listar();
                dgvLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Listar");
            }
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


        

        private void dgvLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //NÚMERO
        private async void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string numero = txtfiltroNumero.Text;

                List<Contrato> lcon = new DaoContrato()
                    .FiltroNum(numero);
                dgvLista.ItemsSource = lcon;


            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Mensaje","error al Filtrar Información");
            }
        }

        //CLIENTE
        private async void btnFiltrarRut_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string rut = txtfiltroRut.Text;

                List<Contrato> lcl = new DaoContrato()
                    .FiltroRut(rut);
                dgvLista.ItemsSource = lcl;
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Mensaje","error al Filtrar Información");
            }

        }
        //TIPOEVENTO
        private async void btnFiltrarTipo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                TipoEvento tipoE = (TipoEvento)cbofilTipoContrato.SelectedItem;
                List<Contrato> lf = new DaoContrato()
                    .FiltroCon(tipoE);
                dgvLista.ItemsSource = lf;
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Mensaje","error al Filtrar Información");
            }

        }

        private void btnPasar_Click_1(object sender, RoutedEventArgs e)
        {

            if (btnPasar.Visibility == Visibility.Hidden)
            {
                btnPasar.Visibility = Visibility.Hidden;

            }


            if (cc.btnModificar.Visibility == Visibility.Hidden)
            {
                cc.btnModificar.Visibility = Visibility.Hidden;

            }
            Contrato con = (Contrato)dgvLista.SelectedItem;
            cc.txtNumero.Text = con.Numero;
            cc.BuscarContrato();
            cc.btnModificar.Visibility = Visibility.Visible;

        }
    }
}
