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
    public partial class PopUpAdvise : Form
    {
        Form1 f;
        GameContext u;
        public PopUpAdvise(Form1 f, GameContext u)
        {
            this.f = f;
            this.u = u;
            InitializeComponent();
            showAdvises();
        }

        private void showAdvises()
        {

            Advise B = u.ThisAdvise;
            Dictionary<string, Tuple<string,string, string>> D = B.Advises();
            int X = 2;
            foreach (var pair in B.ListOfAdvisors)
            {

                string name = pair.Name;
                string state = pair.State;

                System.Windows.Forms.Label Advise = new System.Windows.Forms.Label();
                Advise.Text = "";
                Advise.Name = pair.Name;
                Advise.AutoSize = true;
                Advise.Left = 300;
                Advise.Top = (X + 2) * 20;
                this.Controls.Add( Advise );
                X += 3;
                if (state == "activé")
                {

                    foreach( var test in D )
                    {

                        if( test.Value.Item1 == name )
                        {

                            if( test.Value.Item3 == "positif" )
                            {
                                Advise.Text += string.Format( " \n Votre {0} vous conseil de miser dans le domaine {1} ", name, test.Value.Item2 );
                            }
                            else
                            {
                                Advise.Text += string.Format( " \n Votre {0} vous conseil de ne pas miser dans le domaine {1}", name, test.Value.Item2 );
                            }
                        }
                    }
                }
                else {
                    Advise.Text = "Ce bonus n'est pas encore activé";

                }
                
            }
            
        }
        

    }
}
