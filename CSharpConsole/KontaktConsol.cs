using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace CSharpConsole
{
    public class ContactManager
    {
        private List<Kontakter> _contacts = new List<Kontakter>();

        public async void AddContact(string Name, string SecondName, string Email, string PhoneNumber, string Street, string PostNumber, string City, Guid Id)
        {
            var temp = _contacts.Any(contact => contact.ID == Id);
            if (temp == false)
            {
                var Kontakt = new Kontakter(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City, Id);
                _contacts.Add(Kontakt);
                //Console.WriteLine($"Kontakt skapad {Kontakt}");
            }
        }

        public void DisplayContacts()
        {
            if (_contacts.Count == 0)
            {
                Console.WriteLine("Inga Kontakter");
            }
            else
            {
                Console.WriteLine("Kontakt meny");
                var count = 1;
                foreach (var contact in _contacts)
                {
                    Console.WriteLine("\n" + count);
                    Console.WriteLine(contact);
                    count += 1;
                }
            }
        }
        public void Write(int numb)
        {
            if (numb >= 0 && numb < _contacts.Count) // ser till att input är giltight. med litte hjälp av AI
            {
                Kontakter selected = _contacts[numb];
                //Console.WriteLine(selected);
                var tracker = _contacts[numb].ID;
                string json = JsonSerializer.Serialize(selected);
                var Path = $@"D:\{tracker}_path.json";
                Console.WriteLine("Kontakt sparad i D:");
                File.WriteAllText(Path, json);
            }
            //d1afcd29-07e4-4158-8da6-3234db078b2e
            //foreach (var contact in _contacts)
            //{
            //    console.writeline(contact);
            //    string json = jsonserializer.serialize(contact);
            //    file.writealltext(@"d:\path.json", json);
            //}
            // skapad med hjälp av https://stackoverflow.com/questions/16921652/how-to-write-a-json-file-in-c
        }

        public void Auto()
        {
            string[] readText = Directory.GetFiles(@"D:\");
           

            foreach (var x in readText)
            {
               
               //Console.WriteLine(x.EndsWith("path.json"));
                if (x.EndsWith("path.json"))
                {
                    string finnal = File.ReadAllText(x);
                    //Console.WriteLine(finnal);

                    finnal = Regex.Replace(finnal, "Fornamn", "");
                    finnal = Regex.Replace(finnal, "Efternamn", "");
                    finnal = Regex.Replace(finnal, "Epostadress", "");
                    finnal = Regex.Replace(finnal, "Telefonnummer", "");
                    finnal = Regex.Replace(finnal, "Gatuadress", "");
                    finnal = Regex.Replace(finnal, "Postnummer", "");
                    finnal = Regex.Replace(finnal, "Ort", "");
                    finnal = Regex.Replace(finnal, "ID", "");
                    finnal = Regex.Replace(finnal, ":", "");
                    finnal = Regex.Replace(finnal, "\"", "");
                    finnal = Regex.Replace(finnal, "}", "");
                    finnal = Regex.Replace(finnal, "{", "");

                    List<string> result = finnal.Split(',').ToList();

                    string Name = result[0];
                    string SecondName = result[1];
                    string Email = result[2];
                    string PhoneNumber = result[3];
                    string Street = result[4];
                    string PostNumber = result[5];
                    string City = result[6];
                    //Console.WriteLine(result[7]);
                    Guid Id = new(result[7]);

                    AddContact(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City, Id);
                }
            }
            /*
            string readText = File.ReadAllText(@"D:\path.json");
            readText = Regex.Replace(readText, "Fornamn", "");
            readText = Regex.Replace(readText, "Efternamn", "");
            readText = Regex.Replace(readText, "Epostadress", "");
            readText = Regex.Replace(readText, "Telefonnummer", "");
            readText = Regex.Replace(readText, "Gatuadress", "");
            readText = Regex.Replace(readText, "Postnummer", "");
            readText = Regex.Replace(readText, "Ort", "");
            readText = Regex.Replace(readText, "ID", "");
            readText = Regex.Replace(readText, ":", "");
            readText = Regex.Replace(readText, "\"", "");
            readText = Regex.Replace(readText, "}", "");
            readText = Regex.Replace(readText, "{", "");

            List<string> result = readText.Split(',').ToList();

            string Name = result[0];
            string SecondName = result[1];
            string Email = result[2];
            string PhoneNumber = result[3];
            string Street = result[4];
            string PostNumber = result[5];
            string City = result[6];
            Console.WriteLine(result[7]);
            Guid Id = new(result[7]);
            
            AddContact(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City, Id);
            */
        }
    }
}
