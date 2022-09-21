namespace Projeto_15_06_Sistema_de_Emails
{
    public class AnswerEmail : Email
    {
        private int _emailQuestionId;

        public bool WasAnswered
        {
            get { return this._wasAnswered; }
            set { this._wasAnswered = value; }
        }

        public int EmailQuestionId
        {
            get => _emailQuestionId;
            private set => _emailQuestionId = value;
        }

        public AnswerEmail(string content, int questionId) : base(content)
        {
            WasAnswered = false;

            this.EmailQuestionId = questionId;

            ChangeQuestionEmailStatus(questionId);
        }

        private static bool ChangeQuestionEmailStatus(int id)
        {
            foreach (var questionEmail in Program.QuestionList)
            {
                if (questionEmail.Id == id)
                {
                    questionEmail.WasAnswered = true;

                    return true;
                }
            }

            Program.Warning("Id inexistente!");

            return false;
        }

        public override string Display()
        {
            return $"============ Resposta ============\n[ Identificação da dúvida ]: {this.EmailQuestionId}\n[ Número de Identificação ]: {this.Id}\n[ Dúvida ]: {GetQuestionById(this.EmailQuestionId)}\n[ Resposta ]: {this.Content}";
        }

        public static string GetQuestionById(int id)
        {
            foreach (var question in Program.QuestionList)
            {
                if (question.Id == id)
                    return question.Content;
            }

            return "Id inexistente!";
        }
    }
}
