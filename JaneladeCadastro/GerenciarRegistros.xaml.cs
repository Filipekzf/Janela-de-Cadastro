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

namespace JaneladeCadastro
{
    /// <summary>
    /// Lógica interna para GerenciarRegistros.xaml
    /// </summary>
    public partial class GerenciarRegistros : Window
    {
        public GerenciarRegistros()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnVoltarTela_Click(object sender, RoutedEventArgs e)
        {
            TelaInicio telaInicio = new();
            telaInicio.Show();
            this.Close();
        }
    }
}
