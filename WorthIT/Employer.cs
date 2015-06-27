using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    [Serializable]
    public class Employer
    {
        public string employer;
        user u;
        public Dictionary<string , EmployerInfo> D = new Dictionary<string, EmployerInfo>();
        public Employer(user u)
        {
            this.u = u;
            EmployerInfo BNP = new EmployerInfo( this, "BNP", 500, 500, "inactif",false );
            EmployerInfo LCL = new EmployerInfo( this, "LCL", 1000, 2000, "inactif", false );
            EmployerInfo Edouard = new EmployerInfo( this, "Edouard", 2000, 5000, "inactif", false );
            EmployerInfo Clement = new EmployerInfo( this, "Clement", 5000, 10000, "inactif", false );
            

            D.Add( "BNP", BNP );
            D.Add( "LCL", LCL );
            D.Add( "Edouard", Edouard );
            D.Add( "Clement", Clement );

            employer = "MyFirstJob";
        }


        public  Dictionary<string , Tuple<int , int , string>> GetEmployer()
        {
            Dictionary<string , Tuple<int , int , string>> Dico = new Dictionary<string, Tuple<int, int, string>>();
            foreach (var pair in D)
            {
                Tuple<string , int , int , string> result =pair.Value.GetEmployer();
                Dico.Add(result.Item1, Tuple.Create(result.Item2, result.Item3, result.Item4));

            }
            return Dico;
        }

        public void ChangeEmployer( string employerName )
        {
            int not =  u.argent.getNotoriety();
            foreach (var pair in D)
            {
                int not2;
                int money;
                if (pair.Key == employerName)
                {
                    if( pair.Value.CheckEmployer( not ) )
                    {
                        not2 = pair.Value.notoriety;
                        money = pair.Value.money;
                        updateNot( not2, money );
                        UpdateEmployer();
                        pair.Value.NewEmployer();
                        employer = employerName;
                        
                    }
                    
                }
            }
        }

        private void UpdateEmployer()
        {
           foreach (var pair in D)
           {
               pair.Value.OldEmployerDelete();
           }
        }

        internal void updateNot( int not, int salary )
        {
            u.argent.UpdateNotorietyAfterNewEmployer(not, salary);
        }

        public string getEmployer ()
        {
            return employer;
        }

        public List<EmployerInfo> getEmployerInfo()
        {
            List<EmployerInfo> L = new List<EmployerInfo>();
            foreach( var pair in D )
            {
                L.Add( pair.Value );
            }

            return L;
        }
    }
}
