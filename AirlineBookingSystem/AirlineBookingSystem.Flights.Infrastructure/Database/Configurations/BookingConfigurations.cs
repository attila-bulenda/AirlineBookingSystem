using AirlineBookingSystem.Flights.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirlineBookingSystem.Flights.Infrastructure.Database.Configurations
{
    public class BookingConfigurations : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {           
            builder.HasData
            (
                new Booking { Id = 1, PassengerName= "John Smith", PassportNumber= "BX534916732", SeatNumber = "12C", FlightId = 1 },
                new Booking { Id = 2, PassengerName = "Alice Thompson", PassportNumber = "AX128374950", SeatNumber = "14A", FlightId = 3 },
                new Booking { Id = 3, PassengerName = "Liam Johnson", PassportNumber = "CT938471205", SeatNumber = "22F", FlightId = 5 },
                new Booking { Id = 4, PassengerName = "Emma Wilson", PassportNumber = "PL372849172", SeatNumber = "8B", FlightId = 1 },
                new Booking { Id = 5, PassengerName = "Noah Brown", PassportNumber = "YX182736459", SeatNumber = "16C", FlightId = 7 },
                new Booking { Id = 6, PassengerName = "Olivia Davis", PassportNumber = "RB273648159", SeatNumber = "10A", FlightId = 2 },
                new Booking { Id = 7, PassengerName = "James Taylor", PassportNumber = "QP394857612", SeatNumber = "9E", FlightId = 4 },
                new Booking { Id = 8, PassengerName = "Sophia Martinez", PassportNumber = "KM837261945", SeatNumber = "19D", FlightId = 6 },
                new Booking { Id = 9, PassengerName = "Benjamin Lee", PassportNumber = "UT928374560", SeatNumber = "13B", FlightId = 9 },
                new Booking { Id = 10, PassengerName = "Isabella White", PassportNumber = "DZ173849260", SeatNumber = "21A", FlightId = 10 },
                new Booking { Id = 11, PassengerName = "Lucas Harris", PassportNumber = "WL294837165", SeatNumber = "12D", FlightId = 2 },
                new Booking { Id = 12, PassengerName = "Mia Clark", PassportNumber = "GX193847205", SeatNumber = "23C", FlightId = 8 },
                new Booking { Id = 13, PassengerName = "Henry Young", PassportNumber = "JF384726195", SeatNumber = "7F", FlightId = 5 },
                new Booking { Id = 14, PassengerName = "Charlotte Allen", PassportNumber = "MB837261934", SeatNumber = "15E", FlightId = 3 },
                new Booking { Id = 15, PassengerName = "Alexander Scott", PassportNumber = "ER918374612", SeatNumber = "18B", FlightId = 11 },
                new Booking { Id = 16, PassengerName = "Amelia King", PassportNumber = "PK183746205", SeatNumber = "5C", FlightId = 14 },
                new Booking { Id = 17, PassengerName = "Daniel Green", PassportNumber = "ZH827364920", SeatNumber = "6D", FlightId = 6 },
                new Booking { Id = 18, PassengerName = "Evelyn Hall", PassportNumber = "NL728394651", SeatNumber = "17A", FlightId = 12 },
                new Booking { Id = 19, PassengerName = "Matthew Baker", PassportNumber = "LS283746159", SeatNumber = "24F", FlightId = 13 },
                new Booking { Id = 20, PassengerName = "Harper Nelson", PassportNumber = "CV837465120", SeatNumber = "20E", FlightId = 10 },
                new Booking { Id = 21, PassengerName = "Jackson Adams", PassportNumber = "HT918374621", SeatNumber = "3A", FlightId = 4 },
                new Booking { Id = 22, PassengerName = "Abigail Rivera", PassportNumber = "UV837162930", SeatNumber = "4B", FlightId = 7 },
                new Booking { Id = 23, PassengerName = "Sebastian Ramirez", PassportNumber = "YX847261950", SeatNumber = "2F", FlightId = 9 },
                new Booking { Id = 24, PassengerName = "Emily Perez", PassportNumber = "KG837261940", SeatNumber = "11C", FlightId = 8 },
                new Booking { Id = 25, PassengerName = "Aiden Carter", PassportNumber = "NE102938475", SeatNumber = "6E", FlightId = 1 },
                new Booking { Id = 26, PassengerName = "Ella Roberts", PassportNumber = "RH837261953", SeatNumber = "1D", FlightId = 13 },
                new Booking { Id = 27, PassengerName = "Logan Mitchell", PassportNumber = "FE918374625", SeatNumber = "7C", FlightId = 12 },
                new Booking { Id = 28, PassengerName = "Scarlett Turner", PassportNumber = "OB374829105", SeatNumber = "8F", FlightId = 15 },
                new Booking { Id = 29, PassengerName = "David Phillips", PassportNumber = "MT837261970", SeatNumber = "5A", FlightId = 6 },
                new Booking { Id = 30, PassengerName = "Grace Campbell", PassportNumber = "EQ193847205", SeatNumber = "9B", FlightId = 11 },
                new Booking { Id = 31, PassengerName = "Joseph Parker", PassportNumber = "RE827364920", SeatNumber = "10F", FlightId = 14 },
                new Booking { Id = 32, PassengerName = "Chloe Evans", PassportNumber = "SU837261984", SeatNumber = "13A", FlightId = 5 },
                new Booking { Id = 33, PassengerName = "Samuel Edwards", PassportNumber = "TK273849162", SeatNumber = "17F", FlightId = 2 },
                new Booking { Id = 34, PassengerName = "Aria Collins", PassportNumber = "VC837261918", SeatNumber = "18C", FlightId = 3 },
                new Booking { Id = 35, PassengerName = "Elijah Stewart", PassportNumber = "BG837261933", SeatNumber = "14E", FlightId = 15 },
                new Booking { Id = 36, PassengerName = "Victoria Sanchez", PassportNumber = "ZH837261911", SeatNumber = "22C", FlightId = 7 },
                new Booking { Id = 37, PassengerName = "Wyatt Morris", PassportNumber = "DE283746195", SeatNumber = "19B", FlightId = 9 },
                new Booking { Id = 38, PassengerName = "Zoey Rogers", PassportNumber = "XM837261997", SeatNumber = "15A", FlightId = 6 },
                new Booking { Id = 39, PassengerName = "Gabriel Reed", PassportNumber = "PY837261934", SeatNumber = "16F", FlightId = 8 },
                new Booking { Id = 40, PassengerName = "Lily Cook", PassportNumber = "TR827364928", SeatNumber = "12B", FlightId = 10 }
            );
        }
    }
}
