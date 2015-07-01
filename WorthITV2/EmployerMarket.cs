using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class EmployerMarket
    {
        public string _myEmployer;
        GameContext myGame;
        public List<PossibleEmployer> allPossibleEmployerList = new List<PossibleEmployer>();
        public EmployerMarket(GameContext thisGameContext)
        {
            myGame = thisGameContext;
            _myEmployer = "My First Employer";
            PossibleEmployer BNP = new PossibleEmployer( this, "BNP", 500, 500, "inactif", false );
            PossibleEmployer LCL = new PossibleEmployer( this, "LCL", 1000, 2000, "inactif", false );
            PossibleEmployer Edouard = new PossibleEmployer( this, "Edouard", 2000, 5000, "inactif", false );
            PossibleEmployer Clement = new PossibleEmployer( this, "Clement", 5000, 10000, "inactif", false );

            allPossibleEmployerList.Add( BNP );
            allPossibleEmployerList.Add( LCL );
            allPossibleEmployerList.Add( Edouard );
            allPossibleEmployerList.Add( Clement );
        }

        public GameContext MyGame
        {
            get { return myGame; }
        }

        public Dictionary<string, Tuple<int, int, string>> GetEmployer()
        {
            Dictionary<string , Tuple<int , int , string>> Dico = new Dictionary<string, Tuple<int, int, string>>();
            foreach( var pair in allPossibleEmployerList )
            {
                Tuple<string , int , int , string> result =pair.GetEmployer();
                Dico.Add( result.Item1, Tuple.Create( result.Item2, result.Item3, result.Item4 ) );

            }
            return Dico;
        }

        public void ChangeEmployer( string employerName )
        {
            int not =  myGame.ThisUser.MyBank.MyAccount.ThisAccountNotoriety;
            foreach( var pair in allPossibleEmployerList )
            {
                int not2;
                int money;
                if( pair.ThisEmployerName == employerName )
                {
                    if( pair.CheckEmployer( not ) )
                    {
                        not2 = pair.ThisEmployerNotorietyRequire;
                        money = pair.ThisEmployerSalary;
                        updateNot( not2, money );
                        UpdateEmployer();
                        pair.NewEmployer();

                    }

                }
            }
        }

        public string MyEmployer()
        {
            foreach(var pair in allPossibleEmployerList)
            {
                if (pair.ThisEmployerState == "actif")
                {
                    _myEmployer = pair.ThisEmployerName;
                }               
            }
            return _myEmployer;
        }

        private void UpdateEmployer()
        {
            foreach( var pair in allPossibleEmployerList )
            {
                pair.OldEmployerDelete();
            }
        }

        internal void updateNot( int not, int salary )
        {
            myGame.ThisUser.MyBank.UpdateNotorietyAfterNewEmployer( not, salary );
        }

        public List<PossibleEmployer> getEmployerInfo()
        {
            List<PossibleEmployer> L = new List<PossibleEmployer>();
            foreach( var pair in allPossibleEmployerList )
            {
                L.Add( pair);
            }

            return L;
        }


    }
}
