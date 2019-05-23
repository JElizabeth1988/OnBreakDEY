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

namespace WpfControlLibrary1
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private int hora=0, minutos=0;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnmenoshora_Click(object sender, RoutedEventArgs e)
        {
            hora--;
            if (hora <0)
            {
                hora = 24;
            }
            txthora.Text = hora.ToString();
        }

        private void btnmasminutos_Click(object sender, RoutedEventArgs e)
        {
            minutos++;
            if (minutos > 59)
            {
                minutos = 0;
            }
            txtminutos.Text = minutos.ToString();
        }

        private void btnmenosminutos_Click(object sender, RoutedEventArgs e)
        {
            minutos--;
            if (minutos<0)
            {
                minutos = 59;
            }
            txtminutos.Text = minutos.ToString();
        }

        private void btnmashora_Click(object sender, RoutedEventArgs e)
        {
            hora++;
            if (hora>24)
            {
                hora = 0;
            }
            txthora.Text = hora.ToString();
        }
        public DateTime recuperar() {
            int ano = ((DateTime)dtfecha.SelectedDate).Year;
            int mes = ((DateTime)dtfecha.SelectedDate).Month;
            int dia = ((DateTime)dtfecha.SelectedDate).Day;
            int hora = int.Parse(txthora.Text);
            int min = int.Parse(txtminutos.Text);

            return new DateTime(ano, mes, dia, hora, min, 0);

        }
        public DateTime recuperarFecha()
        {
            int ano = ((DateTime)dtfecha.SelectedDate).Year;
            int mes = ((DateTime)dtfecha.SelectedDate).Month;
            int dia = ((DateTime)dtfecha.SelectedDate).Day;

            return new DateTime(ano, mes, dia);
        }


    }
}
