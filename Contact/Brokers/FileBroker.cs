using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Contact.Brokers
{
    internal class FileBroker
    {
        //ContactsInfo sinfidan obyect oldim proplardan foydalanish uchun
        ContactsInfo Contacts= new ContactsInfo();

        //qiymat faqat constructor orqali o'rnatiladi va faqat o'qiladi bu fayl joylashuvi;
        private readonly string _filePath;

        //Constructor
        public FileBroker(string filePath)
        {
            _filePath = filePath;
        }

        //contactni o'qish uchun
        public List<ContactsInfo> ReadContacts()
        {
            if (!File.Exists(_filePath))
                return new List<ContactsInfo>();
            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<ContactsInfo>>(jsonData) ?? new List<ContactsInfo>();


        }
        public void WriteContacts(List<ContactsInfo> contacts)
        {
            var jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }

}
