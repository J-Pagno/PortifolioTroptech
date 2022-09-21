namespace Aula_06_06_Revisao
{
    public class TrackAndField
    {
        private string _firstName;

        private string _lastName;

        public Form Form { get; set; }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
