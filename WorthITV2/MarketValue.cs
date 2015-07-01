using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class MarketValue
    {
        Market thisMarket;
        readonly string  _name;
        double _value;
        double _ryse;
        double previousRyse;
        int _part;
        readonly string _type;
        int _possess;
        public bool affichage1;
        public bool affichage2;
        string C;
        double previousValue;
        Dictionary<string, string> newsDictionary = new Dictionary<string, string>();
        List<double> L = new List<double>();
        Dictionary<string, double> ActionValue = new Dictionary<string, double>();


        public MarketValue( Market market, string thisName, double thisValue, double thisRyse, int thisPart, string thisType, int thisPossess, bool show1, bool show2, string C )
        {
            thisMarket = market;
            _name = thisName;
            _value = thisValue;
            _ryse = thisRyse;
            _part = thisPart;
            _type = thisType;
            _possess = thisPossess;
            affichage1 = show1;
            affichage2 = show2;
            this.C = C;
            previousValue = _value;
            previousRyse = _ryse;
        }

        public string Name
        {
            get { return _name; }
        }

        public double PreviousValue
        {
            get { return previousValue; }
        }

        public double PreviousRyse
        {
            get { return previousRyse; }
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public double Ryse
        {
            get { return _ryse; }
            set { _ryse = value; }
        }

        public int Part
        {
            get { return _part; }
            set { _part = value; }
        }

        public string Type
        {
            get { return _type; }
        }

        public int Possess
        {
            get { return _possess; }
            set { _possess = value; }
        }

        public Market MyMarket
        {
            get { return thisMarket; }
        }

        public void Update()
        {
            previousValue = _value;
            previousRyse = _ryse;
            L.Add( _value );
            if( _value >= 5 )
            {
                if( _ryse >= 1 )
                {
                    _ryse = Arrondir( 0.9 );
                }
            }
            if( _value <= 0.33 )
            {

                if( _ryse <= 1 )
                {
                    _ryse = Arrondir( 1.1 );
                }

            }
            LimitateMoove();
            _value = Arrondir( _value * _ryse );

        }

        internal void ModifyRyse( Tuple<string, double, string> result )
        {

            string value;
            if( result.Item1 == _type )
            {
                if( newsDictionary.TryGetValue( result.Item3, out value ) )
                {

                }
                else
                {
                    if( result.Item2 > 1 )
                    {
                        _ryse = Arrondir( _ryse * result.Item2 );
                        newsDictionary.Add( result.Item3, "positif" );
                    }
                    else
                    {
                        _ryse = Arrondir( _ryse * result.Item2 );
                        newsDictionary.Add( result.Item3, "negatif" );
                    }

                }

            }

        }

        internal double Arrondir( double NombreAMofidier )
        {
            return Math.Round( NombreAMofidier, 3, MidpointRounding.AwayFromZero );
        }

        internal void LimitateMoove()
        {
            if( _ryse < 0.5 )
            {
                _ryse = 1.1;
            }
            if( _ryse > 2 )
            {
                _ryse = 0.9;
            }
        }

        public Tuple<string, double, double> GetActionValue()
        {
            return Tuple.Create( _name, _value, _ryse );
        }

        public void BuyPart( int part )
        {
            _part += part;
        }

        internal double getOnlyValue( string p )
        {
            if( _name == p )
            {
                return _value;
            }
            else
            {
                return 0;
            }
        }

        internal double getValueToSell( string Aname )
        {
            if( _name == Aname )
            {
                return _value;
            }
            else
            {
                return 0;
            }

        }

        internal double normalLaw()
        {
            Random rand = new Random(); //reuse this if you are generating many
            double u1 = rand.NextDouble(); //these are uniform(0,1) random doubles
            double u2 = rand.NextDouble();
            double randStdNormal = Math.Sqrt( -2.0 * Math.Log( u1 ) ) *
            Math.Sin( 2.0 * Math.PI * u2 ); //random normal(0,1)
            return randStdNormal;
        }

        public void BuyAction( int buy )
        {

            _possess += buy;

        }

        public string GetColor()
        {
            return C;
        }

        public List<double> getGraph()
        {
            return L;
        }

        internal void changeState( string subName, int p, bool b )
        {
            if( _name == subName )
            {
                if( p == 1 )
                {
                    affichage1 = b;
                }
                else if( p == 2 )
                {
                    affichage2 = b;
                }
                if( affichage2 == false )
                {

                }
            }
        }

        internal void tryStopNews( string title, string affect )
        {
            string res;
            if( newsDictionary.TryGetValue( title, out res ) )
            {
                newsDictionary.Remove( title );
            }

        }

    }
}
