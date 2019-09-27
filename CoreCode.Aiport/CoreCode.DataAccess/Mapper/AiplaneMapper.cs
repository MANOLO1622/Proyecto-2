using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.DataAccess.Mapper
{

    public class AirplaneMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_LICENSE_PLATE = "LICENSE_PLATE";
        private const string DB_COL_CAPACITY = "CAPACITY";
        private const string DB_COL_MODEL = "MODEL";
        private const string DB_COL_BRAND = "BRAND";
        private const string DB_COL_ID_AIRLINE = "ID_AIRLINE";
        private const string DB_COL_STATUS = "STATUS";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {

            var Airplane = new Airplane
            {
                Id = GetStringValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                License_Plate = GetIntValue(row, DB_COL_LICENSE_PLATE),
                Capacity = GetIntValue(row, DB_COL_CAPACITY),
                Model = GetStringValue(row, DB_COL_MODEL),
                Brand = GetStringValue(row, DB_COL_BRAND),
                Id_Airline = GetStringValue(row, DB_COL_ID_AIRLINE),
                Status = GetBoolValue(row, DB_COL_STATUS),


            };
            return Airplane;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var airline = BuildObject(row);
                lstResults.Add(airline);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CREATE_AIRPLANE" };
            var a = (Airplane)entity;

            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_NAME, a.Name);
            operation.AddIntParam(DB_COL_LICENSE_PLATE, a.License_Plate);
            operation.AddIntParam(DB_COL_CAPACITY, a.Capacity);
            operation.AddVarcharParam(DB_COL_MODEL, a.Model);
            operation.AddVarcharParam(DB_COL_BRAND, a.Brand);
            operation.AddIntParam(DB_COL_STATUS, a.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_AIRLINE, a.Id_Airline);



            return operation;
        }

        public Airplane BuildObjectFromDataRow(DataRow row)
        {
            var airplane = new Airplane
            {
                Id = row.Field<string>(DB_COL_ID),
                Name = row.Field<string>(DB_COL_NAME),
                License_Plate = row.Field<int>(DB_COL_LICENSE_PLATE),
                Capacity = row.Field<int>(DB_COL_CAPACITY),
                Model = row.Field<string>(DB_COL_MODEL),
                Brand = row.Field<string>(DB_COL_BRAND),
                Status = row.Field<bool>(DB_COL_STATUS),
                Id_Airline = row.Field<string>(DB_COL_ID_AIRLINE)
            };
            return airplane;
        }

     


        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LISTAIRPLANE" };
            return operation;
        }

        public SqlOperation RetrieveWaitingAirplans()//*
        {
            var operation = new SqlOperation { ProcedureName = "RET_WAITING_AIRPLANS" };
            return operation;
        }

        public SqlOperation RetrieveAcceptedAirplans()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCEPTED_AIRPLANS" };
            return operation;
        }

        public SqlOperation RetrieveDeniedAirplans()
        {
            var operation = new SqlOperation { ProcedureName = "RET_REJECTED_AIRPLANS" };
            return operation;
        }

        public SqlOperation RetrieveAvailableAirlines()
        {
            var operation = new SqlOperation { ProcedureName = " RET_AVAILABLE_AIRPLANS" };
            return operation;
        }

        public SqlOperation RetrieveUnvailableAirlines()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_AIRPLANS" };
            return operation;
        }

        //public SqlOperation RetrieveAssociatedAirlinesStatement(BaseEntity entity)
        //{
        //    var operation = new SqlOperation { ProcedureName = "RET_ASSOCIATED_AIRPLANS" };
        //    var c = (Airline)entity;

        //    operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.ID);

        //    return operation;
        //}


        //public SqlOperation RetrieveRejectedAirlinesStatement(BaseEntity entity)
        //{
        //    var operation = new SqlOperation { ProcedureName = "RET_REJECTED_AIRLINES_AIRPORTS" };
        //    var c = (Airline)entity;

        //    operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.ID);

        //    return operation;
        //}


        //public SqlOperation RetrieveWaitingAirlinesStatement(BaseEntity entity)
        //{
        //    var operation = new SqlOperation { ProcedureName = "RET_WAITING_AIRLINES_AIRPORT" };
        //    var c = (Airline)entity;

        //    operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.ID);

        //    return operation;
        //}



        //public SqlOperation GetAirlinesByAirportIdStatement(string airportId)
        //{
        //    var operation = new SqlOperation { ProcedureName = "sp_getAirlinesByAirportId" };
        //    operation.AddVarcharParam(DB_COL_ID, airportId);
        //    return operation;
        //}

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEAIRPLANE" };
            var a = (Airplane)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_NAME, a.Name);
            operation.AddIntParam(DB_COL_LICENSE_PLATE, a.License_Plate);
            operation.AddIntParam(DB_COL_CAPACITY, a.Capacity);
            operation.AddVarcharParam(DB_COL_MODEL, a.Model);
            operation.AddVarcharParam(DB_COL_BRAND, a.Brand);
            operation.AddIntParam(DB_COL_STATUS, a.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_AIRLINE, a.Id_Airline);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETEAIRPLANE" };
            var a = (Airplane)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETAIRPLANEBYID" };
            var a = (Airplane)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }



        public SqlOperation GetRetrieveStatementAirlineById(String Id)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETAIRPLANEBYID" };
            var a = new Airplane();
            operation.AddVarcharParam(DB_COL_ID, a.Id);

            return operation;
        }


    }
}
