using System.ComponentModel.DataAnnotations;

namespace CSharpConsole
{
    public class Kontakter
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Fornamn { get; set; }
        public string Efternamn {  get; set; }
        public string Epostadress {  get; set; }
        public string Telefonnummer { get; set; }
        public string Gatuadress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }

        public Kontakter() { }
        public Kontakter(string Name, string SecondName, string Email, string PhoneNumber, string Street, string PostNumber, string City)
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
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Fornamn} {Efternamn}, Email: {Epostadress}, Phone: {Telefonnummer}, Address: {Gatuadress}, {Postnummer}, {Ort}";
        }
    }
}