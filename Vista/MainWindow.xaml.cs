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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //BOTON ADMINISTRACION CLIENTE
        private void Tile_Click(object sender, RoutedEventArgs e)
        {
            WpfCliente cliente = new WpfCliente();
            cliente.Show();
        }

        //boton listar cliente
        private void Tile_Click_2(object sender, RoutedEventArgs e)
        {
            wpfListadoCliente listCliente = new wpfListadoCliente();
            listCliente.Show();
        }
        //boton administracion contrato
        private void Tile_Click_4(object sender, RoutedEventArgs e)
        {

            Crear_Contrato contrato = new Crear_Contrato();
            contrato.Show();
        }
        //boton listar contrato
        private void Tile_Click_3(object sender, RoutedEventArgs e)
        {
            ListarContrato listContrato = new ListarContrato();
            listContrato.Show();
        }
    }
}
