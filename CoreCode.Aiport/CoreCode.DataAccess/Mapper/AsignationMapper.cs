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
   public class AsignationMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_AIRPORT = "ID_AIRPORT";
        private const string DB_COL_ID_USER = "ID_USER";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           
            var Asignation = new Asignation
            {
                Id = GetStringValue(row, DB_COL_ID),
                Id_Airport = GetStringValue(row, DB_COL_ID_AIRPORT),
                Id_User = GetStringValue(row, DB_COL_ID_USER),
                

            };
            return Asignation;
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
            
            
               var operation = new SqlOperation { ProcedureName = "SP_CREATE_ASIGNATION" };
            var a = (Asignation)entity;

            
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, a.Id_Airport);
            operation.AddVarcharParam(DB_COL_ID_USER, a.Id_User);
            


            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_ASIGNATIONS" };
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
            var a = (Asignation)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }



        public SqlOperation GetRetrieveStatementAsignationById(String Id)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GET_ASIGNATIONBYID" };
            var a = new Asignation();
            operation.AddVarcharParam(DB_COL_ID, a.Id);
         
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
