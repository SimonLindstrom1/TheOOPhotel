using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOOPhotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hej! Vad är ditt för och efternamn?");
            string name = Console.ReadLine();

            Console.Write("Ange din Epost: ");
            string email = Console.ReadLine();

            Console.Write("Ange ditt telefonnummer: ");
            string phone = Console.ReadLine();

            Person guest = new Person(name, email, phone);

            Console.WriteLine("Från när vill du boka ditt rum?: ");

            DateTime startDate;
           
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Ange incheckningsdatum (ÅÅÅÅ-MM-DD):");
            }
            Console.WriteLine("Hur många dagar vill du boka?");
            int lengthOfStayInDays = int.Parse(Console.ReadLine());

            HotelBooking booking = new HotelBooking(guest, startDate, lengthOfStayInDays);
            booking.ShowBookingDetails();

            Console.WriteLine("Vill du ändra dina bokade dagar?");
            string updateBooking = Console.ReadLine();
            if (updateBooking?.ToLower()=="ja")
            {
                Console.WriteLine("Hur många dagar vill du lägga till?: ");
                lengthOfStayInDays = int.Parse(Console.ReadLine());
                HotelBooking updatedBooking = new HotelBooking(guest, startDate, lengthOfStayInDays);
                updatedBooking.ShowBookingDetails();
            }
            else
            {
                Console.WriteLine("Tack för din bokning! :)");
            }
            
        }
    }
    public class HotelBooking
    {
        public Person Guest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PricePerNigth;
        public HotelBooking(Person guest, DateTime startDate, int lengthOfStayInDays)
        {
            Guest = guest;
            StartDate = startDate.Add(new TimeSpan(15,0,0));
            EndDate = startDate.AddDays(lengthOfStayInDays).Date.Add(new TimeSpan(12, 0, 0));
            PricePerNigth = lengthOfStayInDays * 1999;
        }
        public void ShowBookingDetails()
        {
            Console.WriteLine($"Gästnamn: {Guest.Name}");
            Console.WriteLine($"Incheckning: {StartDate}");
            Console.WriteLine($"Utcheckning: {EndDate}");
            Console.WriteLine("Pris per natt: 1999 kr");
            Console.WriteLine($"Pris för vistelse: {PricePerNigth} kr"); 
        }

    }
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
        public void personinfo()
        {
            Console.WriteLine($"Namn: {Name}");
            Console.WriteLine($"Epost: {Email}");
            Console.WriteLine($"Nummer: {Phone}");
        }
    }
}
