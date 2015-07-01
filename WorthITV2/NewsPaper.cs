using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class NewsPaper
    {
        GameContext myGame;
        public List<PossibleNews> AllPossibleNewsList = new List<PossibleNews>();
        public NewsPaper(GameContext thisGameContext)
        {
            myGame = thisGameContext;

            PossibleNews criseAuCaire = new PossibleNews( this, "Une crise éclate au caire.", "Manifestations contre le gouvernement en place en Irak, le pays est paralisé", "désactivé", 10, 30, 10, 1, "Pétrole", 0.95, "Geopoliticien", "WW3" );
            PossibleNews Gisement = new PossibleNews( this, "Découverte d'une gisement", "Découverte d'un immense gisement de pétrole au coeur de la Gironde", "désactivé", 10, 30, 10, 1, "Pétrole", 1.05, "Ingénieur", "none" );
            PossibleNews CriseTextile = new PossibleNews( this, "Crise du textile", "L'industrie du textile en plus crise", "désactivé", 10, 30, 10, 1, "Vêtement", 0.95, "Geopoliticien", "none" );
            PossibleNews DéfiléMode = new PossibleNews( this, "Défilé de mode", "Incroyable succès du dernier défilé de mode parisien", "désactivé", 10, 30, 10, 1, "Vêtement", 1.05, "Coiffeuse", "none" );
            PossibleNews CriseTelephone = new PossibleNews( this, "Crise du téléphone", "15000 Iphone cassé chaque jour dans le monde , déja qu'ils ont pas de batterie...", "désactivé", 10, 30, 10, 1, "Mecano", 0.95, "Mecano", "none" );
            PossibleNews ExpansionConsole = new PossibleNews( this, "Expansion des jeux", "Le jeux vidéo fait un grand retour sur vos consoles cette année", "désactivé", 10, 30, 10, 1, "Electronique", 1.05, "Coiffeuse", "none" );
            PossibleNews CrashTest = new PossibleNews( this, "CrashTest", "D'après une récette enquète , les crash test des grandes compagnies de voitures seraient truqués", "désactivé", 10, 30, 10, 1, "Voiture", 0.95, "Coiffeuse", "none" );
            PossibleNews AlcolVolant = new PossibleNews( this, "Alcol au volant", "Loi Bourbon , l'alcolémie au volant est maintenant autorisé", "désactivé", 10, 30, 10, 1, "Voiture", 0.95, "Coiffeuse", "none" );
            PossibleNews FonciaVoleur = new PossibleNews( this, "FOncia vole ", "Une association indépendante a porté plainte contre Foncia contre escroquerie", "désactivé", 10, 30, 10, 1, "Commerial", 0.95, "Coiffeuse", "none" );
            PossibleNews BaisseDesprix = new PossibleNews( this, "Baisse des prix", "Baisse général du prix de l'immobilier dans toute la françe", "désactivé", 10, 30, 10, 1, "Immobilier", 1.05, "Commercial", "none" );
            PossibleNews Hack = new PossibleNews( this, "hack", "Hacking de tous les comptes tweeter", "désactivé", 10, 30, 10, 1, "Informatique", 0.95, "Mecano", "none" );
            PossibleNews LA5G = new PossibleNews( this, "5g", "La 5g est désormais disponible partout en françe", "désactivé", 10, 30, 10, 1, "Informatique", 1.05, "Mecano", "none" );

            AllPossibleNewsList.Add(criseAuCaire );
            AllPossibleNewsList.Add( Gisement );
            AllPossibleNewsList.Add( CriseTextile );
            AllPossibleNewsList.Add( DéfiléMode );
            AllPossibleNewsList.Add( CriseTelephone );
            AllPossibleNewsList.Add( ExpansionConsole );
            AllPossibleNewsList.Add( CrashTest );
            AllPossibleNewsList.Add( AlcolVolant );
            AllPossibleNewsList.Add( FonciaVoleur );
            AllPossibleNewsList.Add( BaisseDesprix );
            AllPossibleNewsList.Add( Hack );
            AllPossibleNewsList.Add( LA5G );
        }



        public GameContext MyGame
        {
            get { return myGame; }
        }

        public void updateNews()
        {
            foreach( var pair in AllPossibleNewsList)
            {
                pair.Update();

            }
        }

        public void activateExtension( string extension )
        {
        }

        public void checkNews( Market market )
        {
            foreach( var pair in AllPossibleNewsList )
            {
                Tuple<string, double, string> result =  pair.Check();
                MyGame.CheckNews( result, market );

            }
        }

        public Dictionary<string, string> GetActivateNews()
        {
            Dictionary <string,string > Activate = new Dictionary<string, string>();
            foreach( var pair in  AllPossibleNewsList)
            {
                Tuple<string , string > result = pair.GetActivateNews();
                if( result.Item2 != "désactivé" )
                {
                    Activate.Add( result.Item1, result.Item2 );
                }
            }
            return Activate;
        }

        internal void stopNewsAction( string title, string affect )
        {
            MyGame.ThisMarket.stopNewsAction( title, affect );
        }
    }
}
