using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Brokers;

namespace Contact.Service
{
    internal class PhoneBookService
    {
        //faqat o'qish uchun ishlatiladigan o'zgaruvchi qisman
        private readonly FileBroker _fileBroker;
        public PhoneBookService()
        {
            _fileBroker = new FileBroker("contacts.json");
        }

        //Kontact qo'shish
        public void AddContact()
        {
            try
            {
                Console.Write("Ismni kiriting:");
                string name = Console.ReadLine();
                Console.Write("Telefon raqamini kiriting:");
                string phoneNumber = Console.ReadLine();
                Console.Write("Emailni kiriting:");
                string email= Console.ReadLine();

                var newContact = new ContactsInfo { Name = name, Phone = phoneNumber, Email = email };
                var contacts = _fileBroker.ReadContacts();
                contacts.Add(newContact);
                _fileBroker.WriteContacts(contacts);
                Console.WriteLine("Kontakt muaffaqiyatli qo'shildi.");

            }catch(Exception exp)
            {
                LoggingBroker.LogError(exp.Message);
            }
        }
        
        //Kontaktni tahrirlash
        public void EditContact()
        {
            try
            {
                Console.Write("Tahrirlanadigan kontakt ismini kiriting:");
                string name = Console.ReadLine();
                var contacts = _fileBroker.ReadContacts();
                var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (contact != null)
                {
                    Console.Write("Yangi telefon raqam kiriting:");
                    contact.Phone = Console.ReadLine();
                    Console.Write("Yangi email kiriting:");
                    contact.Email = Console.ReadLine();

                    _fileBroker.WriteContacts(contacts);
                    Console.WriteLine("Kontakt muaffaqiyatli tahrirlandi.");
                }
                else
                    Console.WriteLine("Kontakt topilmadi.");
            }
            catch (Exception exp)
            {
                LoggingBroker.LogError(exp.Message);
            }
        }

        //Kontaktni o'chirish
        public void DeleteContact()
        {
            try
            {
                Console.Write("O'chiriladigan kontaktning ismini kiriting:");
                string name = Console.ReadLine();
                var contacts = _fileBroker.ReadContacts();
                var contact = contacts.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (contact != null)
                {
                    contacts.Remove(contact);
                    _fileBroker.WriteContacts(contacts);
                    Console.WriteLine("Kontakt muaffaqiyatli o'chirildi.");
                }
                else
                    Console.WriteLine("Kontakt topilmadi.");
            }
            catch(Exception exp)
            {
                LoggingBroker.LogError(exp.Message);
            }
        }

        //Hamma kontaktni ko'rish.
        public void ViewAllContact()
        {
            try
            {
                var contacts = _fileBroker.ReadContacts();
                Console.WriteLine("\nHamma kontaktlar:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Ism: {contact.Name}, Telefon: {contact.Phone}, Email: {contact.Email}");
                }
            }
            catch(Exception exp)
            {
                LoggingBroker.LogError(exp.Message);
            }
        }

        public void SearchContact()
        {
            try
            {
                Console.Write("Qidiriladigan kontaktni ismini kiriting:");
                string name = Console.ReadLine();

                var contacts = _fileBroker.ReadContacts();
                var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (contact != null)
                {
                    Console.WriteLine($"Ism: {contact.Name}, Telefon: {contact.Phone}, Email: {contact.Email}");
                }
                else
                    Console.WriteLine("Kontakt topilmadi.");
            }
            catch (Exception exp)
            {
                LoggingBroker.LogError(exp.Message);
            }
        }
    }
}
