using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class User
    {

        Bank myBank;
        GameContext myGame;
        public User(GameContext thisGame)
        {
            myBank = new Bank(this);
            myGame = thisGame;

        }

        public GameContext MyGame
        {
            get { return myGame; }
        }

        public Bank MyBank
        {
            get { return myBank; }
        }
    }
}
