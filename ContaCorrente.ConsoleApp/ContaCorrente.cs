using System.Collections;

namespace ContaCorrente.ConsoleApp
{
    internal class ContaCorrente
    {
        private int saldo;
        private int numero;
        private int limite;
        private bool ehEspecial;
        private ArrayList movimentacoes;



        public ContaCorrente(int saldo, int numero, int limite, bool ehEspecial, ArrayList movimentacoes)
        {
            this.saldo = saldo;
            this.numero = numero;
            this.limite = limite;
            this.ehEspecial = ehEspecial;
            this.movimentacoes = movimentacoes;
        }

        public void Sacar(int valor)
        {
            if (limite + saldo > valor)
            {
                this.saldo -= valor;
                this.movimentacoes.Add($"Saque no valor de {valor}");
            }
            else
                Console.WriteLine("Valor de saque maior que saldo mais limite");
        }

        public void Depositar(int valor)
        {
            this.saldo += valor;
            this.movimentacoes.Add($"Deposito no valor de {valor}");
        }

        public void VisualizarSaldo()
        {
            Console.WriteLine("Saldo: "+this.saldo);
        }

        public void VisualizarExtrato()
        {
            Console.WriteLine("Saldo: "+this.saldo);
            Console.WriteLine("Número da Conta: "+this.numero);
            Console.WriteLine("Limite da Conta: "+this.limite);
            Console.WriteLine("É especial: "+this.ehEspecial);
            Console.WriteLine("Movimentações");
            foreach (string movimentacao in this.movimentacoes)
            {
                Console.WriteLine(movimentacao);
            }
        }

        public void Transferencia(ContaCorrente conta, int valor)
        {
            if (limite + saldo > valor)
            {
                this.Sacar(valor);
                conta.Depositar(valor);
            }
            else
                Console.WriteLine("Valor de transferencia maior que saldo mais limite");
        }
    }
}