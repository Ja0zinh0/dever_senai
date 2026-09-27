namespace SistemaControleClientes
{
    // HERANÇA: Pessoa_Fisica ESTENDE Clientes (herda Nome, Endereco e Pagar_Imposto).
    class Pessoa_Fisica : Clientes
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }

        public Pessoa_Fisica(string nome, string endereco, string cpf, string rg)
            : base(nome, endereco) // chama o construtor da classe base (Clientes)
        {
            Cpf = cpf;
            Rg = rg;
        }

        // Não sobrescreve Pagar_Imposto: exatamente como no diagrama, esta classe
        // não tem um método próprio, então herda o comportamento de Clientes.

        public override string ToString()
        {
            return base.ToString() + $"\nCPF............: {Cpf}\nRG.............: {Rg}";
        }
    }
}
