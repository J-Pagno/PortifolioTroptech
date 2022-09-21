namespace Projeto_15_06_Sistema_de_Emails
{
    public class QuestionEmail : Email
    {
        public bool WasAnswered
        {
            get { return this._wasAnswered; }
            set { this._wasAnswered = value; }
        }

        public QuestionEmail(string content) : base(content) { }

        public override string Display()
        {
            return $"============ Dúvida ============\n[ Número de Identificação ]: {this.Id}\n[ Pergunta ]: {this.Content}\n[ Respondido ]: {(this.WasAnswered ? "Sim" : "Não")}";
        }
    }
}
