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
        private Crear_Contrato crear_Contrato;

        public wpfListadoCliente()
        {
            InitializeComponent();
            btnPasar.Visibility = Visibility.Hidden;

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
        }//llamado desde menu principal, el btn traspasar no se ve

        public wpfListadoCliente(WpfCliente origen)
        {
            InitializeComponent();
            cl = origen;

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

        }

        public wpfListadoCliente(Crear_Contrato crear_Contrato)
        {
            this.crear_Contrato = crear_Contrato;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnPasar_Click(object sender, RoutedEventArgs e)
        {
            if (btnPasar.Visibility == Visibility.Hidden)
            {
                btnPasar.Visibility = Visibility.Hidden;

            }
            else
            {
                btnPasar.Visibility = Visibility.Hidden;
            }
            
        }
    }
}