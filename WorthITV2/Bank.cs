using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class Bank
    {
        public BankAccount MyAccount;
        User thisPlayer;
        public Bank(User player)
        {
            MyAccount = new BankAccount(this,500,100,500);
            thisPlayer = player;
            
        }

        public User MyUser
        {
            get { return thisPlayer; }
        }

        public void updateMoney()
        {
            MyAccount.ThisAccountMoney = MyAccount.ThisAccountMoney + MyAccount.ThisAccountSalary;

        }

        public void UpdateAfterBuy( double price )
        {
            int intPrice = Convert.ToInt32( price );
            MyAccount.ThisAccountMoney -= intPrice;

        }

        public void updateNotoriety(int add)
        {
            MyAccount.ThisAccountNotoriety += add;
        }

        public void UpdateNotorietyAfterNewEmployer( int not, int salary )
        {
            MyAccount.ThisAccountSalary = salary;
            MyAccount.ThisAccountNotoriety -= not;
        }

        public void SellAction( int newPrice, double actionGlobalValue, double actualValue, int actionNumber )
        {
            MyAccount.ThisAccountMoney += newPrice;
            double notMoove = (actualValue - actionGlobalValue) * actionNumber;
            MyAccount.ThisAccountNotoriety += Convert.ToInt32( notMoove );
        }

    }
}
