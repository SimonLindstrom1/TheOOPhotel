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
            string guestName = Console.ReadLine();

            Console.WriteLine("Från när vill du boka ditt rum?: ");

            DateTime startDate;
           
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Ange incheckningsdatum (ÅÅÅÅ-MM-DD):");
            }
            Console.WriteLine("Hur många dagar vill du boka?");
            int lengthOfStayInDays = int.Parse(Console.ReadLine());

            HotelBooking booking = new HotelBooking(guestName, startDate, lengthOfStayInDays);
            booking.ShowBookingDetails();

            Console.WriteLine("Vill du ändra dina bokade dagar?");
            string updateBooking = Console.ReadLine();
            if (updateBooking?.ToLower()=="ja")
            {
                Console.WriteLine("Hur många dagar vill du lägga till?: ");
                lengthOfStayInDays = int.Parse(Console.ReadLine());
                HotelBooking updatedBooking = new HotelBooking(guestName, startDate, lengthOfStayInDays);
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
        public string GuestName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PricePerNigth;
        public HotelBooking(string guestName, DateTime startDate, int lengthOfStayInDays)
        {
            GuestName = guestName;
            StartDate = startDate.Add(new TimeSpan(15,0,0));
            EndDate = startDate.AddDays(lengthOfStayInDays).Date.Add(new TimeSpan(12, 0, 0));
            PricePerNigth = lengthOfStayInDays * 1999;
        }
        public void ShowBookingDetails()
        {
            Console.WriteLine($"Gästnamn: {GuestName}");
            Console.WriteLine($"Incheckning: {StartDate}");
            Console.WriteLine($"Utcheckning: {EndDate}");
            Console.WriteLine("Pris per natt: 1999 kr");
            Console.WriteLine($"Pris för vistelse: {PricePerNigth} kr"); 
        }

    }
}
