
using System;

namespace Part2_HotelReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hotel hotel = new();

            Room room101 =
                new Room(
                    101,
                    RoomType.Double,
                    1500);

            Guest guest =
                new Guest(
                    1,
                    "Ahmed Ali",
                    "01000000000");

            hotel.AddRoom(room101);
            hotel.AddGuest(guest);

            Reservation reservation =
                hotel.MakeReservation(
                    1,
                    guest,
                    room101,
                    new DateTime(2026, 10, 10),
                    new DateTime(2026, 10, 13));

            Console.WriteLine($"Guest: {guest.FullName}");
            Console.WriteLine($"Room: {reservation.Room.RoomNumber}");
            Console.WriteLine($"Status: {reservation.Status}");
            Console.WriteLine($"Nights: {reservation.NumberOfNights}");
            Console.WriteLine($"Total: {reservation.TotalCost}");

            reservation.Confirm();

            Console.WriteLine($"Status: {reservation.Status}");

            reservation.CheckIn();

            Console.WriteLine($"Status: {reservation.Status}");

            reservation.CheckOut();

            Console.WriteLine($"Status: {reservation.Status}");
        }
    }
}

