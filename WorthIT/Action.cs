using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace testProjet
{
    [Serializable]
    public class Action
    {
        user u;
        public Dictionary<string,ActionsInfo> A = new Dictionary<string, ActionsInfo>();
        
        
        //Création des actions et ajout dans le dictionary
        public Action(user u)
        {
            this.u = u;
            ActionsInfo Ford = new ActionsInfo( this, "Ford", 1.0, 1.08, 0, "Voiture", 0, true, true, "Black" );
            ActionsInfo Total = new ActionsInfo( this, "Total", 1.1, 1.05, 0, "Pétrole", 0, true, true, "Blue" );
            ActionsInfo Ubisoft = new ActionsInfo( this, "Ubisoft", 1.2, 0.99, 0, "Informatique", 0, true, true, "Cyan" );
            ActionsInfo Nokia = new ActionsInfo( this, "Nokia", 1.3, 0.98, 0, "Electronique", 0, true, true, "Green" );
            ActionsInfo Acer = new ActionsInfo( this, "Acer", 1.4, 0.99, 0, "Voiture", 0, true, true, "Magenta" );
            ActionsInfo Aesus = new ActionsInfo( this, "Aesus", 1.5, 0.99, 0, "Electronique", 0, true, true, "Red" );
            ActionsInfo Chanel = new ActionsInfo( this, "Chanel", 0.9, 1.01, 0, "Vêtements", 0, true, true, "DarkMagenta" );
            ActionsInfo BOSS = new ActionsInfo( this, "BOSS", 0.8, 1.01, 0, "Vêtements", 0, true, true, "Gray" );
            ActionsInfo Foncia = new ActionsInfo( this, "Foncia", 0.7, 1.15, 0, "Immobilier", 0, true, true,"DarkRed" );
            ActionsInfo Seloger = new ActionsInfo( this, "Seloger", 0.5, 0.99, 0, "Immobilier", 0, true, true, "DarkBlue" );
            ActionsInfo Nissan = new ActionsInfo( this, "Nissan", 0.6, 1.1, 0, "Voiture", 0, true, true, "DarkGray" );
            

            A.Add( "Ford", Ford );
            A.Add( "Total", Total );
            A.Add( "Ubisoft", Ubisoft );
            A.Add( "Nokia", Nokia );
            A.Add( "Acer", Acer );
            A.Add( "Aesus", Aesus );
            A.Add( "Chanel", Chanel );
            A.Add( "BOSS", BOSS );
            A.Add( "Foncia", Foncia );
            A.Add( "Seloger", Seloger );
            A.Add( "Nissan", Nissan );
            

        }
        //Mise à jours des actions
        public void UpdateActions()
        {  
            foreach (var pair in A)
            {
                pair.Value.Update();               
            
            }
        }

        public List<ActionsInfo> GetActionsInfo()
        {
            List<ActionsInfo> Ai = new List<ActionsInfo>();
            foreach (var pair in A)
            {
                Ai.Add( pair.Value );
                
            }
            return Ai;
        }

        public user user
        {
            get { return u; }
        }
        //Modifie la valeur de monté des actions concernées par une news
        internal void ModifyRyse( Tuple<string, double, string> result )
        {
            foreach( var pair in A )
            {
                pair.Value.ModifyRyse(result);
            }
        }

        public Dictionary<string, Tuple<double, double>> GetActionValue()
        {
            Dictionary <string,Tuple<double,double> > D = new Dictionary<string, Tuple<double, double>>();
            foreach( var pair in A )
            {
                Tuple<string ,double,double > result = pair.Value.GetActionValue();
                D.Add( result.Item1, Tuple.Create( result.Item2, result.Item3) );
            }
            return D;
        }

        public double GetActionOnlyValue( string p )
        {
            double result = 0.0;
           foreach (var pair in A)
           {
               if (pair.Value.getOnlyValue(p) !=0)
               {
                   result = pair.Value.getOnlyValue( p );
               }
           }
           return result;
               
        }

        public void SellAction( string name, int actionNumber, double actionGlobalValue )
        {

            double value = A[name].value;
                    int newPrice = Convert.ToInt32(actionNumber * actionGlobalValue);
                    user.argent.SellAction( newPrice, actionGlobalValue, value, actionNumber );
                    A[name].possess = 0;
        }

        public void changeState( string subName, int p, bool b )
        {
            foreach (var pair in A)
            {
                pair.Value.changeState(subName, p, b);
            }
        }

        public void BuyMyActions( double p1, int p2, string p3 )
        {
            ActionsInfo res;
            if (A.TryGetValue(p3, out res))
            {
                res.BuyAction( p2 );
                user.argent.UpdateAfterBuy( p1 * p2 );
            }
            
        }

        internal void stopNewsAction( string title, string affect )
        {
            foreach (var pair in A)
            {
                pair.Value.tryStopNews(title, affect);
            }
        }
    }
       
}

