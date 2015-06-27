using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    [Serializable]
    public class Bonus
    {
        user u;
        public Dictionary<string, BonusInfo> B = new Dictionary<string,BonusInfo>();
        public Bonus(user u)
        {
            this.u = u;
            BonusInfo Ingénieur = new BonusInfo (this,"Ingénieur", "désactivé", 1000, false);
            BonusInfo Geopoliticien = new BonusInfo( this, "Geopoliticien", "désactivé", 2000, false );
            BonusInfo Commercial = new BonusInfo( this, "Commercial", "désactivé", 5000, false );
            BonusInfo Mecano = new BonusInfo( this, "Mecano", "désactivé", 10000, false );
            BonusInfo Coiffeuse = new BonusInfo( this, "Coiffeuse", "désactivé", 50000, false );
            B.Add ("ingénieur", Ingénieur);
            B.Add( "Geopoliticien", Geopoliticien );
            B.Add( "Commercial", Commercial );
            B.Add( "Mecano", Mecano );
            B.Add( "Mafieux", Coiffeuse );

        }

        public bool BuyBonus(string name)
        {
            bool result = false;
            int money = u.argent.GetMoney();
            
            foreach( var pair in B )
            {
                if( pair.Key.ToString() == name )
                {
                    if (pair.Value.Buy(money, user.GetMoney()))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public user user
        {
            get { return u; }
        }

        public Dictionary<string, int> GetBonus()
        {
            Dictionary<string, int> Bo = new Dictionary<string,int>();
            foreach (var pair in B)
            {
                Tuple<string, int >result = pair.Value.GetBonus();
                string BonusName = result.Item1;
                int BonusPrice = result.Item2;
                Bo.Add(BonusName, BonusPrice);
                
            }
            return Bo;
        }

        public bool GetState( string p )
        {
            bool result = false;
            foreach(var pair in B)
            {
                if (pair.Key.ToString() == p)
                {
                     result = pair.Value.GetState();                                     
                }
                
            }
            return result;
        }

        public List<BonusInfo> getBonusInfo()
        {
            List<BonusInfo> L = new List<BonusInfo>();
            foreach (var pair in B)
            {
                L.Add( pair.Value );
            }
            return L;
        }

        public Dictionary<string, Tuple<string, string, string>> Advises()
        {
            News N = u.GetNews();
            Dictionary<string , Tuple<string ,string, string>> D = new Dictionary<string, Tuple<string,string, string>>();
            foreach (var pair in N.N)
            {
                string affect;
                if(pair.Value.typeOfAffect > 1)
                {
                     affect = "positif";
                }
                else {
                    affect = "negatif";
                }
                D.Add( pair.Value.title, Tuple.Create(pair.Value.BonusAdviser, pair.Value.affect, affect));
            }
            return D;
        }

    }
}
