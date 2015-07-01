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
    public partial class PopUpEmployer : Form
    {
        WorthITV2.GameContext ThisGame;
        Form1 f;
        public PopUpEmployer( Form1 f, WorthITV2.GameContext thisGame )
        {
            ThisGame = thisGame;
            this.f = f;
            InitializeComponent();
            showEmployer();
        }


        public void showEmployer()
        {
            int X = 1;
            EmployerMarket E = ThisGame.ThisEmployerMarket;
            foreach (var pair in E.allPossibleEmployerList)
            {
                System.Windows.Forms.Label NameE = new System.Windows.Forms.Label();
                NameE.Text = pair.ThisEmployerName;
                NameE.AutoSize = true;
                NameE.Left = 100;
                NameE.Top = (X + 1) * 20;
                this.Controls.Add( NameE );

                System.Windows.Forms.Label SalaryE = new System.Windows.Forms.Label();
                SalaryE.Text = pair.ThisEmployerSalary.ToString();
                SalaryE.AutoSize = true;
                SalaryE.Left = 200;
                SalaryE.Top = (X + 1) * 20;
                this.Controls.Add( SalaryE );

                System.Windows.Forms.Label NotE = new System.Windows.Forms.Label();
                NotE.Text = pair.ThisEmployerNotorietyRequire.ToString();
                NotE.AutoSize = true;
                NotE.Left = 300;
                NotE.Top = (X + 1) * 20;
                this.Controls.Add( NotE );

                if (pair.ThisEmployerState == "inactif")
                {
                    System.Windows.Forms.Button Activate = new System.Windows.Forms.Button();
                    Activate.Text = "Se faire embaucher";
                    Activate.AutoSize = true;
                    Activate.Left = 400;
                    Activate.Top = (X + 1) * 20;
                    Activate.Name = pair.ThisEmployerName;
                    Activate.Click += new System.EventHandler( this.ActivateClick );
                    this.Controls.Add( Activate );
                }
                else
                {
                    System.Windows.Forms.Label State = new System.Windows.Forms.Label();
                    State.Text = "Cet employer est actif";
                    State.AutoSize = true;
                    State.Left = 400;
                    State.Top = (X + 1) * 20;
                    this.Controls.Add( State );
                }
                

                X+=2;
            }
        }

        private void ActivateClick( object sender, EventArgs e )
        {
            var data = sender as Button;
            string name = data.Name;
            EmployerMarket E = ThisGame.ThisEmployerMarket;
            E.ChangeEmployer( name );
            f.UpdateP();

            
        }
    }
}
