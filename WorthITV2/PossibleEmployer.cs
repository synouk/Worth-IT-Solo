using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class PossibleEmployer
    {
        EmployerMarket thisEmployerMarket;
        readonly string _thisEmployerName;
        readonly int _thisEmployerSalary;
        readonly int _thisEmployerNotorietyRequire;
        string _thisEmployerState;


        public PossibleEmployer(EmployerMarket E,string Name, int Salary, int Notoriety, string state, bool show )
        {
            thisEmployerMarket = E;
            _thisEmployerName = Name;
            _thisEmployerNotorietyRequire = Notoriety;
            _thisEmployerSalary = Salary;
            _thisEmployerState = state;
        }

        public string ThisEmployerName
        {
            get { return _thisEmployerName; }
        }

        public string ThisEmployerState
        {
            get { return _thisEmployerState; }
            set { _thisEmployerState = value; }
        }
        
        public int ThisEmployerSalary
        {
            get { return _thisEmployerSalary; }
        }

        public int ThisEmployerNotorietyRequire
        {
            get { return _thisEmployerNotorietyRequire; }
        }

        public EmployerMarket MyEmployerMarket
        {
            get { return thisEmployerMarket; }
        }

        public Tuple<string, int, int, string> GetEmployer()
        {
            return Tuple.Create( _thisEmployerName, _thisEmployerSalary, _thisEmployerNotorietyRequire, _thisEmployerState );
        }

        public bool CheckEmployer( int not )
        {
            bool result = false;

            if( not >= _thisEmployerNotorietyRequire)
            {
                result = true;

            }
            return result;
        }

        public void NewEmployer()
        {
            _thisEmployerState = "actif";
        }

        public void OldEmployerDelete()
        {
            if( _thisEmployerState == "actif" )
            {
                _thisEmployerState = "inactif";
            }
        }
    }
}
