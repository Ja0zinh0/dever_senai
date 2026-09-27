namespace SistemaControleClientes
{
    // HERANÇA: Pessoa_Juridica também ESTENDE Clientes.
    class Pessoa_Juridica : Clientes
    {
        public string Cnpj { get; set; }
        public string Ie { get; set; }

        public Pessoa_Juridica(string nome, string endereco, string cnpj, string ie)
            : base(nome, endereco)
        {
            Cnpj = cnpj;
            Ie = ie;
        }

        // POLIMORFISMO: exatamente como no diagrama, esta classe TEM seu próprio
        // Pagar_Imposto, que substitui (override) o da classe base com outra regra.
        public override void Pagar_Imposto(float v)
        {
            valor = v;
            valor_imposto = valor * 0.08f; // alíquota de exemplo: 8% (ajuste como preferir)
            total = valor + valor_imposto;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCNPJ...........: {Cnpj}\nInscr. Estadual: {Ie}";
        }
    }
}
