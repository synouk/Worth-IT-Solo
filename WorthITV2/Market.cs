using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
     [Serializable]
    public class Market
    {
         public List<MarketValue> ListOfAllMarket = new List<MarketValue>();
        GameContext myGame;
        public Market(GameContext thisGame)
        {
            myGame = thisGame;

            MarketValue Ford = new MarketValue( this, "Ford", 1.0, 1.08, 0, "Voiture", 0, true, true, "Black" );
            MarketValue Total = new MarketValue( this, "Total", 1.1, 1.05, 0, "Pétrole", 0, true, true, "Blue" );
            MarketValue Ubisoft = new MarketValue( this, "Ubisoft", 1.2, 0.99, 0, "Informatique", 0, true, true, "Cyan" );
            MarketValue Nokia = new MarketValue( this, "Nokia", 1.3, 0.98, 0, "Electronique", 0, true, true, "Green" );
            MarketValue Acer = new MarketValue( this, "Acer", 1.4, 0.99, 0, "Voiture", 0, true, true, "Magenta" );
            MarketValue Aesus = new MarketValue( this, "Aesus", 1.5, 0.99, 0, "Electronique", 0, true, true, "Red" );
            MarketValue Chanel = new MarketValue( this, "Chanel", 0.9, 1.01, 0, "Vêtements", 0, true, true, "DarkMagenta" );
            MarketValue BOSS = new MarketValue( this, "BOSS", 0.8, 1.01, 0, "Vêtements", 0, true, true, "Gray" );
            MarketValue Foncia = new MarketValue( this, "Foncia", 0.7, 1.15, 0, "Immobilier", 0, true, true, "DarkRed" );
            MarketValue Seloger = new MarketValue( this, "Seloger", 0.5, 0.99, 0, "Immobilier", 0, true, true, "DarkBlue" );
            MarketValue Nissan = new MarketValue( this, "Nissan", 0.6, 1.1, 0, "Voiture", 0, true, true, "DarkGray" );

            ListOfAllMarket.Add( Ford );
            ListOfAllMarket.Add( Total );
            ListOfAllMarket.Add( Ubisoft );
            ListOfAllMarket.Add( Nokia );
            ListOfAllMarket.Add( Acer );
            ListOfAllMarket.Add( Aesus );
            ListOfAllMarket.Add( Chanel );
            ListOfAllMarket.Add( BOSS );
            ListOfAllMarket.Add( Foncia );
            ListOfAllMarket.Add( Seloger );
            ListOfAllMarket.Add( Nissan );

        }

        public GameContext MyGame
        {
            get { return myGame; }
        }

        public MarketValue CheckValueName( string nameToTest )
        {
            MarketValue result = null;
            foreach( var pair in ListOfAllMarket )
            {
                if( nameToTest == pair.Name )
                {
                    result = pair;
                }
            }
            return result;
        }

        public void UpdateActions()
        {
            foreach( var pair in ListOfAllMarket )
            {
                pair.Update();

            }
        }

        public List<MarketValue> GetActionsInfo()
        {
            List<MarketValue> Ai = new List<MarketValue>();
            foreach( var pair in ListOfAllMarket )
            {
                Ai.Add( pair );

            }
            return Ai;
        }

        internal void ModifyRyse( Tuple<string, double, string> result )
        {
            foreach( var pair in ListOfAllMarket )
            {
                pair.ModifyRyse( result );
            }
        }

        public Dictionary<string, Tuple<double, double>> GetActionValue()
        {
            Dictionary <string,Tuple<double,double> > D = new Dictionary<string, Tuple<double, double>>();
            foreach( var pair in ListOfAllMarket )
            {
                Tuple<string ,double,double > result = pair.GetActionValue();
                D.Add( result.Item1, Tuple.Create( result.Item2, result.Item3 ) );
            }
            return D;
        }

        public double GetActionOnlyValue( string p )
        {
            double result = 0.0;
            foreach( var pair in ListOfAllMarket )
            {
                if( pair.getOnlyValue( p ) != 0 )
                {
                    result = pair.getOnlyValue( p );
                }
            }
            return result;

        }

        public void SellAction( string name, int actionNumber, double actionGlobalValue )
        {
            foreach (var pair in ListOfAllMarket)
            {
                if (pair.Name == name)
                {
                    double value = pair.Value;
                    int newPrice = Convert.ToInt32( actionNumber * actionGlobalValue );
                    myGame.ThisUser.MyBank.SellAction( newPrice, actionGlobalValue, value, actionNumber );
                    pair.Possess = 0;

                }
            }
        }

        public void changeState( string subName, int p, bool b )
        {
            foreach( var pair in ListOfAllMarket )
            {
                pair.changeState( subName, p, b );
            }
        }

        public void BuyMyActions( double p1, int p2, string p3 )
        {
            var res = CheckValueName( p3 );
            if (res != null)
            {
                res.BuyAction( p2 );
                myGame.ThisUser.MyBank.UpdateAfterBuy( p1 * p2 );
            }
        }

        internal void stopNewsAction( string title, string affect )
        {
            foreach( var pair in ListOfAllMarket )
            {
                pair.tryStopNews( title, affect );
            }
        }
    }
}
