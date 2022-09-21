namespace AgendaComArray
{
    public class AgendaItem
    {
        public string Name;
        public string Phone;
        public string Address;
        public string Profession;
        public static int peopleCounter;

        public AgendaItem(string name, string phone)
        {
            Name = name;
            Phone = phone;

            peopleCounter++;
        }

        public AgendaItem(string name, string phone, string address, string profession)
        {
            Name = name;
            Phone = phone;
            Address = address;
            Profession = profession;
            
            peopleCounter++;
        }
    }
}
