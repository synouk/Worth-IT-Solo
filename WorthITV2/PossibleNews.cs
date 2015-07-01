using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorthITV2
{
    [Serializable]
    public class PossibleNews
    {
        NewsPaper thisGameNewsPaper;
        readonly string _title;
        readonly string _message;
        string _state;
        readonly int _activationChance;
        readonly int _desactivationChance;
        readonly int _type;
        readonly string _affect;
        readonly double _typeOfAffect;
        readonly string _bonusAdvisor;
        readonly string _extension;
        readonly int _extensionChance;
        public PossibleNews(NewsPaper thisNewsPaper, string title, string message, string state, int activationChance, int desactivationChance,int extensionChance,
            int type, string affect, double typeOfAffect, string BonusAdviser, string extension)
        {

            thisGameNewsPaper = thisNewsPaper;
            _title = title;
            _message = message;
            _state = state;
            _activationChance = activationChance;
            _desactivationChance = desactivationChance;
            _type = type;
            _affect = affect;
            _typeOfAffect = typeOfAffect;
            _bonusAdvisor = BonusAdviser;
            _extension = extension;
            _extensionChance = extensionChance;

        }

        public string Title
        {
            get { return _extension; }
        }

        public string Message
        {
            get { return _message; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public int ActivationChance
        {
            get { return _activationChance; }
        }

        public int DesactivationChance
        {
            get { return _desactivationChance; }
        }

        public int Type
        {
            get { return _type; }
        }

        public string Affect
        {
            get { return _affect; }
        }

        public double TypeOfAffect
        {
            get { return _typeOfAffect; }
        }

        public string BonusAdvisor
        {
            get { return _bonusAdvisor; }
        }

        public string extension
        {
            get { return _extension; }
        }

        public NewsPaper MyNewsPaper
        {
            get { return thisGameNewsPaper; }
        }

        public void Update()
        {
            if( _type == 2 )
            {
            }
            else
            {
                if( _state == "activé" )
                {
                    tryModifyState( _desactivationChance, _type );
                    MyNewsPaper.stopNewsAction( _title, _affect );
                }
                else
                {
                    tryModifyState( _activationChance, _type );
                }
            }

        }

        public void tryModifyState( int chances, int type )
        {

            int _modify = MyNewsPaper.MyGame.rand.Next( 1, 100 );
            if( _modify <= chances )
            {
                if( type == 1 )
                {
                    changeState();
                }
                else
                {
                }
            }

        }

        public void changeState()
        {
            if( _state == "désactivé" )
            {
                _state = "activé";

            }
            else
            {
                if( _extension != "none" )
                {
                    activateExtension( _extension );
                }
                _state = "désactivé";

            }
        }

        public void activateExtension( string extension )
        {

        }

        public Tuple<string, double, string> Check()
        {
            if( _state == "activé" )
            {
                return Tuple.Create( _affect, _typeOfAffect, _title );
            }
            else
            {
                return Tuple.Create( "none", 0.0, "" );
            }
        }

        internal Tuple<string, string> GetActivateNews()
        {
            if( _state == "activé" )
            {
                return Tuple.Create( _title, _message );
            }
            else
            {
                return Tuple.Create( _title, "désactivé" );
            }
        }
    }

     
}
