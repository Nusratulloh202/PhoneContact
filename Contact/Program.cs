using Contact.Brokers;
using Contact.Service;

var phoneBookService = new PhoneBookService();
while (true)
{
    Console.WriteLine("\nTelefon kitobi dasturi:");
    Console.WriteLine("1. Yangi kontakt qo'shish");
    Console.WriteLine("2. Kontaktni tahrirlash");
    Console.WriteLine("3. Kontaktni o'chirish");
    Console.WriteLine("4. Barcha kontaktlarni ko'rish");
    Console.WriteLine("5. Kontaktni nomi bo'yicha qidirish");
    Console.WriteLine("6. Chiqish");
    Console.Write("Tanlovingizni kiriting: ");
    try
    {
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                phoneBookService.AddContact();
                break;
            case 2:
                phoneBookService.EditContact();
                break;
            case 3:
                phoneBookService.DeleteContact();
                break;
            case 4:
                phoneBookService.ViewAllContact();
                break;
            case 5:
                phoneBookService.SearchContact();
                break;
            case 6:
                Console.WriteLine("Chiqish...");
                return;
            default:
                Console.Write("Noto'g'ri tanlov. Qayta kiriting:");
                break;
        }
    }
    catch(Exception exp)
    {
        LoggingBroker.LogError(exp.Message);
    }
}
