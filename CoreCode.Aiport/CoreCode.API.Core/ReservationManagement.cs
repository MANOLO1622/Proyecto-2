using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class ReservationManagement
    {
        private readonly ReservationCrudFactory crudReservation;

        public ReservationManagement()
        {
            crudReservation = new ReservationCrudFactory();
        }

        public void Create(Reservation reservation)
        {
            crudReservation.Create(reservation);
        }

        public List<Reservation> RetrieveAll()
        {
            return crudReservation.RetrieveAll<Reservation>();
        }


        public List<Reservation> RetrieveAvailable()
        {
            return crudReservation.RetrieveAvailable<Reservation>();
        }

        public List<Reservation> RetrieveUnavailable()
        {
            return crudReservation.RetrieveUnavailable<Reservation>();
        }

        public Reservation RetrieveById(Reservation reservation)
        {
            return crudReservation.Retrieve<Reservation>(reservation);
        }

        public void Update(Reservation reservation)
        {
            crudReservation.Update(reservation);
        }

        public void Delete(Reservation reservation)
        {
            crudReservation.Delete(reservation);
        }

    }
}
