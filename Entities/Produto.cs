namespace ApiLojaEletronicos.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = "";
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public string Marca { get; set; } = "";
        public DateTime DataCadastro { get; set; }
        public bool isDelete { get; set; }

        public Produto()
        {
            isDelete = false;
        }

        public void Update(string nome, double valor, int quantidade, string marca)
        {
            Nome = nome;
            Valor = valor;
            Marca = marca;
            Quantidade = quantidade;
        }
        public void Delete()
        {
            isDelete = true;
        }
    }
}
