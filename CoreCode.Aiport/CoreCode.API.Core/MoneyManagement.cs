using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class MoneyManagement
    {
        private readonly MoneyCrudFactory crudMoney;

        public MoneyManagement()
        {
            crudMoney = new MoneyCrudFactory();
        }

        public void Create(Money money)
        {
            crudMoney.Create(money);
        }

        public List<Money> RetrieveAll()
        {
            return crudMoney.RetrieveAll<Money>();
        }

        public List<Money> RetrieveAvailable()
        {
            return crudMoney.RetrieveAvailable<Money>();
        }

        public List<Money> RetrieveUnavailable()
        {
            return crudMoney.RetrieveUnavailable<Money>();
        }

        public Money RetrieveById(Money money)
        {
            return crudMoney.Retrieve<Money>(money);
        }

        public void Update(Money money)
        {
            crudMoney.Update(money);
        }

        public void Delete(Money money)
        {
            crudMoney.Delete(money);
        }

    }
}
