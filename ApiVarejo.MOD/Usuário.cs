namespace ApiVarejo.MOD
{
    /*
    public class Endereço
    {
        public string? rua { get; set;}
        public string? numero{ get; set;}
        public string? cep { get; set;}
    }*/
    public class Usuário
    {
        /*public Endereço endereço;
        public Usuário() 
        { 
            endereço = new Endereço();
        }*/
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? telefone { get; set; }
        public string? dataDeNascimento { get; set; }
        public string? cpf { get; set; }
        public string? rua { get; set; }
        public string? numero { get; set; }
        public string? cep { get; set; }
        public int? id { get; set; }

    }
}