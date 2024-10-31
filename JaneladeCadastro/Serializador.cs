using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlzEx.Standard;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Windows;

namespace JaneladeCadastro
{
    public class Serializador
    {
        #region Serializador
        private static JObject SerializarListaInformacoesPessoais(List<InformacoesPessoais> informacoesPessoais)
            {
            JArray jInformacoesPessoais = new();

            foreach(InformacoesPessoais informacoes in informacoesPessoais)
                jInformacoesPessoais.Add(SerializarInformacoesPessoais(informacoes));

            JObject jInformacoes = new();

            jInformacoes["Informacoes"] = jInformacoesPessoais;

            return jInformacoes;
        }
        private static JObject SerializarInformacoesPessoais(InformacoesPessoais informacaoPessoal)
        {
            JObject jInformacoesPessoais = new();

            jInformacoesPessoais["ID"] = informacaoPessoal.Id;
            jInformacoesPessoais["Nome Completo"] = informacaoPessoal.NomeCompleto;
            jInformacoesPessoais["CPF"] = informacaoPessoal.CPF;
            jInformacoesPessoais["RG"] = informacaoPessoal.RG;
            jInformacoesPessoais["Data de Nascimento"] = informacaoPessoal.DataNascimento;
            jInformacoesPessoais["Idade"] = informacaoPessoal.Idade;
            jInformacoesPessoais["Sexo"] = informacaoPessoal.Sexo;
            jInformacoesPessoais["Profissao"] = informacaoPessoal.Profissao;
            jInformacoesPessoais["Escolaridade"] = informacaoPessoal.Escolaridade;
            jInformacoesPessoais["Telefones"] = SerializarListaTelefones(informacaoPessoal.Telefones);
            jInformacoesPessoais["Enderecos"] = SerializarListaEnderecos(informacaoPessoal.Enderecos);


            return jInformacoesPessoais;
        }
        private static JArray SerializarListaTelefones(List<Telefone> telefones)
        {
            JArray jTelefone = new();

            foreach (Telefone telefone in telefones)
                jTelefone.Add(SerializarTelefones(telefone));

            return jTelefone;
        }
        private static JObject SerializarTelefones(Telefone telefones)
        {
            JObject jTelefone = new();

            jTelefone["ID"] = telefones.Id;
            jTelefone["DDD"] = telefones.DDD;
            jTelefone["Numero"] = telefones.Numero;
            jTelefone["Operadora"] = telefones.Operadora;

            return jTelefone;
        }
        private static JArray SerializarListaEnderecos(List<Endereco> enderecos)
        {
            JArray jEndereco = new();

            foreach (Endereco endereco in enderecos)
                jEndereco.Add(SerializarEnderecos(endereco));

            return jEndereco;
        }
        private static JObject SerializarEnderecos(Endereco enderecos)
        {
            JObject jEndereco = new();

            jEndereco["ID"] = enderecos.Id;
            jEndereco["Logradouro"] = enderecos.Logradouro;
            jEndereco["Numero"] = enderecos.Numero;
            jEndereco["Complemento"] = enderecos.Complemento;
            jEndereco["Bairro"] = enderecos.Bairro;
            jEndereco["Cidade"] = enderecos.Cidade;
            jEndereco["Estado"] = enderecos.Estado;

            return jEndereco;
        }
        public void SerializarPessoa(List<InformacoesPessoais> informacoesPessoais)
        {
            JObject jInformacoesPessoais = SerializarListaInformacoesPessoais(informacoesPessoais);

            string informacoes = jInformacoesPessoais.ToString();
            byte[] infos = Encoding.UTF8.GetBytes(informacoes);
            string caminho = @"C:\Users\4Sec\source\repos\JaneladeCadastro\JaneladeCadastro\Dados\Dados.json";

            string diretorio = Path.GetDirectoryName(caminho);
            if(!Directory.Exists(diretorio))
                Directory.CreateDirectory(diretorio);

            File.WriteAllBytes(caminho, infos);
            MessageBox.Show(informacoes + "\nNova pessoa registrada com Sucesso!");
        }
        #endregion

        #region Desserializador
        private static List<InformacoesPessoais> DesserializarListaInformacoesPessoais(JArray jArray)
        {
            List<InformacoesPessoais> informacoesPessoais = new();

            if (jArray != null)
                foreach(JObject jObject in jArray)
                {
                    InformacoesPessoais informacoes = DesserializarInformacoesPessoais(jObject);
                    informacoesPessoais.Add(informacoes);
                }

            return informacoesPessoais;
        }
        private static InformacoesPessoais DesserializarInformacoesPessoais(JObject jObject)
        {
            InformacoesPessoais informacoesPessoais = new()
            {
                Id = (int)jObject["ID"],
                NomeCompleto = (string)jObject["NomeCompleto"],
                CPF = (string)jObject["CPF"],
                RG = (string)jObject["RG"],
                DataNascimento = (DateTime)jObject["DataNascimento"],
                Idade = (int)jObject["Idade"],
                Sexo = (string)jObject["Sexo"],
                Profissao = (string)jObject["Profissao"],
                Escolaridade = (string)jObject["Escolaridade"],
                Telefones = DesserializarListaTelefones((JArray)jObject["Telefones"]),
                Enderecos = DesserializarListaEnderecos((JArray)jObject["Enderecos"])
            };

            return informacoesPessoais;
        }
        private static List<Telefone> DesserializarListaTelefones(JArray jArray)
        {
            List<Telefone> telefones = new();

            if(jArray != null)
                foreach(JObject jObject in jArray)
                {
                    Telefone telefone = DesserializarTelefones(jObject);
                    telefones.Add(telefone);
                }

            return telefones;
        }
        private static Telefone DesserializarTelefones(JObject jObject)
        {
            Telefone telefone = new()
            {
                Id = (int)jObject["ID"],
                Numero = (string)jObject["Numero"],
                DDD = (string)jObject["DDD"],
                Operadora = (string)jObject["Operadora"]
            };

            return telefone;
        }
        private static List<Endereco> DesserializarListaEnderecos (JArray jArray)
        {
            List<Endereco> enderecos = new();

            if(jArray != null)
                foreach(JObject jObject in jArray)
                {
                    Endereco endereco = DesserializarEnderecos(jObject);
                    enderecos.Add(endereco);
                }

            return enderecos;
        }
        private static Endereco DesserializarEnderecos (JObject jObject)
        {
            Endereco endereco = new()
            {
                Id = (int)jObject["ID"],
                Logradouro = (string)jObject["Logradouro"],
                Numero = (string)jObject["Numero"],
                Complemento = (string)jObject["Complemento"],
                Bairro = (string)jObject["Bairro"],
                Cidade = (string)jObject["Cidade"],
                Estado = (string)jObject["Estado"]
            };

            return endereco;
        }

        #endregion

    }
}
