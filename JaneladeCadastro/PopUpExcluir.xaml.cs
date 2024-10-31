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
    /// Lógica interna para PopUpExcluirTelefone.xaml
    /// </summary>
    public partial class PopUpExcluir : Window
    {
        private List<int> ids = new();
        public int _idDigitado;
        public PopUpExcluir(List<int> id)
        {
            InitializeComponent();
            ids = id;
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirmarId_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txbIdDigitado.Text))
            {
                if (int.TryParse(txbIdDigitado.Text, out int valor))
                {
                    if (ids.Contains(valor))
                    {
                        _idDigitado = valor;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ID não encontrado!");
                    }
                }
                else
                {
                    MessageBox.Show("Digite um ID válido!");
                }
            }
        }
    }
}
