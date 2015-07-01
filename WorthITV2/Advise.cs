using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class Advise
    {
        GameContext myGame;
        public List <Advisors> ListOfAdvisors = new List<Advisors>();
        public Advise(GameContext thisGame)
        {
            myGame = thisGame;

            Advisors Ingénieur = new Advisors( this, "Ingénieur", "désactivé", 1000, false );
            Advisors Geopoliticien = new Advisors( this, "Geopoliticien", "désactivé", 2000, false );
            Advisors Commercial = new Advisors( this, "Commercial", "désactivé", 5000, false );
            Advisors Mecano = new Advisors( this, "Mecano", "désactivé", 10000, false );
            Advisors Coiffeuse = new Advisors( this, "Coiffeuse", "désactivé", 50000, false );

            ListOfAdvisors.Add(Ingénieur);
            ListOfAdvisors.Add(Geopoliticien);
            ListOfAdvisors.Add(Commercial);
            ListOfAdvisors.Add(Mecano);
            ListOfAdvisors.Add(Coiffeuse);
        }

        public GameContext MyGame
        {
            get { return myGame; }
        }

        public Advisors CheckAvisorsName(string nameToTest)
        {
            Advisors result = null;
            foreach(var pair in ListOfAdvisors)
            {
                if (nameToTest == pair.Name)
                {
                    result = pair;
                }
            }
            return result;
        }

        public bool BuyBonus( string name )
        {

            int money = MyGame.ThisUser.MyBank.MyAccount.ThisAccountMoney;
            bool toReturn = false;
            Advisors result = CheckAvisorsName(name);
                    if( result.Buy( money) )
                    {
                        toReturn = true;
                    }
                    return toReturn;
 
        }

        public Dictionary<string, int> GetBonus()
        {
            Dictionary<string, int> Bo = new Dictionary<string, int>();
            foreach( var pair in ListOfAdvisors )
            {
                Tuple<string, int >result = pair.GetBonus();
                string BonusName = result.Item1;
                int BonusPrice = result.Item2;
                Bo.Add( BonusName, BonusPrice );

            }
            return Bo;
        }

        public bool GetState( string name )
        {
            bool toReturn = false;
           if (CheckAvisorsName( name )!= null)
           {
               toReturn = true;
           }

            return toReturn;
        }

        public List<Advisors> getBonusInfo()
        {
            List<Advisors> L = new List<Advisors>();
            foreach( var pair in ListOfAdvisors )
            {
                L.Add( pair );
            }
            return L;
        }

        public Dictionary<string, Tuple<string, string, string>> Advises()
        {

            Dictionary<string , Tuple<string ,string, string>> D = new Dictionary<string, Tuple<string, string, string>>();
            foreach( var pair in MyGame.ThisNewsPaper.AllPossibleNewsList )
            {
                string affect;
                if( pair.TypeOfAffect > 1 )
                {
                    affect = "positif";
                }
                else
                {
                    affect = "negatif";
                }
                D.Add( pair.Title, Tuple.Create( pair.BonusAdvisor, pair.Affect, affect ) );
            }
            return D;
        }
    }
}
