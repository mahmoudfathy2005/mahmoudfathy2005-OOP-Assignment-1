
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;


using System;
using System.Collections.Generic;

namespace Part2_HotelReservationSystem
{
    public class Reservation
    {
        public int ReservationId { get; }
        public Guest Guest { get; }
        public Room Room { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }

        public ReservationStatus Status { get; private set; }

        public int NumberOfNights =>
            (CheckOutDate - CheckInDate).Days;

        public decimal TotalCost =>
            NumberOfNights * Room.NightlyRate;

        public Reservation(
            int reservationId,
            Guest guest,
            Room room,
            DateTime checkInDate,
            DateTime checkOutDate,
            IReadOnlyList<Reservation> existingReservations)
        {
            if (checkOutDate <= checkInDate)
                throw new ArgumentException(
                    "Check-out date must be after check-in date.");

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException(
                    "Cannot book a room under maintenance.");

            if (HasOverlappingReservation(
                    room,
                    checkInDate,
                    checkOutDate,
                    existingReservations))
            {
                throw new InvalidOperationException(
                    "Room is already booked for these dates.");
            }

            ReservationId = reservationId;
            Guest = guest;
            Room = room;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Status = ReservationStatus.Pending;
        }

        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
                throw new InvalidOperationException(
                    "Only pending reservations can be confirmed.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException(
                    "Reservation must be confirmed before check-in.");

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new InvalidOperationException(
                    "Only checked-in reservations can be checked out.");

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending &&
                Status != ReservationStatus.Confirmed)
            {
                throw new InvalidOperationException(
                    "Only pending or confirmed reservations can be cancelled.");
            }

            Status = ReservationStatus.Cancelled;
        }

        private static bool HasOverlappingReservation(
            Room room,
            DateTime checkIn,
            DateTime checkOut,
            IReadOnlyList<Reservation> reservations)
        {
            foreach (Reservation reservation in reservations)
            {
                if (reservation.Room != room)
                    continue;

                if (reservation.Status == ReservationStatus.Cancelled ||
                    reservation.Status == ReservationStatus.CheckedOut)
                {
                    continue;
                }

                bool overlaps =
                    checkIn < reservation.CheckOutDate &&
                    checkOut > reservation.CheckInDate;

                if (overlaps)
                    return true;
            }

            return false;
        }
    }
}

