using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{

    [Serializable]
    public class BankAccount
    {
        Bank myBank;
        int _thisAccountMoney;
        int _ThisAccountSalary;
        int _thisAccountNotoriety;

        public BankAccount(Bank thisBank ,int startMoney, int startSalary, int notoriety)
        {
            myBank = thisBank;
            _thisAccountMoney = startMoney;
            _ThisAccountSalary = startSalary;
            _thisAccountNotoriety = notoriety;
        }

        public int ThisAccountMoney
        {
           get {return _thisAccountMoney;}
            set { _thisAccountMoney = value;}
        }

        public int ThisAccountSalary
        {
            get { return _ThisAccountSalary; }
            set { _ThisAccountSalary = value; }
        }

        public int ThisAccountNotoriety
        {
            get { return _thisAccountNotoriety; }
            set { _thisAccountNotoriety = value; }
        }

        public Bank MyBank
        {
            get { return myBank; }
        }
    }
}
