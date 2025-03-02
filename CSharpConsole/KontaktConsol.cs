using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Xml.Linq;

namespace CSharpConsole
{
    public class ContactManager
    {
        private List<Kontakter> _contacts = new List<Kontakter>();

        public async void AddContact(string Name, string SecondName, string Email, string PhoneNumber, string Street, string PostNumber, string City)
        {
            using (var context = new DataBase()) // Connect to the database
            {
                if (context.Contacts.Any(c => c.Epostadress == Email)) // Check for duplicates
                {
                    Console.WriteLine("A contact with this email already exists.");
                    return;
                }

                var newContact = new Kontakter(Name, SecondName, Email, PhoneNumber, Street, PostNumber, City);
                context.Contacts.Add(newContact);
                context.SaveChanges(); // Save to the database
                Console.WriteLine($"Kontakt skapad: {newContact}");
            }
        }

        //public void DisplayContacts()
        //{
        //    if (_contacts.Count == 0)
        //    {
        //        Console.WriteLine("Inga Kontakter");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Kontakt meny");
        //        var count = 1;
        //        foreach (var contact in _contacts)
        //        {
        //            Console.WriteLine("\n" + count);
        //            Console.WriteLine(contact);
        //            count += 1;
        //        }
        //    }
        //}
        public void DisplayContacts()
        {
            using (var context = new DataBase())
            {
                var contacts = context.Contacts.ToList();

                if (contacts.Count == 0)
                {
                    Console.WriteLine("Inga Kontakter");
                    return;
                }

                Console.WriteLine("Kontakt meny:");
                int count = 1;
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"\n{count}. {contact}");
                    count++;
                }
            }
        }
        public void Write(int numb)
        {
            //Console.WriteLine(numb);
            //    using (var context = new DataBase()) 
            //    {
            //        var contacts = context.Contacts.ToList();

            //        if(numb != contacts.Count)
            //        {
            //            return;
            //        }

            //        var Track = contacts[numb];

            //        if (Console.ReadLine() != null)
            //        {
            //            Track.Fornamn = Console.ReadLine();
            //            context.Contacts.Update(Track);
            //        }
            //        else if (Console.ReadLine() == null)
            //        { }
            //    }
        }


        public void Auto()
        {
            using (var context = new DataBase())
            {
                var contacts = context.Contacts.ToList();
                Console.WriteLine($"Loaded {contacts.Count} contacts from database.");
            }
        }
    }
}
