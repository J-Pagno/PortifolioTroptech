namespace BancoSolution.WebAPI
{
    public class Resposta
    {
        public string Status { get; set; }
        public string Descricao { get; set; }

        public Resposta(string status, string descricao)
        {
            Status = status;
            Descricao = descricao;
        }
    }
}
