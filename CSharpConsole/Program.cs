using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Xml.Linq;

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
                Console.WriteLine("\nProjekt meny");
                Console.WriteLine("Skriv 1 for att skapa project");
                Console.WriteLine("Skriv 2 for att see project");
                Console.WriteLine("Skriv 3 for att see konton");
                string Input = Console.ReadLine();

                if (Input == "1")
                {
                    Console.Write("Skriv namn: ");
                    string Name = Console.ReadLine();

                    Console.Write("Skriv startdatum: ");
                    string SecondName = Console.ReadLine();

                    Console.Write("Skriv slutdatum: ");
                    string Email = Console.ReadLine();

                    Console.Write("Vem som är projektansvarig: ");
                    string PhoneNumber = Console.ReadLine();

                    Console.Write("Välj kund: ");
                    string Street = Console.ReadLine();

                    Console.Write("Skriv in tjänst: ");
                    string PostNumber = Console.ReadLine();

                    Console.Write("Skriv status: ");
                    string City = Console.ReadLine();

                    Console.WriteLine("project skapad " + Name + ", " + SecondName);
                    manager.AddContact(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City);
                }
                else if (Input == "2")
                {
                    bool displayloop = true;
                    while (displayloop)
                    {

                        manager.Auto();
                        manager.DisplayContacts();
                        Console.WriteLine("\nSkriv in numret för att see projektet");
                        Console.WriteLine("N För att gå tillbacka");
                        Input = Console.ReadLine();

                        if (Input == "N" || Input == "n" || !int.TryParse(Input, out _))
                        {
                            displayloop = false;
                        }
                        else
                        {
                            int safekeep = 0;
                            bool editloop = true;
                            while (editloop)
                            {
                                int x = 0;
                                if (Input == null || Input == "")
                                {
                                    safekeep += 1;
                                    x = safekeep;
                                    Console.WriteLine("null");
                                }
                                else
                                {
                                    x = Int32.Parse(Input);
                                    Console.WriteLine("not null");
                                }
                                

                                x -= 1;
                                manager.DisplayContacts2(x);

                                Console.WriteLine("\nSkriv 1 för att att edit");
                                Console.WriteLine("N För att gå tillbacka");
                                Input = Console.ReadLine();
                                using (var context = new DataBase())
                                {
                                    var contacts = context.Contacts.ToList();
                                    if (!int.TryParse(Input, out _))
                                    {
                                        editloop = false;
                                    }
                                    else if (Input == "1")
                                    {
                                        Console.Write("Lämna tom on du inte vill ändra");
                                        var Track = contacts[x];
                                        Console.Write("\nNamn: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Fornamn = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        Console.Write("\nStartdatum: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Efternamn = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        Console.Write("\nSlutdatum: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Epostadress = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        Console.Write("\nProjektansvarig: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Telefonnummer = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        Console.Write("\nKund: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Gatuadress = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        Console.Write("\nTjänst: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Postnummer = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        Console.Write("\nStatus: ");
                                        Input = Console.ReadLine();
                                        if (Input != "")
                                        {
                                            Track.Ort = Input;
                                            context.Contacts.Update(Track);
                                            context.SaveChanges();
                                        }
                                        safekeep = x;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Input == "3")
                {
                    bool kontoloop = true;
                    while(kontoloop)
                    {
                        using (var context = new DataBase())
                        {

                            var users = context.Table2.ToList();

                            Console.WriteLine("\n skriv 1 för att see konton. 2 för att lägga till konto. N för att gå tillbacka");
                            Input = Console.ReadLine();
                            if (Input == "1")
                            {
                                int count = 0;
                                foreach (var contact in users)
                                {
                                    Console.WriteLine($"Name: {contact.Name}");
                                    count++;
                                }
                                continue;
                            }
                            if (Input == "2")
                            {
                                Console.WriteLine("Skriv namnet av kontot:");
                                var TheName = Console.ReadLine();
                                var NewUser = new Table2(TheName);
                                context.Table2.Add(NewUser);
                                context.SaveChanges();
                                continue;
                            }
                            if (Input != "1" && Input != "2")
                            {
                                kontoloop = false;
                            }
                        }
                    }

                }

            }
        }
    }
}
