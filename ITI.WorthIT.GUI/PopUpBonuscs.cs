using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorthITV2;

namespace ITI.WorthIT.GUI
{
    public partial class PopUpBonuscs : Form
    {
        Form1 f;
        GameContext u;
        public PopUpBonuscs(Form1 f, GameContext u)
        {
            this.f = f;
            this.u = u;
            InitializeComponent();
            showBonus();
        }

        private void showBonus()
        {
            int X = 1;
            Advise B = u.ThisAdvise;
            foreach (var pair in B.ListOfAdvisors)
            {
                System.Windows.Forms.Label NameE = new System.Windows.Forms.Label();
                NameE.Text = pair.Name;
                NameE.AutoSize = true;
                NameE.Left = 100;
                NameE.Top = (X + 1) * 20;
                this.Controls.Add( NameE );

                System.Windows.Forms.Label price = new System.Windows.Forms.Label();
                price.Text = pair.Price.ToString();
                price.AutoSize = true;
                price.Left = 300;
                price.Top = (X + 1) * 20;
                this.Controls.Add( price );

                if( pair.State == "désactivé" )
                {
                    System.Windows.Forms.Button Activate = new System.Windows.Forms.Button();
                    Activate.Text = "Embaucher cette personne";
                    Activate.AutoSize = true;
                    Activate.Left = 400;
                    Activate.Top = (X + 1) * 20;
                    Activate.Name = pair.Name;
                    Activate.Click += new System.EventHandler( this.ActivateClick );
                    this.Controls.Add( Activate );
                }
                else
                {
                    System.Windows.Forms.Label State = new System.Windows.Forms.Label();
                    State.Text = "En plein travail";
                    State.AutoSize = true;
                    State.Left = 400;
                    State.Top = (X + 1) * 20;
                    this.Controls.Add( State );
                }
                X += 2;
            }
        }

        private void ActivateClick( object sender, EventArgs e )
        {
            var data = sender as Button;
            Advise B = u.ThisAdvise;
            B.BuyBonus( data.Name );
            f.UpdateAll();
        }
    }
}
