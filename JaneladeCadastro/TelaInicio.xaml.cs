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
    /// Lógica interna para Window1.xaml
    /// </summary>
    public partial class TelaInicio : Window
    {
        public TelaInicio()
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

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            txtGerenciar.Visibility = Visibility.Visible;
        }
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            txtGerenciar.Visibility = Visibility.Collapsed;
        }

        private void Button_MouseEnter_1(object sender, MouseEventArgs e)
        {
            txtAdicionar.Visibility = Visibility.Visible;
        }
        private void Button_MouseLeave_1(object sender, MouseEventArgs e)
        {
            txtAdicionar.Visibility = Visibility.Collapsed;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnAdicionarRegistro_Click(object sender, RoutedEventArgs e)
        {
            MainWindow telaRegistro = new MainWindow();
            telaRegistro.Show();
            this.Close();
        }
        private void btnGerenciarRegistro_Click(object sender, RoutedEventArgs e)
        {
            GerenciarRegistros gerenciarRegistros = new GerenciarRegistros();
            gerenciarRegistros.Show();
            this.Close();
        }
    }
}
