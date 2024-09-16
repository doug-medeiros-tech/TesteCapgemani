using System.Globalization;

namespace Questao1
{
    public class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Titular { get; set; }

        private double _saldo;
        
        public double ConsultarSaldo()
        {
            return _saldo;
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            Numero = numero;
            Titular = titular;
            _saldo = depositoInicial;
        }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
            _saldo = 0;
        }

        public void Deposito(double quantia)
        {
            _saldo += quantia;
        }
        public void Saque(double quantia)
        {
            _saldo -= (quantia + 3.50);
        }
    }
}
