using ApiVarejo.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiVarejo.DAL.Utilitários
{
    public class MétodosDAL
    {
        public string StringCadastro()
        {
            //loop para pegar o nome de cada propriedade do objeto, inserir elas no query
            string query = "INSERT INTO SiteVarejoFiap.dbo.Varejo (";
            Type tipo = typeof(Usuário);
            PropertyInfo[] propriedades = tipo.GetProperties();
            foreach (PropertyInfo propriedade in propriedades)
            {
                string nomePropriedade = propriedade.Name;
                if (nomePropriedade == "id") { continue; }
                string nomePropriedadeMaiusculo = char.ToUpper(nomePropriedade[0]) + nomePropriedade.Substring(1);
                query += String.Format(" {0},", nomePropriedadeMaiusculo);
            }

            query = query.TrimEnd(',') + ") VALUES (";
            foreach (PropertyInfo propriedade in propriedades)
            {
                string nomePropriedade = propriedade.Name;
                if (nomePropriedade == "id") { continue; }
                query += String.Format(" @{0},", nomePropriedade);
            }
            query = query.TrimEnd(',') + ")";
            return query;
        }
        public string StringListagem2(Usuário usuario, ref bool filtragem, string query)
        {
            PropertyInfo[] propriedades = usuario.GetType().GetProperties();
            foreach(PropertyInfo propriedade in propriedades)
            {
                var valor = propriedade.GetValue(usuario, null);
                if (valor != null)
                {
                    if (filtragem)
                    {
                        query += " AND";
                    }
                    else
                    {
                        query += " WHERE";
                        filtragem = true;
                    }
                    string nomePropriedade = propriedade.Name;
                    string nomePropriedadeMaiusculo = char.ToUpper(nomePropriedade[0]) + nomePropriedade.Substring(1);
                    query += String.Format(" {0} = @{1}", nomePropriedadeMaiusculo, nomePropriedade);
                }
            }
            return query;
        }
        /*
        public string StringListagem(Usuário usuario, string property, ref bool filtragem, string query)
        {
            PropertyInfo propriedade = usuario.GetType().GetProperty(property);
            var valor = propriedade.GetValue(usuario, null);
            if (valor != null)
            {
                if (filtragem)
                {
                    query += " AND";
                }
                else
                {
                    query += " WHERE";
                    filtragem = true;
                }
                string propriedadeMaiusculo = char.ToUpper(property[0]) + property.Substring(1);
                query += String.Format(" {0} = @{1}", propriedadeMaiusculo, property);
            }
            return query;
        }*/
        public string StringAtualizar()
        {
            string query = @"UPDATE SiteVarejoFiap.dbo.Varejo SET";
            Type tipo = typeof(Usuário);
            PropertyInfo[] propriedades = tipo.GetProperties();
            foreach (PropertyInfo propriedade in propriedades)
            {
                string nomePropriedade = propriedade.Name;
                if (nomePropriedade == "id") { continue; } 
                string nomePropriedadeMaiusculo = char.ToUpper(nomePropriedade[0]) + nomePropriedade.Substring(1);
                query += String.Format(" {0} = ISNULL(@{1},{2}),", nomePropriedadeMaiusculo, nomePropriedade, nomePropriedadeMaiusculo);
            }      
            query = query.TrimEnd(',');
            query += " WHERE Id = @id;";
            return query;
        }
    }
}