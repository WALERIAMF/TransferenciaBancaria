using System;


namespace Transferencia_bancaria
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = Math.Abs(credito);
            this.Nome = nome;
        }

        public Conta(TipoConta tipoConta, double saldo, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("O saldo atual da conta de {0} é de R${1:F2}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += Math.Abs(valorDeposito);
            Console.WriteLine("O saldo atual da conta de {0} é de R${1:F2}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo  + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}
