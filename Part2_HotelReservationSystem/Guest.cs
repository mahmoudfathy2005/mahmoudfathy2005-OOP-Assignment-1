using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Part2_HotelReservationSystem
{
    public class Guest
    {
        private readonly List<Reservation> _reservations = new();

        public int GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }

        public IReadOnlyList<Reservation> Reservations =>
            _reservations;

        public Guest(
            int guestId,
            string fullName,
            string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException(
                    "Full name cannot be empty.");

            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException(
                    "Phone number cannot be empty.");

            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        internal void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }
    }
}


