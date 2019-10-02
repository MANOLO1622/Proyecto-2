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
    public class PriceMapper : EntityMapper, ISqlStatements, IObjectMapper

    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_PRICE = "PRICE";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           // string DB_COL_ID = null;
            var price = new PriceAmount
            {
                Id = GetStringValue(row, DB_COL_ID),
                Price = GetDecimalValue(row, DB_COL_PRICE)
            };
            return price;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var price = BuildObject(row);
                lstResults.Add(price);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllPriceStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PRICE_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
