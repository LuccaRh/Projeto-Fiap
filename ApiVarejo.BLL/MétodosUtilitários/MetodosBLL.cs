using ApiVarejo.MOD;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiVarejo.BLL.MétodosUtilitários
{
    public class MetodosBLL
    {
        //Impedir que o tamanho da string passe de um valor, que é o colocado pelo banco de dados
        public void ExcessaoTamanho(Usuário usuario, string property, int tamanho)
        {
            PropertyInfo propriedade = usuario.GetType().GetProperty(property);
            var valor = propriedade.GetValue(usuario, null);
            if (valor == null) { return; }
            if (valor.ToString().Length > tamanho)
            {
                string propriedadeMaiusculo = char.ToUpper(property[0]) + property.Substring(1);
                string erro = String.Format("{0} do usuário muito grande.", propriedadeMaiusculo);
                throw new Exception(erro);
            }
        }
        //Impedir que string seja nula, ou que o seu tamanho seja muito grande
        public void ExcessaoNullTamanho(Usuário usuario, string property, int tamanho)
        {
            PropertyInfo propriedade = usuario.GetType().GetProperty(property);
            var valor = propriedade.GetValue(usuario, null);
            if (valor == null | valor == "")
            {
                string erro = String.Format("Por favor inserir {0} do usuário.", property);
                throw new Exception(erro);
            }
            if (valor.ToString().Length > tamanho)
            {
                string propriedadeMaiusculo = char.ToUpper(property[0]) + property.Substring(1);
                string erro = String.Format("{0} do usuário muito grande.", propriedadeMaiusculo);
                throw new Exception(erro);
            }
        }
        public void StringApenasComLetras(string nome)
        {
            if (nome == null)
            {
                return;
            }
            if (!Regex.IsMatch(nome, @"^[a-zA-Z\s]+$"))
            {
                throw new Exception("Utilizar apenas letras no nome por favor.");
            }
        }
        //Arrumar data de nascimento, apenas liberando datas no formato certo
        public string CorreçãoDataDeNascimento(string dataDeNascimento)
        {
            if (dataDeNascimento == null)
            {
                return null;
            }
            bool validação = dataDeNascimento.All(c => Char.IsDigit(c) || c == '-');
            if (!validação)
            {
                throw new Exception("Utilizar apenas números e \"-\" para digitar a sua data de nascimento por favor. (xx-xx-xxxx)");
            }
            //Remove tudo que não seja número da string
            dataDeNascimento = new string(dataDeNascimento.Where(char.IsDigit).ToArray());
            int size = dataDeNascimento.Length;
            if (size != 8)
            {
                throw new Exception("Utilizar a quantidade certa de número para a data de nascimento por favor. (xx-xx-xxxx)");
            }
            //Verificação de data válida e formatação certa xx-xx-xxxx
            int dia = int.Parse(dataDeNascimento.Substring(0, 2));
            if (dia > 31) { throw new Exception("Utilize um dia válido por favor."); }
            int mes = int.Parse(dataDeNascimento.Substring(2, 2));
            if (mes > 12) { throw new Exception("Utilize um mês válido por favor."); }
            int ano = int.Parse(dataDeNascimento.Substring(4));
            if (ano > 2023 | ano < 1907) { throw new Exception("Utilize um ano válido por favor."); }
            dataDeNascimento = dia + "-" + mes + "-" + ano;
            return dataDeNascimento;
        }
        //Arrumar cpf, apenas liberando cpfs no formato certo
        public string CorreçãoCPF(string cpf)
        {
            if (cpf == null)
            {
                return null;
            }
            bool validação = cpf.All(c => Char.IsDigit(c) || c == '/');
            if (!validação)
            {
                throw new Exception("Utilizar apenas números e \"/\" para digitar o cpf por favor.");
            }
            //Remove tudo que não seja número da string
            cpf = new string(cpf.Where(char.IsDigit).ToArray());
            int size = cpf.Length;
            if (size != 11)
            {
                throw new Exception("Utilizar a quantidade certa de números de um cpf (11) por favor.");
            }
            //Transformar para formatação usual de cpf xxxxxxxxx/xx
            cpf = cpf.Substring(0, size - 2) + "/" + cpf.Substring(size - 2);
            return cpf;
        }
        //Arrumar telefones, apenas liberando telefones no formato certo
        public string CorreçãoTelefone(string telefone)
        {
            
            if (telefone == null)
            {
                return null;
            }
            bool validação = telefone.All(c => Char.IsDigit(c) || Char.IsWhiteSpace(c) || c == '(' || c == ')' || c == '-');
            if (!validação) 
            {
                throw new Exception("Utilizar apenas números, ou formatação usual do telefone por favor.");
            }
            //Remove tudo que não seja número da string
            telefone = new string(telefone.Where(char.IsDigit).ToArray());
            int size = telefone.Length;

            //Conferir se é celular ou telefone
            if (size == 11)
            {
                if (telefone[2] != '9')
                {
                    throw new Exception("Não possui a formatação certa para telefone de celular");
                }
            }
            else if (size == 10)
            {
                if (telefone[2] == '9')
                {
                    throw new Exception("Não possui a formatação certa para telefone de casa");
                }
            }
            else
            {
                throw new Exception("Utilizar a quantidade certa de números de um celular/telefone (11/10) por favor.");
            }
            //Transformar para formatação usual de telefone (xx) xxxxx-xxxx
            string um = telefone.Substring(0, 1);
            string dois = telefone.Substring(1, 1);
            string tres = string.Format("({0}{1}) {2}", um, dois, telefone.Substring(2));
            int lenght = tres.Length;
            telefone = tres.Substring(0, lenght - 4) + "-" + tres.Substring(lenght - 4);
            return telefone;
        }
    }
}
