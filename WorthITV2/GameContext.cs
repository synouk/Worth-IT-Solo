using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class GameContext
    {
        Advise thisGameAdvise;
        User thisGameUser;
        Market thisGameMarket;
        NewsPaper thisGameNewsPaper;
        EmployerMarket thisGameEmployerMarket;
        Random rnd;
        Random random;

        public GameContext()
        {
            thisGameAdvise = new Advise(this);
            thisGameUser = new User( this );
            thisGameMarket = new Market( this );
            thisGameNewsPaper = new NewsPaper( this );
            thisGameEmployerMarket = new EmployerMarket( this );
            rnd = new Random();
            random = new Random();

        }

        public Advise ThisAdvise
        {
            get { return thisGameAdvise; }
        }

        public User ThisUser
        {
            get { return thisGameUser; }
        }

        public Market ThisMarket
        {
            get { return thisGameMarket; }
        }

        public NewsPaper ThisNewsPaper
        {
            get { return thisGameNewsPaper; }
        }

        public EmployerMarket ThisEmployerMarket
        {
            get { return thisGameEmployerMarket; }
        }

        public Random rand
        {
            get { return rnd; }
        }

        public void CheckNews( Tuple<string, double, string> result, Market market )
        {

            ThisMarket.ModifyRyse( result );
        }

        public double GetRandomNumber( double minimum, double maximum )
        {

            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        internal void BuyBonus( int prix, Bank bank )
        {
            ThisUser.MyBank.UpdateAfterBuy( prix );
        }

        public Tuple<string, int, int, string> NextTurn()
        {

            ThisMarket.UpdateActions();
            ThisNewsPaper.updateNews();
            ThisNewsPaper.checkNews( ThisMarket );
            ThisUser.MyBank.updateMoney();
            int money = ThisUser.MyBank.MyAccount.ThisAccountMoney;
            string employer = "yolo";

            return Tuple.Create( "clément", money, money, employer );



        }
    }
}
