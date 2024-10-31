using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.ActiveDirectory;
using System.Security.RightsManagement;
using Microsoft.Xaml.Behaviors.Media;
using System.Windows.Resources;

namespace JaneladeCadastro
{
    public class InformacoesPessoais
    {
        public int Id { get; set; } = 1;
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
        public string Escolaridade { get; set; }
        public List<Endereco> Enderecos { get; set; } = new();
        public List<Telefone> Telefones { get; set; } = new();

        private int _idTelefone { get; set; } = 1;
        public void AdicionarValor()
        {
            _idTelefone++;
        }
        public int GetValor()
        {
            return _idTelefone;
        }

        private int _idEndereco { get; set; } = 1;
        public void AdicionarValorEndereco()
        {
            _idEndereco++;
        }
        public int GetValorEndereco()
        {
            return _idEndereco;
        }

    }

    public class Endereco
    {

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

    }

    public class Telefone
    {

        public int Id { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public string Operadora { get; set; }

    }

    
}
