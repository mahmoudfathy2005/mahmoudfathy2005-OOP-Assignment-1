using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;

namespace Part2_HotelReservationSystem
{
    public class Hotel
    {
        private readonly List<Room> _rooms = new();
        private readonly List<Guest> _guests = new();
        private readonly List<Reservation> _reservations = new();

        public IReadOnlyList<Room> Rooms =>
            _rooms;

        public IReadOnlyList<Guest> Guests =>
            _guests;

        public IReadOnlyList<Reservation> Reservations =>
            _reservations;

        public void AddRoom(Room room)
        {
            if (_rooms.Contains(room))
                throw new InvalidOperationException(
                    "Room is already added to the hotel.");

            _rooms.Add(room);
        }

        public void AddGuest(Guest guest)
        {
            if (_guests.Contains(guest))
                throw new InvalidOperationException(
                    "Guest is already added to the hotel.");

            _guests.Add(guest);
        }

        public Reservation MakeReservation(
            int reservationId,
            Guest guest,
            Room room,
            DateTime checkIn,
            DateTime checkOut)
        {
            if (!_guests.Contains(guest))
                throw new InvalidOperationException(
                    "Guest does not belong to this hotel.");

            if (!_rooms.Contains(room))
                throw new InvalidOperationException(
                    "Room does not belong to this hotel.");

            Reservation reservation = new(
                reservationId,
                guest,
                room,
                checkIn,
                checkOut,
                _reservations);

            _reservations.Add(reservation);

            guest.AddReservation(reservation);

            return reservation;
        }
    }
}

