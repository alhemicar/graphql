using GraphQL.Types;
using GraphQLProject.Interfaces;

namespace GraphQLProject.Type
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationRepository ReservationRepository)
        {
            Field<ListGraphType<ReservationType>>("Reservations").Resolve(context => {
                return ReservationRepository.GetAllReservations();
            });
        }
    }
}