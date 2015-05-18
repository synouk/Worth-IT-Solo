using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    class user
    {
        public Random rnd;
        public Random random;
    
        public user()
        {
            rnd = new Random();
            random = new Random();
            Action A = new Action(this);
            News N = new News(this);
            Bonus B = new Bonus( this );
            Argent Ar = new Argent( this );

            demonstration( A, N, Ar, B );
               
                

        }

        private void demonstration( Action A, News N, Argent Ar, Bonus B )
        {
            
            Console.WriteLine( "Appuyez sur une touche" );

            int key = Console.Read();

            NextTurn( A, N, Ar, B );
            Console.WriteLine( "--" );
            Console.WriteLine( "--" );

            demonstration( A,  N,  Ar,  B );
          
        }



        public void NextTurn( Action A, News N , Argent Ar, Bonus B)
        {
            if( A == null || N == null ) throw new ArgumentException( "Must be a class", "A, N" );
            A.UpdateActions();
            N.updateNews();
            N.checkNews(A);
            Ar.updateArgent();
            B.AchatBonus( Ar.GetArgent(), "ingénieur", Ar );
            

            
        }

        public Random rand
        {
            get { return rnd; }
        }



        public void CheckNews( Tuple<string, double> result, Action A )
        {
            if (result == null) throw new ArgumentException("Must be a tuple with a item1 string and item 2 double ", "result");
            if (A == null  ) throw new ArgumentException("Must be a class", "A");

            A.ModifyRyse(result);
        }

        public double GetRandomNumber( double minimum, double maximum )
        {
            if( minimum < 0 ) throw new ArgumentException( "Number must be >0 ", "minimum" );
            if( maximum > 1 ) throw new ArgumentException( "Number must be <1", "maximum" );

            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        internal void AchatBonus( int prix, Argent Ar )
        {
            Ar.UpdateApresAchat( prix );
        }
    }
}
