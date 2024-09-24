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
            Console.WriteLine("Hur många gäster vill du boka för?");
            int numberOfGuests = int.Parse(Console.ReadLine());

            string[] guestNames = new string[numberOfGuests];

            for (int i = 0; i < numberOfGuests; i++)
            {
                Console.WriteLine($"Ange namn för gäst {i + 1}:");
                guestNames[i] = Console.ReadLine();
            }

            Console.Write("Ange din e-post: ");
            string email = Console.ReadLine();

            Console.Write("Ange ditt telefonnummer: ");
            string phone = Console.ReadLine();

            Person guest = new Person(guestNames, email, phone);

            Console.WriteLine("Från när vill du boka ditt rum?: ");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Ogiltigt format. Ange incheckningsdatum (ÅÅÅÅ-MM-DD):");
            }

            Console.WriteLine("Hur många dagar vill du boka?");
            int lengthOfStayInDays = int.Parse(Console.ReadLine());

            HotelBooking booking = new HotelBooking(guest, startDate, lengthOfStayInDays);
            booking.ShowBookingDetails();

            Console.WriteLine("Vill du ändra dina bokade dagar?");
            string updateBooking = Console.ReadLine();
            if (updateBooking?.ToLower() == "ja")
            {
                Console.WriteLine("Hur många dagar vill du boka till?: ");
                int additionalDays = int.Parse(Console.ReadLine());
                booking.ExtendStay(additionalDays);
                booking.ShowBookingDetails();
            }
            else
            {
                Console.WriteLine("Tack för din bokning! :)");
            }
        }
    }

}
    
    public class HotelBooking
{
    public Person Guest { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalCost { get; set; }
    private const int PricePerNight = 1999;

    public HotelBooking(Person guest, DateTime startDate, int lengthOfStayInDays)
    {
        Guest = guest;
        StartDate = startDate.Add(new TimeSpan(15, 0, 0));
        EndDate = startDate.AddDays(lengthOfStayInDays).Date.Add(new TimeSpan(12, 0, 0));
        TotalCost = lengthOfStayInDays * PricePerNight;
    }

    public void ExtendStay(int additionalDays)
    {
        EndDate = EndDate.AddDays(additionalDays);
        TotalCost += additionalDays * PricePerNight;
    }

    public void ShowBookingDetails()
    {
        Console.WriteLine("Gäster: ");
        foreach (var name in Guest.Names)
        {
            Console.WriteLine($"- {name}");
        }
        Console.WriteLine($"Incheckning: {StartDate}");
        Console.WriteLine($"Utcheckning: {EndDate}");
        Console.WriteLine($"Pris per natt: {PricePerNight} kr");
        Console.WriteLine($"Pris för vistelse: {TotalCost} kr");
    }
}

    
    public class Person
    {
        public string[] Names { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Person(string[] names, string email, string phone)
        {
            Names = names;
            Email = email;
            Phone = phone;
        }
       
    public void PersonInfo()
        {
            Console.WriteLine("Gäster: ");
            foreach (var name in Names)
            {
                Console.WriteLine($"- {name}");
            }
            Console.WriteLine($"E-post: {Email}");
            Console.WriteLine($"Telefonnummer: {Phone}");
        }

    }
