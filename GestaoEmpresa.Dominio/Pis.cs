namespace GestaoEmpresa.Dominio
{
    public class Pis
    {
        public const int MaxLength = 11;
        public string Numero { get; private set; }
        public Pis(string numero)
        {
            if (!Validar(numero)) throw new DomainException("Pis inválido");
            Numero = numero.ApenasNumeros();
        }

        public static bool Validar(string pis)
        {
            pis = pis.ApenasNumeros();
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }
    }
}
