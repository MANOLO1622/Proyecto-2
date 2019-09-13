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
    public class AsignationAirlineCrudFactory : CrudFactory
    {

        private readonly AsignationAirlineMapper mapper;

        public AsignationAirlineCrudFactory()
        {
            mapper = new AsignationAirlineMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var asignationAirline = (AsignationAirline)entity;
            var sqlOperation = mapper.GetCreateStatement(asignationAirline);
            dao.ExecuteProcedure(sqlOperation);
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

        public override List<T> RetrieveAll<T>()
        {
            var listAsignationAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAsignationAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAsignationAirlines;
        }

        public override void Update(BaseEntity entity)
        {

        }

        public override void Delete(BaseEntity entity)
        {

        }

    }
}
