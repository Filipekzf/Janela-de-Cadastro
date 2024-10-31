using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace JaneladeCadastro
{
    public class SalvarBD
    {
        private static string server = @"DESKTOP-3HGOB3E\SQLEXPRESS";
        private static string dataBase = "DadosPessoais";
        private static string user = @"dbo";

        private static string StrCon
        {
            get { return $"Data Source={server}; Integrated Security=true; TrustServerCertificate=True; Initial Catalog={dataBase}; User ID={user}"; }
        }

        public void SalvarDadosPessoais(InformacoesPessoais informacoesPessoais)
        {
            try
            {
                DateTime dt = new();

                using (SqlConnection cn = new(StrCon))
                {
                    cn.Open();

                    string addPessoa = "INSERT INTO DadosPessoais (NomeCompleto, CPF, RG, DataNascimento, Sexo, Profissão, Escolaridade) " +
                        "VALUES ( @NomeCompleto, @CPF, @RG, @DataNascimento, @Sexo, @Profissão, @Escolaridade)";
                    string addTelefone = "INSERT INTO Telefones (DDD, Telefone, Operadora, CPF) " +
                        "VALUES (@DDD, @Telefone, @Operadora, @CPF)";
                    string addEndereco = "INSERT INTO Enderecos (Logradouro, Numero, Complemento, Estado, Cidade, Bairro, CPF) " +
                        "VALUES (@Logradouro, @Numero, @Complemento, @Estado, @Cidade, @Bairro, @CPF)";


                    using (SqlCommand cmd = new(addPessoa, cn))
                    {
                        cmd.Parameters.AddWithValue("@NomeCompleto", informacoesPessoais.NomeCompleto);
                        cmd.Parameters.AddWithValue("@CPF", informacoesPessoais.CPF);
                        cmd.Parameters.AddWithValue("@RG",  !string.IsNullOrEmpty(informacoesPessoais.RG) ? informacoesPessoais.RG : "");
                        cmd.Parameters.AddWithValue("@DataNascimento", informacoesPessoais.DataNascimento != dt ? informacoesPessoais.DataNascimento : new DateTime(1753,01,01));
                        cmd.Parameters.AddWithValue("@Sexo", !string.IsNullOrEmpty(informacoesPessoais.Sexo) ? informacoesPessoais.Sexo : "");
                        cmd.Parameters.AddWithValue("@Profissão", !string.IsNullOrEmpty(informacoesPessoais.Profissao) ? informacoesPessoais.Profissao : "");
                        cmd.Parameters.AddWithValue("@Escolaridade", !string.IsNullOrEmpty(informacoesPessoais.Escolaridade) ? informacoesPessoais.Escolaridade : "");

                        cmd.ExecuteNonQuery();
                    }

                    foreach (Telefone telefone in informacoesPessoais.Telefones)
                    {
                        using (SqlCommand cmd = new(addTelefone, cn))
                        {
                            cmd.Parameters.AddWithValue("@DDD", !string.IsNullOrEmpty(telefone.DDD) ? telefone.DDD : "");
                            cmd.Parameters.AddWithValue("@Telefone", telefone.Numero);
                            cmd.Parameters.AddWithValue("@Operadora", !string.IsNullOrEmpty(telefone.Operadora) ? telefone.Operadora : "");
                            cmd.Parameters.AddWithValue("@CPF", informacoesPessoais.CPF);

                            cmd.ExecuteNonQuery();

                        }
                    }

                    foreach (Endereco endereco in informacoesPessoais.Enderecos)
                    {
                        using (SqlCommand cmd = new(addEndereco, cn))
                        {
                            cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                            cmd.Parameters.AddWithValue("@Numero", !string.IsNullOrEmpty(endereco.Numero) ? endereco.Numero : "");
                            cmd.Parameters.AddWithValue("@Complemento", !string.IsNullOrEmpty(endereco.Complemento) ? endereco.Complemento : "");
                            cmd.Parameters.AddWithValue("@Estado", !string.IsNullOrEmpty(endereco.Estado) ? endereco.Estado : "");
                            cmd.Parameters.AddWithValue("@Cidade", !string.IsNullOrEmpty(endereco.Cidade) ? endereco.Cidade : "");
                            cmd.Parameters.AddWithValue("@Bairro", !string.IsNullOrEmpty(endereco.Bairro) ? endereco.Bairro : "");
                            cmd.Parameters.AddWithValue("@CPF", informacoesPessoais.CPF);


                            cmd.ExecuteNonQuery();

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.Message);
            }
        }
    }
}
