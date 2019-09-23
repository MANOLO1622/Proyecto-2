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
   public class AsignationAirlineMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_COMERCIAL_NAME = "COMERCIAL_NAME";
        private const string DB_COL_NAME = "NAME";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           
            var AsignationAirline = new AsignationAirline
            {
                Id = GetIntValue(row, DB_COL_ID),
                Comercial_name = GetStringValue(row, DB_COL_COMERCIAL_NAME),
                Name = GetStringValue(row, DB_COL_NAME),


            };
            return AsignationAirline;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var airport = BuildObject(row);
                lstResults.Add(airport);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            
            
               var operation = new SqlOperation { ProcedureName = "SP_CREATE_ASIGNATION_AIRLINE" };
            var a = (AsignationAirline)entity;


            operation.AddVarcharParam(DB_COL_COMERCIAL_NAME, a.Comercial_name);
            operation.AddVarcharParam(DB_COL_NAME, a.Name);



            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_ASIGNATIONS_AIRLINES" };
            return operation;
        }

        public SqlOperation GetAirlinesByAsignationIdStatement(string asignationId)
        {
            var operation = new SqlOperation { ProcedureName = "sp_getAirlinesByAirportId" };
            operation.AddVarcharParam(DB_COL_ID, asignationId);
            return operation;
        }


        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GET_ASIGNATIONID" };
            var a = (AsignationAirline)entity;
            operation.AddIntParam(DB_COL_ID, a.Id);
            return operation;
        }



        public SqlOperation GetRetrieveStatementAsignationById(String Id)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GET_ASIGNATIONBYID" };
            var a = new AsignationAirline();
            operation.AddIntParam(DB_COL_ID, a.Id);
         
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETEFLIGHT" };
            //var a = (Flight)entity;
            //operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEFLIGHT" };
            //var a = (Flight)entity;
            //operation.AddVarcharParam(DB_COL_ID, a.Id);
            //operation.AddVarcharParam(DB_COL_AIRLINE_ID, a.Airline_Id);
            //operation.AddVarcharParam(DB_COL_ORIGIN_AIRPORT, a.Origin_Airport_Id);
            //operation.AddVarcharParam(DB_COL_DESTINY_AIRPORT, a.Destiny_Airport_Id);
            //operation.AddDateParam(DB_COL_DEPARTURE_TIME, a.Departure_Time);
            //operation.AddDateParam(DB_COL_ARRIVAL_TIME, a.Arrival_DateTime);
            //operation.AddVarcharParam(DB_COL_STATUS, a.Status);
            //operation.AddVarcharParam(DB_COL_ID_AIRPLANE, a.Id_Airplane);
            ///operation.AddVarcharParam(DB_COL_ID_GATE, a.Id_Gate);
            return operation;
        }

    }
}
