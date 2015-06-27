using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testProjet;

namespace ITI.WorthIT.GUI
{
    public partial class PopUpAdvise : Form
    {
        Form1 f;
        user u;
        public PopUpAdvise(Form1 f, user u)
        {
            this.f = f;
            this.u = u;
            InitializeComponent();
            showAdvises();
        }

        private void showAdvises()
        {
            
            Bonus B = u.bonus;
            Dictionary<string, Tuple<string,string, string>> D = B.Advises();
            int X = 2;
            foreach (var pair in B.B)
            {
                
                string name = pair.Value.name;
                string state = pair.Value.state;

                System.Windows.Forms.Label Advise = new System.Windows.Forms.Label();
                Advise.Text = "";
                Advise.Name = pair.Value.name;
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
