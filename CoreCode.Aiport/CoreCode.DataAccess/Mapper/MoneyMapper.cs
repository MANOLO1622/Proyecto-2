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
    public class MoneyMapper : EntityMapper, ISqlStatements, IObjectMapper

    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_ORIGEN = "ORIGEN";
        private const string DB_COL_DESTINO = "DESTINO";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_PRECIO = "PRECIO";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           // string DB_COL_ID = null;
            var money = new Money
            {
                IDMoney = GetStringValue(row, DB_COL_ID),
                Origen = GetStringValue(row, DB_COL_ORIGEN),
                Destino = GetStringValue(row, DB_COL_DESTINO),
                Status = GetBoolValue(row, DB_COL_STATUS),
                Precio = GetStringValue(row, DB_COL_PRECIO)
            };
            return money;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var money = BuildObject(row);
                lstResults.Add(money);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MONEY_PR" };
            var c = (Money)entity;

            operation.AddVarcharParam(DB_COL_ID, c.IDMoney);
            operation.AddVarcharParam(DB_COL_ORIGEN, c.Origen);
            operation.AddVarcharParam(DB_COL_DESTINO, c.Destino);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_PRECIO, c.Precio);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MONEY_PR" };
            var c = (Money)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDMoney);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MONEY_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveAvailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_AVAILABLE_MONEY_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveUnavailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_MONEY_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MONEY_PR" };
            var c = (Money)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDMoney);

            return operation; 
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MONEY_PR" };
            var c = (Money)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDMoney);
            operation.AddVarcharParam(DB_COL_ORIGEN, c.Origen);
            operation.AddVarcharParam(DB_COL_DESTINO, c.Destino);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_PRECIO, c.Precio);
            return operation;
        }
    }
}
