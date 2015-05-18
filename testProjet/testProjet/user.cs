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

            for( int i = 0; i < 10; i++ )
            {
                NextTurn( A, N );
            }
                

        }

        public void NextTurn( Action A, News N )
        {
            N.updateNews();
            N.checkNews(A);
            A.UpdateActions();
        }

        public Random rand
        {
            get { return rnd; }
        }



        public void CheckNews( Tuple<string, string> result, Action A )
        {
            A.ModifyRyse(result);
        }
    }
}
