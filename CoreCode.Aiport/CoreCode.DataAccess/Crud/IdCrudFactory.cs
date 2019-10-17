using CoreCode.DataAccess.Mapper;
using CoreCode.Entities.POJO;
using DataAccess.Crud;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.DataAccess.Crud
{
    public class IdCrudFactory : CrudFactory
    {

        private readonly IdMapper mapper;

        public IdCrudFactory()
        {

            mapper = new IdMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var tikect = (IdFligth)entity;
            var sqlOperation = mapper.GetCreateStatement(tikect);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var tikect = (IdFligth)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(tikect));
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        //public override List<T> RetrieveAll<T>()
        //{
        //    var listReservations = new List<T>();
        //    var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
        //    var dic = new Dictionary<string, object>();
        //    if (lstResult.Count > 0)
        //    {
        //        var objs = mapper.BuildObjects(lstResult);
        //        foreach (var c in objs) listReservations.Add((T)Convert.ChangeType(c, typeof(T)));
        //    }

        //    return listReservations;
        //}

        public override List<T> RetrieveAll<T>()
        {
            var listIds = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllIdStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listIds.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listIds;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
