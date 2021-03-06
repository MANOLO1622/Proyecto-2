﻿using CoreCode.DataAccess.Mapper;
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
    public class TicketCrudFactory : CrudFactory
    {

        private readonly TicketMapper mapper;

        public TicketCrudFactory()
        {
            mapper = new TicketMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var ticket = (Ticket)entity;
            var sqlOperation = mapper.GetCreateStatement(ticket);
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
            var listTickets = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listTickets.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listTickets;
        }

        public override void Update(BaseEntity entity)
        {
            var ticket = (Ticket)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(ticket));
        }

        public override void Delete(BaseEntity entity)
        {
            var ticket = (Ticket)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(ticket));
        }

        public List<T> RetrieveOnTime<T>()
        {
            var listTickets = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetOnTimeTicket());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listTickets.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listTickets;
        }

        public List<T> RetrieveCanceled<T>()
        {
            var listTickets = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCanceledTicket());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listTickets.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listTickets;
        }

        public List<T> RetrieveDelay<T>()
        {
            var listTickets = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetDelayTicket());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listTickets.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listTickets;
        }

    }
}
