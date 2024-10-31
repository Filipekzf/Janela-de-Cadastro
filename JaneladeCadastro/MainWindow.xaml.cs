using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.IO;
using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using static MaterialDesignThemes.Wpf.Theme;
using System.Windows.Ink;
using System.Text.RegularExpressions;

namespace JaneladeCadastro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InformacoesPessoais informacoesPessoais { get; set; } = new();

        bool valido = false;

        public MainWindow()
        {
            InitializeComponent();

            List<string> estados = new()
        {
            "",
            "AC", // Acre
            "AL", // Alagoas
            "AP", // Amapá
            "AM", // Amazonas
            "BA", // Bahia
            "CE", // Ceará
            "DF", // Distrito Federal
            "ES", // Espírito Santo
            "GO", // Goiás
            "MA", // Maranhão
            "MT", // Mato Grosso
            "MS", // Mato Grosso do Sul
            "MG", // Minas Gerais
            "PA", // Pará
            "PB", // Paraíba
            "PR", // Paraná
            "PE", // Pernambuco
            "PI", // Piauí
            "RJ", // Rio de Janeiro
            "RN", // Rio Grande do Norte
            "RS", // Rio Grande do Sul
            "RO", // Rondônia
            "RR", // Roraima
            "SC", // Santa Catarina
            "SP", // São Paulo
            "SE", // Sergipe
            "TO"  // Tocantins
        };
            cbxEstado.ItemsSource = estados;

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

        private void cbxSexo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxSexo.SelectedIndex == 2)
            {
                borderSexoOutro.Visibility = Visibility.Visible;
            }
            else
            {
                borderSexoOutro.Visibility = Visibility.Collapsed;
                txbSexoOutro.Text = null;
            }
        }
        private void dpkDataNascimento_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (DateTime.TryParse(dpkDataNascimento.Text, out DateTime textDate))
            {
                DateTime dateTime = new();
                DateTime DataNascimento = DateTime.TryParse(dpkDataNascimento.Text, out DateTime data) ? data : dateTime;
                int Idade = DateTime.Now.Year - DataNascimento.Year;
                if (DateTime.Now.Month <= DataNascimento.Month)
                {
                    if (DateTime.Now.Month == DataNascimento.Month)
                    {
                        if (DateTime.Now.Day < DataNascimento.Day)
                        {
                            Idade--;
                        }
                    }
                    else
                    {
                        Idade--;
                    }
                }

                txbIdade.Text = Idade.ToString();
            }
        }
        private void cbxEscolaridade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxEscolaridade.SelectedIndex == 4)
            {
                txbEscolaridadeOutro.Visibility = Visibility.Visible;
                borderEscolaridadeOutro.Visibility = Visibility.Visible;
            }
            else
            {
                txbEscolaridadeOutro.Visibility = Visibility.Collapsed;
                borderEscolaridadeOutro.Visibility = Visibility.Collapsed;
                txbEscolaridadeOutro.Text = null;
            }
        }

        private void btnProximo_Click(object sender, RoutedEventArgs e)
        {
            int indexTabDadosAtual = tabControlDados.SelectedIndex;
            int indexTabLateralAtual = tabControlLateral.SelectedIndex;

            if (indexTabDadosAtual == 0)
            {
                ValidadorDadosPessoais();

                if (valido == true)
                {
                    ellipsePage1.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipsePage2.Fill = new SolidColorBrush(Colors.DarkRed);
                    ellipsePage3.Fill = new SolidColorBrush(Colors.Transparent);

                    if (informacoesPessoais.Telefones.Count == 0)
                        borderBtnProximo.IsEnabled = false;

                    PassarTab(indexTabDadosAtual, indexTabLateralAtual);
                }
            }
            else if (indexTabDadosAtual == 1)
            {
                if (valido == true && dgTelefones.IsReadOnly == true)
                {
                    ellipsePage1.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipsePage2.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipsePage3.Fill = new SolidColorBrush(Colors.DarkRed);

                    PassarTab(indexTabDadosAtual, indexTabLateralAtual);
                }

                if (dgTelefones.IsReadOnly == false)
                    MessageBox.Show("Finalize Edição de dados");
            }
        }
        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            int indexTabDadosAtual = tabControlDados.SelectedIndex;
            int indexTabLateralAtual = tabControlLateral.SelectedIndex;

            if (indexTabDadosAtual == 1)
            {
                valido = true;
                if (valido == true)
                {
                    ellipsePage1.Fill = new SolidColorBrush(Colors.DarkRed);
                    ellipsePage2.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipsePage3.Fill = new SolidColorBrush(Colors.Transparent);

                    borderBtnProximo.IsEnabled = true;
                }
            }
            else if (indexTabDadosAtual == 2)
            {
                valido = true;
                if (valido == true)
                {
                    ellipsePage1.Fill = new SolidColorBrush(Colors.Transparent);
                    ellipsePage2.Fill = new SolidColorBrush(Colors.DarkRed);
                    ellipsePage3.Fill = new SolidColorBrush(Colors.Transparent);
                }
            }

            if (indexTabDadosAtual < tabControlDados.Items.Count + 1)
            {
                tabControlDados.SelectedIndex = indexTabDadosAtual - 1;
                tabControlLateral.SelectedIndex = indexTabLateralAtual - 1;
                if (indexTabDadosAtual == 1)
                {
                    borderBtnVoltar.Visibility = Visibility.Collapsed;
                }
                if (indexTabDadosAtual == 2)
                {
                    borderBtnProximo.Visibility = Visibility.Visible;
                    borderBtnSalvar.Visibility = Visibility.Collapsed;
                }
            }
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            TelaInicio telaInicio = new();
            Serializador serializador = new();
            List<InformacoesPessoais> informacoes = new();
            SalvarBD salvarBD = new();
            informacoes.Add(informacoesPessoais);


            serializador.SerializarPessoa(informacoes);

            salvarBD.SalvarDadosPessoais(informacoesPessoais);

            FinalizarRegistroDeDados();
        }

        private void btnAdicionarTelefone_Click(object sender, RoutedEventArgs e)
        {
            ValidadorTelefones();
            dgTelefones.ItemsSource = null;
            dgTelefones.ItemsSource = informacoesPessoais.Telefones;
            if (informacoesPessoais.Telefones.Count > 0)
                borderBtnProximo.IsEnabled = true;
        }
        private void btnAdicionarEndereco_Click(object sender, RoutedEventArgs e)
        {
            ValidadorEnderecos();
            dgEnderecos.ItemsSource = null;
            dgEnderecos.ItemsSource = informacoesPessoais.Enderecos;
            if (informacoesPessoais.Enderecos.Count > 0)
                borderBtnSalvar.IsEnabled = true;
        }

        private void btnEditarTelefoneRegistrado_Click(object sender, RoutedEventArgs e)
        {
            if (informacoesPessoais.Telefones.Count > 0)
            {
                dgTelefones.IsReadOnly = false;
                btnEditarTelefoneRegistrado.Visibility = Visibility.Collapsed;
                btnPararEditarTelefoneRegistrado.Visibility = Visibility.Visible;
            }
        }
        private void btnPararEditarTelefoneRegistrado_Click(object sender, RoutedEventArgs e)
        {
            dgTelefones.IsReadOnly = true;
            btnPararEditarTelefoneRegistrado.Visibility = Visibility.Collapsed;
            btnEditarTelefoneRegistrado.Visibility = Visibility.Visible;
        }
        private void btnExcluirTelefone_Click(object sender, RoutedEventArgs e)
        {
            if (informacoesPessoais.Telefones.Count > 0)
            {
                PopUpExcluir popUpExcluir = new(informacoesPessoais.Telefones.Select(x => x.Id).ToList());
                popUpExcluir.Owner = this;
                popUpExcluir.ShowDialog();
                if (popUpExcluir._idDigitado != 0)
                {
                    informacoesPessoais.Telefones.Remove(informacoesPessoais.Telefones.Find(x => x.Id == popUpExcluir._idDigitado));
                    dgTelefones.ItemsSource = null;
                    dgTelefones.ItemsSource = informacoesPessoais.Telefones;
                }

            }
        }
        private void btnEditarEnderecoRegistrado_Click(object sender, RoutedEventArgs e)
        {
            if (informacoesPessoais.Enderecos.Count > 0)
            {
                dgEnderecos.IsReadOnly = false;
                btnEditarEnderecoRegistrado.Visibility = Visibility.Collapsed;
                btnPararEditarEnderecoRegistrado.Visibility = Visibility.Visible;
            }
        }
        private void btnPararEditarEnderecoRegistrado_Click(object sender, RoutedEventArgs e)
        {
            dgEnderecos.IsReadOnly = true;
            btnPararEditarEnderecoRegistrado.Visibility = Visibility.Collapsed;
            btnEditarEnderecoRegistrado.Visibility = Visibility.Visible;
        }
        private void btnExcluirEndereco_Click(object sender, RoutedEventArgs e)
        {
            if (informacoesPessoais.Enderecos.Count > 0)
            {
                PopUpExcluir popUpExcluir = new(informacoesPessoais.Enderecos.Select(x => x.Id).ToList());
                popUpExcluir.Owner = this;
                popUpExcluir.ShowDialog();
                if (popUpExcluir._idDigitado != 0)
                {
                    informacoesPessoais.Enderecos.Remove(informacoesPessoais.Enderecos.Find(x => x.Id == popUpExcluir._idDigitado));
                    dgEnderecos.ItemsSource = null;
                    dgEnderecos.ItemsSource = informacoesPessoais.Enderecos;
                }

            }
        }

        private bool ValidarCpf(string cpf)
        {
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
            {
                return false;
            }

            return true;
        }
        private bool ValidarNumero(string numero)
        {
            numero = new string(numero.Where(char.IsDigit).ToArray());

            if (numero.Length != 9)
            {
                return false;
            }

            return true;
        }

        private void ValidadorDadosPessoais()
        {

            if (!string.IsNullOrEmpty(txbNomeCompleto.Text) && !string.IsNullOrEmpty(txbCPF.Text))
            {
                if (!ValidarCpf(txbCPF.Text))
                {
                    MessageBox.Show("Digite um CPF válido!");
                    return;
                }

                informacoesPessoais.CPF = txbCPF.Text;
                informacoesPessoais.NomeCompleto = txbNomeCompleto.Text;

                informacoesPessoais.RG = !string.IsNullOrEmpty(txbRG.Text) ? txbRG.Text : null;
                DateTime dateTime = new();
                informacoesPessoais.DataNascimento = DateTime.TryParse(dpkDataNascimento.Text, out DateTime data) ? data : dateTime;
                informacoesPessoais.Idade = DateTime.Now.Year - informacoesPessoais.DataNascimento.Year;
                if (DateTime.Now.Month <= informacoesPessoais.DataNascimento.Month)
                {
                    if (DateTime.Now.Month == informacoesPessoais.DataNascimento.Month)
                    {
                        if (DateTime.Now.Day < informacoesPessoais.DataNascimento.Day)
                        {
                            informacoesPessoais.Idade--;
                        }
                    }
                    else
                    {
                        informacoesPessoais.Idade--;
                    }
                }


                if (!string.IsNullOrEmpty(cbxSexo.Text) && cbxSexo.Text != "Outro")
                {
                    informacoesPessoais.Sexo = cbxSexo.Text;
                }
                else if (!string.IsNullOrEmpty(txbSexoOutro.Text))
                {
                    informacoesPessoais.Sexo = txbSexoOutro.Text;
                }
                else if (cbxSexo.Text == "Outro")
                {
                    MessageBox.Show("Insira um Sexo");
                    return;
                }

                informacoesPessoais.Profissao = !string.IsNullOrEmpty(txbProfissao.Text) ? txbProfissao.Text : null;
                informacoesPessoais.Escolaridade = !string.IsNullOrEmpty(cbxEscolaridade.Text) ? cbxEscolaridade.Text : null;

                if (!string.IsNullOrEmpty(cbxEscolaridade.Text) && cbxEscolaridade.Text != "Outro")
                {
                    informacoesPessoais.Escolaridade = cbxEscolaridade.Text;
                }
                else if (!string.IsNullOrEmpty(txbEscolaridadeOutro.Text))
                {
                    informacoesPessoais.Escolaridade = txbEscolaridadeOutro.Text;
                }
                else if (cbxEscolaridade.Text == "Outro")
                {
                    MessageBox.Show("Insira uma Escolaridade");
                    return;
                }

                valido = true;
                borderBtnVoltar.Visibility = Visibility.Visible;


            }
            else if (string.IsNullOrEmpty(txbNomeCompleto.Text))
            {
                MessageBox.Show("Preencha o Nome");
            }
            else if (string.IsNullOrEmpty(txbCPF.Text))
            {
                MessageBox.Show("Preencha o CPF");
            }
        }
        private void ValidadorTelefones()
        {
            if (!string.IsNullOrEmpty(txbNumero.Text))
            {
                if (!ValidarNumero(txbNumero.Text))
                {
                    MessageBox.Show("Digite um Numero válido!");
                    return;
                }
                Telefone telefone = new();

                telefone.Numero = txbNumero.Text;
                telefone.DDD = txbDDD.Text;
                telefone.Operadora = txbOperadora.Text;
                telefone.Id = informacoesPessoais.GetValor();
                informacoesPessoais.AdicionarValor();
                informacoesPessoais.Telefones.Add(telefone);

                LimparTelefone();

            }
            else if (string.IsNullOrEmpty(txbNumero.Text))
            {
                MessageBox.Show("Preencha o Telefone");
            }
        }
        private void ValidadorEnderecos()
        {
            if (!string.IsNullOrEmpty(txbLogradouro.Text))
            {
                Endereco endereco = new();
                endereco.Logradouro = Regex.Replace(txbLogradouro.Text, @"\d+", "").Trim();
                endereco.Numero = Regex.Match(txbLogradouro.Text, @"\d+").Value;
                endereco.Id = informacoesPessoais.GetValorEndereco();
                informacoesPessoais.AdicionarValorEndereco();
                endereco.Complemento = txbComplemento.Text;
                endereco.Estado = cbxEstado.Text;
                endereco.Cidade = txbCidade.Text;
                endereco.Bairro = txbBairro.Text;

                informacoesPessoais.Enderecos.Add(endereco);

                LimparEndereco();
            }
            else if (string.IsNullOrEmpty(txbLogradouro.Text))
            {
                MessageBox.Show("Preencha o Logradouro");
            }
        }

        private void LimparDadosPessoais()
        {
            txbNomeCompleto.Text = null;
            txbCPF.Text = null;
            txbRG.Text = null;
            cbxSexo.Text = null;
            dpkDataNascimento.Text = null;
            txbIdade.Text = null;
            txbProfissao.Text = null;
            cbxEscolaridade.Text = null;
        }
        private void LimparTelefone()
        {
            txbNumero.Text = null;
            txbDDD.Text = null;
            txbOperadora.Text = null;
        }
        private void LimparEndereco()
        {
            txbLogradouro.Text = null;
            txbComplemento.Text = null;
            cbxEstado.Text = null;
            txbCidade.Text = null;
            txbBairro.Text = null;
        }

        private void PassarTab(int indexTabDadosAtual, int indexTabLateralAtual)
        {
            if (indexTabDadosAtual < tabControlDados.Items.Count - 1)
            {
                tabControlDados.SelectedIndex = indexTabDadosAtual + 1;
                tabControlLateral.SelectedIndex = indexTabLateralAtual + 1;

                if (indexTabDadosAtual == 1)
                {
                    borderBtnProximo.Visibility = Visibility.Collapsed;
                    borderBtnSalvar.Visibility = Visibility.Visible;
                }
            }
        }

        private void FinalizarRegistroDeDados()
        {

            tabControlDados.SelectedIndex = 0;
            tabControlLateral.SelectedIndex = 0;
            borderBtnSalvar.Visibility = Visibility.Collapsed;
            borderBtnVoltar.Visibility = Visibility.Collapsed;
            borderBtnProximo.Visibility = Visibility.Visible;
            dgEnderecos.ItemsSource = null;
            dgTelefones.ItemsSource = null;
            informacoesPessoais = new();
            LimparDadosPessoais();

            ellipsePage1.Fill = new SolidColorBrush(Colors.DarkRed);
            ellipsePage2.Fill = new SolidColorBrush(Colors.Transparent);
            ellipsePage3.Fill = new SolidColorBrush(Colors.Transparent);

        }

    }
}   