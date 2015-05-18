using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    class Bonus
    {
        user u;
        Dictionary<string, BonusInfo> B = new Dictionary<string,BonusInfo>();
        public Bonus(user u)
        {
            this.u = u;
            BonusInfo ingénieur = new BonusInfo (this,"ingénieur", "désactivé", 1000);
            B.Add ("ingénieur", ingénieur);
        }

        public void AchatBonus(int argent, string name, Argent Ar)
        {
            foreach( var pair in B )
            {
                if (pair.Key == name)
                {
                    pair.Value.Achat(argent, Ar);
                }

            }
        }

        public user user
        {
            get { return u; }
        }
    }
}
