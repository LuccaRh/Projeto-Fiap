using ApiVarejo.DAL.Utilitários;
using ApiVarejo.MOD;
using Dapper;

namespace ApiVarejo.DAL
{
    public class VarejoDAL
    {
        public readonly MétodosDAL _MétodoDAL;
        public VarejoDAL() 
        {
            _MétodoDAL = new MétodosDAL();
        }
        public bool Cadastrar(Usuário usuario)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = _MétodoDAL.StringCadastro();
            connection.Execute(query, usuario);
            return true;
        }
        //Procura de usuario por nome ou email
        public List<Usuário> Listar(Usuário usuario)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = "SELECT * FROM SiteVarejoFiap.dbo.Varejo";
            bool filtragem = false;
            //query = _MétodoDAL.StringListagem(usuario, "nome", ref filtragem, query);
            //query = _MétodoDAL.StringListagem(usuario, "email", ref filtragem, query);
            query = _MétodoDAL.StringListagem2(usuario, ref filtragem, query);
            var lista = connection.Query<Usuário>(query, new { nome = "%"+usuario.nome+"%",email = "%" + usuario.email + "%",telefone =  "%" + usuario.telefone + "%", dataDeNascimento = "%" + usuario.dataDeNascimento + "%",cpf = "%" + usuario.cpf + "%" }) as List<Usuário>;
            return lista;
        }
        public bool Atualizar(Usuário usuario)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = _MétodoDAL.StringAtualizar();
            return connection.Execute(query, usuario) > 0;
        }
        public bool Deletar(int id)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = @"DELETE FROM SiteVarejoFiap.dbo.Varejo WHERE Id = @id";
            return connection.Execute(query, new { Id = id }) > 0;
        }
        public bool VerificarEmail(string email)
        {
            using var connection = new BdConnection().AbrirConexao();
            string query = "SELECT Email FROM SiteVarejoFiap.dbo.Varejo";
            var lista = connection.Query<String>(query) as List<String>;
            return lista.Contains(email);
        }
    }
}