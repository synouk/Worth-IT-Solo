using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace testProjet
{
    [Serializable]
    public class user
    {
        public Random rnd;
        public Random random;
        public Action action;
        public News news;
        public Bonus bonus;
        public Argent argent;
        public Employer employer;


        
        public  user()
        {
            rnd = new Random();
            random = new Random();
            Action A = new Action(this);
            News N = new News(this);
            Bonus B = new Bonus( this );
            Argent Ar = new Argent( this );
            Employer E = new Employer( this );
            action = A;
            news = N;
            bonus = B;
            argent = Ar;
            employer = E;

                              

        }
 

        public Tuple<string, int, int , string>  NextTurn()
        {
            
            action.UpdateActions();
            news.updateNews();
            news.checkNews(action);
            argent.updateMoney();
            int money = argent.GetMoney();
            string employer = argent.GetEmployer();

            return Tuple.Create("clément", money, money, employer) ;
            

            
        }

        public void CheckNews( Tuple<string, double> result, Action A )
        {

            A.ModifyRyse(result);
        }

        public double GetRandomNumber( double minimum, double maximum )
        {

            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        internal void BuyBonus( int prix, Argent Ar )
        {
            Ar.UpdateAfterBuy( prix );
        }

        public News GetNews()
        {
            return news;
        }

        public Random rand
        {
            get { return rnd; }
        }

        public Action GetAction( )
        {
            return action;
        }

        public Argent GetMoney()
        {
            return argent;
        }

        public Employer GetEmployer()
        {
            return employer;
        }

        public Bonus GetBonus()
        {
            return bonus;
        }
    }
}
