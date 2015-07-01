using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace testProjet
{
    [Serializable]
    public class ActionsInfo 
    {
        Action a;
        public double value;
        public double ryse;
        public double previousRyse = 1.0;
        public double previousValue;
        public string type;
        public string name;
        public int possess;
        public bool affichage1;
        public bool affichage2;
        string C;
        Dictionary<string, string> newsDictionary = new Dictionary<string, string>();
        List<double> L = new List<double>();

        public int part;
        Dictionary<string, double> ActionValue = new Dictionary<string,double>();

        public ActionsInfo( Action a, string nom, double value,  double ryse,int part, string type, int possess, bool affichage1, bool affichage2, string C )
        {
            this.a = a;
            this.name = nom;
            this.value = value;
            this.ryse = ryse;
            this.type = type;
            this.possess = possess;
            this.affichage1 = affichage1;
            this.affichage2 = affichage2;
            this.C = C;
            previousValue = value;

            this.part = part;
            L.Add(value);
            
        }

        // Mise à jours des valeurs d'actions 
        public void Update()
        {
            previousValue = value;
            previousRyse = ryse;
            L.Add(value);
            if (value >= 5)
            {
                    if( ryse >= 1 )
                    {
                        ryse = Arrondir( 0.9);
                    }
            }
            if (value <= 0.33)
            {

                    if( ryse <= 1 )
                    {
                        ryse = Arrondir( 1.1);
                    }
                
            }
            LimitateMoove();
            value = Arrondir(value * ryse);
                
        }

        public Action up
        {
            get { return a; }
        }

        // Mise à jours de la montée des actions concernées par une news
        internal void ModifyRyse( Tuple<string, double, string> result )
        {
            
            string value;
            if (result.Item1 == type)
            {
                if (newsDictionary.TryGetValue(result.Item3, out value))
                {

                }
                else
                {
                    if (result.Item2 >1)
                    {
                        ryse = Arrondir( ryse * result.Item2 );
                        newsDictionary.Add( result.Item3, "positif" );
                    }
                    else
                    {
                        ryse = Arrondir( ryse * result.Item2 );
                        newsDictionary.Add( result.Item3, "negatif" );
                    }
                    
                }
                
            }            
            
        }
        // Arrondit un double à 3 chiffre après la virgule
        internal double Arrondir (double NombreAMofidier)
        {
            return Math.Round( NombreAMofidier, 3, MidpointRounding.AwayFromZero );
        }
        //Limite le mouvement des actions , pour éviter les trop gros écarts de chiffre 
        internal void LimitateMoove ()
        {
            if( ryse < 0.5 )
            {
                ryse = 1.1;
            }
            if( ryse > 2 )
            {
                ryse = 0.9;
            }
        }

        public Tuple<string, double,double> GetActionValue()
        {
            return Tuple.Create( name, value, ryse );
        }
        
        public double getValue()
        {
            return value;
        }

        public void BuyPart(int part)
        {
            this.part += part;
        }

        internal double getOnlyValue( string p )
        {
            if (name == p)
            {
                return  value ;
            }
            else
            {
                return 0;
            }
        }

        internal double getValueToSell(string Aname)
        {
            if( name == Aname )
            {
                return  value ;
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

        public void BuyAction(int buy)
        {

               possess += buy;
            
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
            if (name == subName)
            {
                if (p == 1)
                {
                    affichage1 = b;
                }
                else if (p== 2)
                {
                    affichage2 = b;
                }
                if (affichage2 == false)
                {

                }
            }
        }

        internal void tryStopNews( string title, string affect )
        {
            string res;
            if (newsDictionary.TryGetValue(title, out res))
            {
                newsDictionary.Remove( title );
            }
                                 
        }
    }
}
