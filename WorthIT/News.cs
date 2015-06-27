using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testProjet
{
    [Serializable]
    public class News
    {
        user u;
        public Dictionary<string,NewsInfo> N = new Dictionary<string, NewsInfo>();
        

        // Création des news et ajout dans le dictionary
        public News(user u)
        {
            this.u = u;

            NewsInfo criseAuCaire = new NewsInfo(this, "Une crise éclate au caire.", "Manifestations contre le gouvernement en place en Irak, le pays est paralisé", "désactivé",10,30,10,1, "Pétrole", 0.95,"Geopoliticien", "WW3");
            NewsInfo Gisement = new NewsInfo(this, "Découverte d'une gisement", "Découverte d'un immense gisement de pétrole au coeur de la Gironde", "désactivé",10,30,10,1,"Pétrole", 1.05, "Ingénieur", "none");
            NewsInfo CriseTextile = new NewsInfo( this, "Crise du textile", "L'industrie du textile en plus crise", "désactivé", 10, 30, 10, 1, "Vêtement", 0.95, "Geopoliticien", "none" );
            NewsInfo DéfiléMode = new NewsInfo(this, "Défilé de mode", "Incroyable succès du dernier défilé de mode parisien","désactivé",10,30,10,1,"Vêtement",1.05,"Coiffeuse","none");
            NewsInfo CriseTelephone = new NewsInfo( this, "Crise du téléphone", "15000 Iphone cassé chaque jour dans le monde , déja qu'ils ont pas de batterie...", "désactivé", 10, 30, 10, 1, "Mecano", 0.95, "Mecano", "none" );
            NewsInfo ExpansionConsole = new NewsInfo( this, "Expansion des jeux", "Le jeux vidéo fait un grand retour sur vos consoles cette année", "désactivé", 10, 30, 10, 1, "Electronique", 1.05, "Coiffeuse", "none" );
            NewsInfo CrashTest = new NewsInfo( this, "CrashTest", "D'après une récette enquète , les crash test des grandes compagnies de voitures seraient truqués","désactivé", 10, 30, 10, 1, "Voiture", 0.95, "Coiffeuse", "none" );
            NewsInfo AlcolVolant = new NewsInfo( this, "Alcol au volant", "Loi Bourbon , l'alcolémie au volant est maintenant autorisé", "désactivé", 10, 30, 10, 1, "Voiture", 0.95, "Coiffeuse", "none" );
            NewsInfo FonciaVoleur = new NewsInfo( this, "FOncia vole ", "Une association indépendante a porté plainte contre Foncia contre escroquerie","désactivé", 10, 30, 10, 1, "Commerial", 0.95, "Coiffeuse", "none" );
            NewsInfo BaisseDesprix = new NewsInfo( this, "Baisse des prix", "Baisse général du prix de l'immobilier dans toute la françe", "désactivé", 10, 30, 10, 1, "Immobilier", 1.05, "Commercial", "none" );
            NewsInfo Hack = new NewsInfo( this, "hack", "Hacking de tous les comptes tweeter", "désactivé", 10, 30, 10, 1, "Informatique", 0.95, "Mecano", "none" );
            NewsInfo LA5G = new NewsInfo (this , "5g", "La 5g est désormais disponible partout en françe","désactivé", 10,30,10,1,"Informatique", 1.05,"Mecano","none");



            N.Add( "criseAuCaire", criseAuCaire );
            N.Add("Gisement", Gisement);
            N.Add("CriseTextile",CriseTextile);
            N.Add( "DéfiléMode", DéfiléMode );
            N.Add( "CriseTelephone", CriseTelephone );
            N.Add( "ExpansionConsole", ExpansionConsole );
            N.Add( "CrashTest", CrashTest );
            N.Add("AlcolVolant",AlcolVolant);
            N.Add( "FonciaVoleur", FonciaVoleur );
            N.Add( "BaisseDesprix", BaisseDesprix );
            N.Add( "Hack", Hack );
            N.Add( "LA5G", LA5G );



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

        public Dictionary<string, string> GetActivateNews()
        {
            Dictionary <string,string > Activate = new Dictionary<string, string>();
            foreach( var pair in N )
            {
                Tuple<string , string > result = pair.Value.GetActivateNews();
                if (result.Item2 != "désactivé")
                {
                    Activate.Add( result.Item1, result.Item2 );
                }
            }
            return Activate;
        }

        
    }
}
