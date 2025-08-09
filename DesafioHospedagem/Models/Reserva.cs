using System.Text;

namespace DesafioHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite.Capacidade < hospedes.Count)
            {
                throw new Exception($"A capacidade máxima da suite é {Suite.Capacidade}");
            }
            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            return DiasReservados < 10 ? Suite.ValorDiaria * DiasReservados : Suite.ValorDiaria * DiasReservados * 0.9M;
        }

        public decimal CalcularValorEstadia(decimal diaria)
        {
            return diaria * DiasReservados;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hóspedes: {ObterQuantidadeHospedes()}");
            sb.AppendLine($"Valor diária: {CalcularValorDiaria()}");
            sb.AppendLine($"Dias reservados: {DiasReservados}");
            sb.AppendLine($"Valor total da estadia: {CalcularValorEstadia(CalcularValorDiaria())}");
            return sb.ToString();
        }
    }
}