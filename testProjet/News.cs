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

        // Création des news et ajout dans le dictionary
        public News(user u)
        {
            this.u = u;
            NewsInfo criseAuCaire = new NewsInfo(this, "Une crise éclate au caire", "le printemps arabe rentre dans une nouvelle phase avec des vagues de manifestation contre le gouvernement en place en égypte, le pays est paralisé", "désactivé",10,20,10,1, "Voiture", 1.05,"Geopoliticien", "WW3");
            NewsInfo criseAAlger = new NewsInfo(this, "Une crise éclate à Alger", "le printemps arabe rentre dans une nouvelle phase avec des vagues de manifestation contre le gouvernement en place en Algérie, le pays est paralisé", "désactivé",10,20,10, 1, "Pétrole", 1.05, "Geopoliticien","WW3" );
            NewsInfo BoumInformatique = new NewsInfo( this, "L' informatique en plein boum", "Les dernières avancées technologiques révolutionnent les moyens de communication", "désactivé", 10, 20, 10, 1, "Informatique", 1.05, "Economiste", "none" );
            NewsInfo NouveauTel = new NewsInfo( this, "Une nouveau téléphone vient de sortir", "Avec la sortie du nouveau téléphone de Samsung les concurrents n'ont qu'à bien se tenir", "désactivé", 10, 20, 10, 1, "Informatique", 0.95, "Ingénieur", "none" );
            NewsInfo VoitureElectrique = new NewsInfo( this, "L'électrique à la mode", "Tout le monde se met à la voiture électrique, ceux qui n'ont pas misé dessus vont prendre du retard", "désactivé", 10, 20, 10, 1, "Informatique", 0.95, "Voiture", "none" );
            NewsInfo ElectionsAAlger = new NewsInfo( this, "Le président sortant boutéflika réelu pour la 2111586 ème fois", "Avec cette nouvelle élection , le climat va se calmer en Algérie, le pétrole va revenir en masse sur le marché", "désactivé", 10, 80, 10, 1, "Pétrole", 0.95, "Geopoliticien", "none" );

            N.Add( "criseAuCaire", criseAuCaire );
            N.Add( "criseAAlger", criseAAlger );
            N.Add ("BoumInformatique", BoumInformatique);
            N.Add( "NouveauTel", NouveauTel );
            N.Add( "VoitureElectrique", VoitureElectrique);
            N.Add( "ElectionAAlger", ElectionsAAlger );
        }

        //Mise à jours de toutes les news 
        public void updateNews()
        {
            foreach( var pair in N )
            {
                pair.Value.Update();

            }
        }

        //Activation d'une extension
        public void activateExtension(string extension)
        {
        }

        public user user
        {
            get { return u; }
        }

        // Regarde chaque news , renvois le result
        public void checkNews(Action A)
        {
            foreach( var pair in N )
            {
               Tuple<string, double> result =  pair.Value.Check();
               u.CheckNews( result, A );

            }
        }
    }
}
