namespace Projeto_15_06_Sistema_de_Emails
{
    public abstract class Email : IEmailDisplay
    {
        private int _id = Program.CurrentEmailIdentification;

        private int _author;

        private string _content;

        protected bool _wasAnswered = false;

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

        public int Author
        {
            get => _author;
            set => _author = value;
        }

        public string Content
        {
            get => _content;
            protected set => _content = value;
        }

        protected Email(string content)
        {
            this._content = content;

            Program.CurrentEmailIdentification++;
        }

        public virtual string Display()
        {
            return "";
        }
    }
}
