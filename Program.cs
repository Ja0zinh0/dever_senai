using System;
using System.Globalization;

namespace SistemaControleClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            bool continuar = true;

            Console.WriteLine("=======================================");
            Console.WriteLine("   SISTEMA DE CONTROLE DE CLIENTES");
            Console.WriteLine("=======================================");

            // ESTRUTURA DE REPETIÇÃO (while): permite cadastrar vários clientes seguidos.
            while (continuar)
            {
                Console.WriteLine("\nTipo de cliente:");
                Console.WriteLine("1 - Pessoa Física");
                Console.WriteLine("2 - Pessoa Jurídica");
                Console.Write("Escolha uma opção: ");

                string entrada = Console.ReadLine();
                int opcao;

                // ESTRUTURA CONDICIONAL + OPERADORES RELACIONAIS (==) E LÓGICOS (&&, ||)
                if (int.TryParse(entrada, out opcao) && (opcao == 1 || opcao == 2))
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Endereço: ");
                    string endereco = Console.ReadLine();

                    float valorCompra = LerValor("Valor da compra/serviço: R$ ");

                    // Variável declarada com o tipo da classe BASE: é isso que permite
                    // tratar Pessoa_Fisica e Pessoa_Juridica de forma polimórfica abaixo.
                    Clientes cliente;

                    if (opcao == 1)
                    {
                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();
                        Console.Write("RG: ");
                        string rg = Console.ReadLine();
                        cliente = new Pessoa_Fisica(nome, endereco, cpf, rg);
                    }
                    else
                    {
                        Console.Write("CNPJ: ");
                        string cnpj = Console.ReadLine();
                        Console.Write("Inscrição Estadual: ");
                        string ie = Console.ReadLine();
                        cliente = new Pessoa_Juridica(nome, endereco, cnpj, ie);
                    }

                    // CHAMADA POLIMÓRFICA: o C# decide em tempo de execução qual versão
                    // de Pagar_Imposto rodar, de acordo com o tipo real do objeto criado.
                    cliente.Pagar_Imposto(valorCompra);

                    Console.WriteLine("\n--------- RECIBO DO CLIENTE ---------");
                    Console.WriteLine(cliente); // também usa polimorfismo (ToString)
                    Console.WriteLine("--------------------------------------");
                }
                else
                {
                    Console.WriteLine("Opção inválida! Digite 1 ou 2.");
                }

                Console.Write("\nDeseja cadastrar outro cliente? (S/N): ");
                string resposta = Console.ReadLine();

                continuar = resposta != null && resposta.Trim().ToUpper() == "S";
            }

            Console.WriteLine("\nSistema encerrado. Até logo!");
        }

        // Método auxiliar com ESTRUTURA DE REPETIÇÃO (do-while) para validar a entrada
        // numérica antes de aceitá-la (evita o programa quebrar com texto inválido).
        static float LerValor(string mensagem)
        {
            float valor;
            bool valido;

            do
            {
                Console.Write(mensagem);
                string entrada = (Console.ReadLine() ?? "").Replace(",", ".");
                valido = float.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out valor)
                         && valor >= 0; // OPERADOR RELACIONAL

                if (!valido)
                    Console.WriteLine("Valor inválido! Digite um número maior ou igual a 0.");

            } while (!valido);

            return valor;
        }
    }
}
