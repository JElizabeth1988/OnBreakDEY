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
        WpfCliente cl;

        private WpfCliente cli = new WpfCliente();

        public ListarContrato()
        {
            InitializeComponent();
            btnPasar.Visibility = Visibility.Hidden;

            //COMBOBOX
            cbofilTipoContrato.ItemsSource = Enum.GetValues(typeof
                (TipoEvento));
            cbofilTipoContrato.SelectedIndex = 0;


            try
            {
                DaoContrato dao = new DaoContrato(); 
                dgvLista.ItemsSource = dao.Listar(); 
                dgvLista.Items.Refresh(); 

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Listar"+ex.Message);
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
            cbofilTipoContrato.SelectedIndex = 0;

            try
            {

                DaoContrato dao = new DaoContrato();
                dgvLista.ItemsSource = dao.Listar();
                dgvLista.Items.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Listar" + ex.Message);
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

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {


            try
            {

                //NUMERO
                Contrato con = new Contrato();
                string numero = txtfiltroNumero.Text;

                List<Contrato> lcon = new DaoContrato()
                    .FiltroNum(numero);
                dgvLista.ItemsSource = lcon;


                //CLIENTE
                Cliente co = new Cliente();
                string rut = txtfiltroRut.Text;

                List <Cliente> lco = new DaoContrato()
                    .FiltroRut(rut);
                dgvLista.ItemsSource = lco;


                //TIPOEVENTO
                Cliente cl = new Cliente();
                TipoEvento tipoE = (TipoEvento)cbofilTipoContrato.SelectedItem;
                List<Contrato> lf = new DaoContrato()
                    .FiltroCon(tipoE);
                dgvLista.ItemsSource = lf;

            }
            catch (Exception)
            {
                MessageBox.Show("error al Filtrar Información");
            }
        }

 
    }
}
