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
    public class AsignationCrudFactory : CrudFactory
    {

        private readonly AsignationMapper mapper;

        public AsignationCrudFactory()
        {
            mapper = new AsignationMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var asignation = (Asignation)entity;
            var sqlOperation = mapper.GetCreateStatement(asignation);
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
            var listAsignations = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAsignations.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAsignations;
        }

        public override void Update(BaseEntity entity)
        {

        }

        public override void Delete(BaseEntity entity)
        {

        }

    }
}
