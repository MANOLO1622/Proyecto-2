using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.DataAccess.Mapper
{
    public class ReservationMapper : EntityMapper, ISqlStatements, IObjectMapper

    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_FIRST_NAME = "FIRST_NAME";
        private const string DB_COL_FIRST_LAST_NAME = "FIRST_LAST_NAME";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_DESTINY = "DESTINY";
        private const string DB_COL_PRICE = "PRICE";
        private const string DB_COL_BUY_DATE = "BUY_DATE";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           // string DB_COL_ID = null;
            var reservation = new Reservation
            {
                IDReservation = GetStringValue(row, DB_COL_ID),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                FirstLastName = GetStringValue(row, DB_COL_FIRST_LAST_NAME),
                Status = GetBoolValue(row, DB_COL_STATUS),
                Destiny = GetStringValue(row, DB_COL_DESTINY),
                Price = GetDecimalValue(row, DB_COL_PRICE),
                Buy_Date = Convert.ToDateTime(GetDateValue(row, DB_COL_BUY_DATE)),
            };
            return reservation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var reservation = BuildObject(row);
                lstResults.Add(reservation);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_RESERVATION_PR" };
            var c = (Reservation)entity;

            operation.AddVarcharParam(DB_COL_ID, c.IDReservation);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, c.FirstLastName);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_DESTINY, c.Destiny);
            operation.AddDecimalParam(DB_COL_PRICE, c.Price);
            operation.AddDateParam(DB_COL_BUY_DATE, c.Buy_Date);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_RESERVATION_PR" };
            var c = (Reservation)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDReservation);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_RESERVATION_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveAvailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_AVAILABLE_RESERVATION_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveUnavailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_RESERVATION_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_RESERVATION_PR" };
            var c = (Reservation)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDReservation);

            return operation; 
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_RESERVATION_PR" };
            var c = (Reservation)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDReservation);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, c.FirstName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, c.FirstLastName);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_DESTINY, c.Destiny);
            operation.AddDecimalParam(DB_COL_PRICE, c.Price);
            operation.AddDateParam(DB_COL_BUY_DATE, c.Buy_Date);
            return operation;
        }
    }
}
