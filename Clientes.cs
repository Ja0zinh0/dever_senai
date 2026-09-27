using System;

namespace SistemaControleClientes
{
    // Classe base do diagrama: representa as características comuns a todo cliente.
    // Conceito de POO: ABSTRAÇÃO (modela o que é "comum" a um cliente, sem se preocupar
    // ainda com as particularidades de Pessoa Física ou Jurídica).
    class Clientes
    {
        // ENCAPSULAMENTO: atributos "+" (públicos) do diagrama viram PROPRIEDADES em C#.
        public string Nome { get; set; }
        public string Endereco { get; set; }

        // ENCAPSULAMENTO: atributos "#" (protegidos) do diagrama viram campos "protected".
        // Só a própria classe e as classes filhas (Pessoa_Fisica/Pessoa_Juridica) acessam
        // esses valores diretamente; fora da hierarquia, só é possível alterá-los chamando
        // o método Pagar_Imposto.
        protected float valor;
        protected float valor_imposto;
        protected float total;

        public Clientes(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        // "virtual" permite que as classes filhas sobrescrevam este método (POLIMORFISMO).
        // Esta implementação padrão é a que a Pessoa_Fisica vai usar, pois ela não
        // sobrescreve Pagar_Imposto no diagrama.
        public virtual void Pagar_Imposto(float v)
        {
            valor = v;
            valor_imposto = valor * 0.05f; // alíquota de exemplo: 5% (ajuste como preferir)
            total = valor + valor_imposto;
        }

        // Sobrescrever ToString() também é POLIMORFISMO: cada classe filha completa
        // a exibição com seus próprios dados (CPF/RG ou CNPJ/IE).
        public override string ToString()
        {
            return $"Nome...........: {Nome}\n" +
                   $"Endereço.......: {Endereco}\n" +
                   $"Valor..........: {valor:C}\n" +
                   $"Valor Imposto..: {valor_imposto:C}\n" +
                   $"Total..........: {total:C}";
        }
    }
}
