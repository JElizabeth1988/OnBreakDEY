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
        public Crear_Contrato()
        {
            InitializeComponent();
        }

        private void txtNumero_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            String numero = txtNumero.Text;
            String fechaInicio = dpFecha.Text;
            int horaInicio = int.Parse(txtHora.Text);
            int minutoInicio = int.Parse(txtMinuto.Text);
            String direccion = txtDireccion1.Text;
            //vigente???
            String fechaCreacion = dpCreacion.Text;
            String fechaTermino = dpTermino.Text;
            
            

     
    }
}
