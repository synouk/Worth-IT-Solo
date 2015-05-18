using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    class News
    {
        user u;
        Dictionary<string,NewsInfo> N = new Dictionary<string, NewsInfo>();
        public News(user u)
        {
            this.u = u;
            NewsInfo criseAuCaire = new NewsInfo(this, "Une crise éclate au caire", "le printemps arabe rentre dans une nouvelle phase avec des vagues de manifestation contre le gouvernement en place en égypte, le pays est paralisé", "activé",7,3,9,1, "Voiture", "négatif","Geopoliticien", "WW3");
//            NewsInfo criseAAlger = new NewsInfo(this, "Une crise éclate à Alger", "le printemps arabe rentre dans une nouvelle phase avec des vagues de manifestation contre le gouvernement en place en Algérie, le pays est paralisé", "désactivé",8,8, 97, 1, "Pétrole", "negatif", "Geopoliticien","WW3" );
//            NewsInfo boumInformatique = new NewsInfo( this, "Linformatique en plein boum", "Les dernières avancées technologiques révolutionnent les moyens de communication", "désactivé", 6, 9, 97, 1, "Informatique", "Positif", "Economiste", "none" );
//            NewsInfo WW3 = new NewsInfo( this, "Guerre mondiale", "cey la guerre !", "désactivé", 1, 5, 97, 1, "voiture", "negatif", "Geopoliticien", "none" );

//            N.Add( "WW3", WW3 );
            N.Add( "criseAuCaire", criseAuCaire );
//            N.Add( "criseAAlger", criseAAlger );
        }

        public void updateNews()
        {
            foreach( var pair in N )
            {
                pair.Value.Update();

            }
        }
        public void activateExtension(string extension)
        {
        }

        public user user
        {
            get { return u; }
        }

        public void checkNews(Action A)
        {
            foreach( var pair in N )
            {
               Tuple<string, string> result =  pair.Value.Check();
               u.CheckNews( result, A );

            }
        }
    }
}
