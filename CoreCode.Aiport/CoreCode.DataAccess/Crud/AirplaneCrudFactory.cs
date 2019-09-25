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
    public class AirplaneCrudFactory : CrudFactory
    {

        private readonly AirplaneMapper mapper;

        public AirplaneCrudFactory()
        {
            mapper = new AirplaneMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var airline = (Airline)entity;
            var sqlOperation = mapper.GetCreateStatement(airline);
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

        /*public List<T> RetrieveAirlines<T>(BaseEntity entity)
        {
            AirlineMapper airlineMapper = new AirlineMapper();
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(airlineMapper.GetRetrieveStatementAirlineById(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = airlineMapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return listAirlines;
        }*/


        public override List<T> RetrieveAll<T>()
        {
            var listAirplans = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirplans.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirplans;
        }

        /*public List<T> RetrieveWaitingAirplans<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveWaitingAirplans());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        //
        public List<T> RetrieveAcceptedAirplans<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAcceptedAirplans());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveDeniedAirplans<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveDeniedAirplans());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveAvailableAirplans<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAvailableAirplans());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveUnvailableAirplans<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveUnvailableAirplans());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }

        public List<T> RetrieveAssociatedAirplans<T>(BaseEntity entity)
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAssociatedAirplansStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveRejectedAirplans<T>(BaseEntity entity)
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveRejectedAirplansStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }


        public List<T> RetrieveWaitingAirplans<T>(BaseEntity entity)
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveWaitingAirplansStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }*/


        //
        public override void Update(BaseEntity entity)
        {
            var airplane = (Airplane)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(airplane));
        }

        public override void Delete(BaseEntity entity)
        {
            var airplane = (Airplane)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(airplane));
        }
    }
}
