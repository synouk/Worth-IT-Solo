using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    [Serializable]
    public class Argent
    {
        user u;
        int money;
        public int salary;
        int notoriety;
        string employer;
        public Argent(user u)
        {
           this.u = u;
           money = 500;
           salary = 100;
           employer = "monPremierEmplois";
           notoriety = 1000;
        }

        public void updateMoney ()
        {
            money = money + salary;

        }

        public int GetMoney()
        {
            return money;
        }

        public string GetEmployer ()
        {
            return employer;
        }

        public void UpdateAfterBuy( double price )
        {
            int intPrice = Convert.ToInt32( price );
            money -= intPrice;

        }

        public int getNotoriety()
        {
            return notoriety;
        }

        public void updateNotoriety(int add)
        {
            notoriety += add;
        }

        public void UpdateNotorietyAfterNewEmployer( int not, int salary)
        {
            this.salary = salary;
            notoriety -= not;
        }

        public void SellAction( int newPrice, double actionGlobalValue, double actualValue, int actionNumber )
        {
            money += newPrice;
            double notMoove = (actualValue - actionGlobalValue) * actionNumber;
            notoriety += Convert.ToInt32( notMoove );
        }
    }
}
