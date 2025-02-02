namespace CSharpConsole
{
    public class Kontakter
    {
        public string Fornamn { get; set; }
        public string Efternamn {  get; set; }
        public string Epostadress {  get; set; }
        public string Telefonnummer { get; set; }
        public string Gatuadress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }
        public Guid ID { get; private set; }

        public Kontakter(string Name, string SecondName, string Email, string PhoneNumber, string Street, string PostNumber, string City, Guid Id)
        {
            if(Id == Guid.Empty)
            {
                Fornamn = Name;
                Efternamn = SecondName;
                Epostadress = Email;
                Telefonnummer = PhoneNumber;
                Gatuadress = Street;
                Postnummer = PostNumber;
                Ort = City;
                ID = Guid.NewGuid();
            }
            else
            {
                Fornamn = Name;
                Efternamn = SecondName;
                Epostadress = Email;
                Telefonnummer = PhoneNumber;
                Gatuadress = Street;
                Postnummer = PostNumber;
                Ort = City;
                ID = Id;
            }

        }

        public override string ToString()
        {
            return $"Name: {Fornamn}, SecondName: {Efternamn}, Email: {Epostadress}, PhoneNumber: {Telefonnummer}, Street: {Gatuadress}, PostNumber: {Postnummer}, City: {Ort}, ID: {ID}";
        }
    }
}