using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    [Serializable]
    public class BonusInfo
    {
        Bonus B;
        public string name;
        public string state;
        public int price;
        public bool achat;

        public BonusInfo(Bonus B , string name, string state, int price, bool achat )
        {
            this.B = B;
            this.name = name;
            this.state = state;
            this.price = price;
            this.achat = achat;
        }

        internal bool Buy( int money, Argent Ar )
        {
            if (money >= price )
            {
                state = "activé";
                Ar.UpdateAfterBuy( price );
                return true;
                
            }
            else
            {
                return false;
            }
        }

        public Bonus up
        {
            get { return B; }
        }

        public Tuple<string , int > GetBonus()
        {
            return Tuple.Create( name, price );
        }

        internal bool GetState()
        {
            if (state == "activé")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
