using System.Numerics;

namespace CSharpConsole
{
    class Program
    {
        static void Main()
        {

            var manager = new ContactManager();
            manager.Auto();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nKontakt Meny");
                Console.WriteLine("Skriv 1 for att skapa Kontakt");
                Console.WriteLine("Skriv 2 for att see Kontakter");
                string Input = Console.ReadLine();

                if (Input == "1")
                {
                    Console.Write("Enter name: ");
                    string Name = Console.ReadLine();

                    Console.Write("Skriv in dit Efternamn: ");
                    string SecondName = Console.ReadLine();

                    Console.Write("Skriv in din E-postadress: ");
                    string Email = Console.ReadLine();

                    Console.Write("Enter phone number: ");
                    string PhoneNumber = Console.ReadLine();

                    Console.Write("Skriv in din gatuadress: ");
                    string Street = Console.ReadLine();

                    Console.Write("Skriv in din postnummer: ");
                    string PostNumber = Console.ReadLine();

                    Console.Write("Skriv in din Ort: ");
                    string City = Console.ReadLine();

                    Console.WriteLine("Kontakt skapad " + Name + ", " + SecondName);
                    manager.AddContact(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City, Guid.Empty);
                }
                else if (Input == "2")
                {
                    manager.Auto();
                    manager.DisplayContacts();
                    Console.WriteLine("\nSkriv in numret för att skapa fil");
                    Console.WriteLine("N För att gå tillbacka");
                    Input = Console.ReadLine();
                    if (Input == "N" || Input == "n" || !int.TryParse(Input, out _))
                    { }
                    else
                    {
                        int x = Int32.Parse(Input);
                        x -= 1;
                        manager.Write(x);
                    }
                }
                else if (Input == "3")
                {
                    //manager.Write();
                }
                else if (Input == "4")
                {
                    
                }

            }
        }
    }
}
