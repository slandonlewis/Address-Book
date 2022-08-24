using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few contacts
            Contact bob = new Contact()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@email.com",
                Address = "100 Some Ln, Testville, TN 11111"
            };
            Contact sue = new Contact()
            {
                FirstName = "Sue",
                LastName = "Jones",
                Email = "sue.jones@email.com",
                Address = "322 Hard Way, Testville, TN 11111"
            };
            Contact juan = new Contact()
            {
                FirstName = "Juan",
                LastName = "Lopez",
                Email = "juan.lopez@email.com",
                Address = "888 Easy St, Testville, TN 11111"
            };


            // Create an AddressBook and add some contacts to it
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

            // Try to addd a contact a second time
            addressBook.AddContact(sue);


            // Create a list of emails that match our Contacts
            List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };

            // Insert an email that does NOT match a Contact
            emails.Insert(1, "not.in.addressbook@email.com");


            //  Search the AddressBook by email and print the information about each Contact
            foreach (string email in emails)
            {
                try
                {
                    Contact contact = addressBook.GetByEmail(email);
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Name: {contact.FullName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Address: {contact.Address}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Contact not found");
                }
            }
        }
    }

    public class Contact
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Address;
        public string FullName { get { return $"{FirstName} {LastName}"; } }

    }

    public class AddressBook
    {
        public Dictionary<string, Contact> storedContacts = new Dictionary<string, Contact>();
        public void AddContact(Contact contact)
        {
            try
            {
                storedContacts.Add(contact.Email, contact);
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Contact with {contact.Email} already exists");
            }
        }
        public Contact GetByEmail(string email)
        {
            return storedContacts[email];
        }
    }

}
