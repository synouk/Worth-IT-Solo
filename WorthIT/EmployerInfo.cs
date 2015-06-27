using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    [Serializable]
    public class EmployerInfo
    {
        public string name;
        public int money;
        public int notoriety;
        public string state;
        public bool achat;
        public Employer E;

        public EmployerInfo(Employer E, string name, int money, int notoriety, string state, bool achat)
        {
            this.name = name;
            this.money = money;
            this.notoriety = notoriety;
            this.state = state;
            this.E = E;
            this.achat = achat;

        }

        public Tuple<string , int , int , string> GetEmployer()
        {
            return Tuple.Create( name, money, notoriety, state );
        }

        public bool CheckEmployer (int not)
        {
            bool result = false;

            if( not >= notoriety )
            {
                result = true;

            }
            return result;
        }

        public void NewEmployer()
        {
            state = "actif";
        }

        public void OldEmployerDelete()
        {
            if( state == "actif" )
            {
                state = "inactif";
            }
        }
    }
}
