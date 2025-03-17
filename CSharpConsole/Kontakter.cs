using System.ComponentModel.DataAnnotations;

namespace CSharpConsole
{
    public class Kontakter
    {
        [Key]
        public string ID { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn {  get; set; }
        public string Epostadress {  get; set; }
        public string Telefonnummer { get; set; }
        public string Gatuadress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }

        public Kontakter() { }
        public Kontakter(string Name, string SecondName, string Email, string PhoneNumber, string Street, string PostNumber, string City, string id)
        {
            Fornamn = Name;
            Efternamn = SecondName;
            Epostadress = Email;
            Telefonnummer = PhoneNumber;
            Gatuadress = Street;
            Postnummer = PostNumber;
            Ort = City;
            ID = id;
            
        }
        public override string ToString()
        {
            return $"Projektnumer: {ID} \nName: {Fornamn} \nStartdatum: {Efternamn} \nSlutdatum: {Epostadress} \nprojektansvarig: {Telefonnummer} \nKund: {Gatuadress} \nTjänst: {Postnummer} \nStatus: {Ort}";
        }
    }
}