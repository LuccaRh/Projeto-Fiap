using ApiVarejo.BLL.MétodosUtilitários;
using ApiVarejo.DAL;
using ApiVarejo.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVarejo.BLL
{
    public class VarejoBLL
    {
        private readonly VarejoDAL _VarejoDAL;
        private readonly MetodosBLL _MetodosBLL;
        public VarejoBLL() 
        {
            _VarejoDAL = new VarejoDAL();
            _MetodosBLL = new MetodosBLL();
        }
        public Usuário Cadastrar(Usuário usuario)
        {
            _MetodosBLL.StringApenasComLetras(usuario.nome);
            _MetodosBLL.ExcessaoNullTamanho(usuario, "nome", 200);
            _MetodosBLL.ExcessaoNullTamanho(usuario, "email", 500);
            usuario.telefone = _MetodosBLL.CorreçãoTelefone(usuario.telefone);
            usuario.cpf = _MetodosBLL.CorreçãoCPF(usuario.cpf);
            usuario.dataDeNascimento = _MetodosBLL.CorreçãoDataDeNascimento(usuario.dataDeNascimento);
            if (!_VarejoDAL.Cadastrar(usuario))
            {
                throw new Exception("Erro ao cadastrar.");
            }
            return usuario;
        }
        public List<Usuário> Listar(Usuário usuario)
        {
            return _VarejoDAL.Listar(usuario);
        }
        public bool Atualizar(Usuário usuario)
        {
            _MetodosBLL.StringApenasComLetras(usuario.nome);
            _MetodosBLL.ExcessaoTamanho(usuario, "nome", 200);
            _MetodosBLL.ExcessaoTamanho(usuario, "email", 500);
            usuario.telefone = _MetodosBLL.CorreçãoTelefone(usuario.telefone);
            usuario.cpf = _MetodosBLL.CorreçãoCPF(usuario.cpf);
            usuario.dataDeNascimento = _MetodosBLL.CorreçãoDataDeNascimento(usuario.dataDeNascimento);
            if (!_VarejoDAL.Atualizar(usuario))
            {
                throw new Exception("Erro ao atualizar.");
            }
            return true;
        }
        public bool Deletar(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Apenas valores positivos");
            }
            if (!_VarejoDAL.Deletar(id))
            {
                throw new Exception("Erro ao atualizar.");
            }
            return true;
        }
    }
}