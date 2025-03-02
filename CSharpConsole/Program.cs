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
                    manager.AddContact(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City);
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
                        Console.WriteLine("Skriv 1 för att att edit");
                        Console.WriteLine("N För att gå tillbacka");
                        Input = Console.ReadLine();
                        using (var context = new DataBase())
                        {
                            var contacts = context.Contacts.ToList();
                            if (!int.TryParse(Input, out _))
                            {
                                Console.WriteLine("run");
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
                                Console.Write("\nEfternamn: ");
                                Input = Console.ReadLine();
                                if (Input != "")
                                {
                                    Track.Efternamn = Input;
                                    context.Contacts.Update(Track);
                                    context.SaveChanges();
                                }
                                Console.Write("\nEpostadress: ");
                                Input = Console.ReadLine();
                                if (Input != "")
                                {
                                    Track.Epostadress = Input;
                                    context.Contacts.Update(Track);
                                    context.SaveChanges();
                                }
                                Console.Write("\nTelefonnummer: ");
                                Input = Console.ReadLine();
                                if (Input != "")
                                {
                                    Track.Telefonnummer = Input;
                                    context.Contacts.Update(Track);
                                    context.SaveChanges();
                                }
                                Console.Write("\nGatuadress: ");
                                Input = Console.ReadLine();
                                if (Input != "")
                                {
                                    Track.Gatuadress = Input;
                                    context.Contacts.Update(Track);
                                    context.SaveChanges();
                                }
                                Console.Write("\nPostnummer: ");
                                Input = Console.ReadLine();
                                if (Input != "")
                                {
                                    Track.Postnummer = Input;
                                    context.Contacts.Update(Track);
                                    context.SaveChanges();
                                }
                                Console.Write("\nOrt: ");
                                Input = Console.ReadLine();
                                if (Input != "")
                                {
                                    Track.Ort = Input;
                                    context.Contacts.Update(Track);
                                    context.SaveChanges();
                                }
                            }
                        }
                    }
                }
                else if (Input == "3")
                {
                    //manager.Write();
                }
                else if (Input == "4")
                {
                    using (var context = new DataBase())
                    {

                        var users = context.Table2.ToList();

                        Console.WriteLine(" skriv 1 för att see konton. 2 för att lägga till konto");
                        Input = Console.ReadLine();
                        if (Input == "1")
                        {
                            int count = 0;
                            foreach (var contact in users)
                            {
                                Console.WriteLine($"Name: {contact.Name}");
                                count++;
                            }
                        }
                        if (Input == "2")
                        {
                            Console.WriteLine("Skriv namnet av kontot:");
                            var TheName = Console.ReadLine();
                            var NewUser = new Table2(TheName);
                            context.Table2.Add(NewUser);
                            context.SaveChanges();
                        }
                        

                        

         

                   

                        
                        //if (!int.TryParse(Input, out _))
                        //{
                        //    Console.WriteLine("run");
                        //}
                        //else if (Input == "1")
                        //{
                        //    Console.Write("Lämna tom on du inte vill ändra");
                        //    var Track = users[x]; // ✅ Select from Table2 instead of Contacts

                        //    Console.Write("\nNamn: ");
                        //    Input = Console.ReadLine();
                        //    if (!string.IsNullOrWhiteSpace(Input)) // ✅ Correct condition
                        //    {
                        //        Track.Name = Input;
                        //        context.Table2.Update(Track); // ✅ Update the Table2 record
                        //        context.SaveChanges(); // ✅ Save the changes
                        //    }
                        //}
                    }
                }

            }
        }
    }
}
