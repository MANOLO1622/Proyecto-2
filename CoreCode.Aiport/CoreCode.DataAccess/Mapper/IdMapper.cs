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
    public class IdMapper : EntityMapper, ISqlStatements, IObjectMapper

    {

        private const string DB_COL_ID = "ID";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           // string DB_COL_ID = null;
            var id = new IdFligth
            {
                Id = GetStringValue(row, DB_COL_ID),
                
            };
            return id;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var id = BuildObject(row);
                lstResults.Add(id);
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

        public SqlOperation GetRetrieveAllIdStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_ID_PR" };
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
