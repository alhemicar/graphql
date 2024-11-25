using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class ReservationRepository : IReservationRepository
    {
        private GraphQLDbContext dbContext;

        public ReservationRepository(GraphQLDbContext context)
        {
            dbContext = context;
        }

        public List<Reservation> GetAllReservations()
        {
            return dbContext.Reservations.ToList();
        }

        public Reservation AddReservation(Reservation Reservation)
        {
            dbContext.Reservations.Add(Reservation);
            dbContext.SaveChanges();

            return Reservation;
        }
    }
}