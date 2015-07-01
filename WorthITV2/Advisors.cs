using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class Advisors
    {
        readonly string _name;
        string _state;
        int _price;
        Advise thisBonusList;
        public Advisors(Advise bonus , string thisName , string thisState , int thisPrice, bool thisBool  )
        {
            _name = thisName;
            _state = thisState;
            _price = thisPrice;
            thisBonusList = bonus;
        }

        public string Name
        {
            get { return _name; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Advise MyAdivse
        {
            get { return thisBonusList; }
        }

        internal bool Buy( int money )
        {
            if( money >= _price )
            {
                _state = "activé";
                MyAdivse.MyGame.ThisUser.MyBank.UpdateAfterBuy(_price);
                return true;

            }
            else
            {
                return false;
            }
        }

        public Tuple<string, int> GetBonus()
        {
            return Tuple.Create( _name, _price );
        }

        internal bool GetState()
        {
            if( _state == "activé" )
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
