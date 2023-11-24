using System.Drawing;
using System.Text.RegularExpressions;

namespace ApiLojaEletronicos.Entities
{
    public class Login
    {
        public Guid Id { get; set; }
        public string Usuario { get; set; } = "";
        public string Senha { get; set; } = "";

        public string Cpf { get; set; } = "";
        public string Tipo { get; set; } = "";
        public DateTime HoraCadastro { get; set; }
        public string DataNascimento { get; set; } = "";


        public void Update(string usuario, string senha, string cpf, string tipo, string dataNasc)
        {
            Usuario = usuario;
            Senha = senha;
            Tipo = tipo;
            Cpf = cpf;
            DataNascimento = dataNasc;
        }
        public void Delete()
        {

        }

    }
}
