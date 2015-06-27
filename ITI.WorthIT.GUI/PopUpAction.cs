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
    public partial class PopUpAction : Form
    {
        Form1 f;
        user u;
        testProjet.Action action;
        public Dictionary<string , Tuple<double, int>> actionToBuy = new Dictionary<string, Tuple<double, int>>();
        public double prix ;
        public PopUpAction(Form1 f, user u, testProjet.Action a)
        {
            InitializeComponent();
            this.f = f;
            this.u = u;
            this.action = a;
            ShowMyActions();
            prix = 0.0;
            label2.Text = prix.ToString();
        }

        private void ShowMyActions()
        {
            int X = 1;
            foreach( var pair in u.action.A)
            {
                //Create nale of action
                System.Windows.Forms.Label NameA = new System.Windows.Forms.Label();
                NameA.Text = pair.Value.name;
                NameA.AutoSize = true;
                //Position label on screen
                NameA.Left = 100;
                NameA.Top = (X + 1) * 20;
                //Add controls to form
                this.Controls.Add( NameA );

                System.Windows.Forms.Label PossessA = new System.Windows.Forms.Label();
                PossessA.Text = pair.Value.possess.ToString();
                PossessA.AutoSize = true;
                //Position label on screen
                PossessA.Left = 200;
                PossessA.Top = (X + 1) * 20;
                //Add controls to form
                this.Controls.Add( PossessA );


                //Create number of action
                System.Windows.Forms.NumericUpDown NumA= new System.Windows.Forms.NumericUpDown(); ;
                NumA.Name = pair.Value.name;
                NumA.Maximum = 500000;
                NumA.Value = 0;
                NumA.AutoSize = true;
                //Position label on screen
                NumA.Left = 300;
                NumA.Top = (X + 1) * 20;
                //Add controls to form
                this.Controls.Add( NumA );
                NumA.ValueChanged += new System.EventHandler( this.numericUpDown1_ValueChanged );
                

                //Create Sell button
                System.Windows.Forms.Button Sell = new System.Windows.Forms.Button();
                Sell.Text = "Vendre";
                Sell.AutoSize = true;
                //Position label on screen
                Sell.Left = 450;
                Sell.Top = (X + 1) * 20;
                Sell.Name = pair.Key;
                Sell.Click += new System.EventHandler( this.SellClick1 );
                //Add controls to form
                this.Controls.Add( Sell );
                
                X += 2;
            }

        }

        private void SellClick1( object sender, EventArgs e )
        {
            var sellingAction = sender as Button;
            string nameToSell = sellingAction.Name;
            Tuple<double, int> res;
            if (f.actionNumberAndValue.TryGetValue(nameToSell, out res))
            {
                action.SellAction( nameToSell, res.Item2, res.Item1 );
            }
            f.upTab();
            f.UpdateP();
        }

        private void numericUpDown1_ValueChanged( object sender, EventArgs e )
        {
            var numericUpDown = sender as NumericUpDown;
            int number = Convert.ToInt32( numericUpDown.Value );
            string name = numericUpDown.Name;
            double value = action.GetActionOnlyValue( name );
            Tuple<double, int> res;
            prix += number * value;
            if (actionToBuy.TryGetValue(name, out res))
            {
                actionToBuy[name] = Tuple.Create( res.Item1, res.Item2 + number );
            }
            else
            {
                actionToBuy.Add( name, Tuple.Create( value, number ) );
            }
            label2.Text = prix.ToString();

        }

        private void button2_Click( object sender, EventArgs e )
        {
            var res = sender as Button;
            Tuple<double, int> result;
            if (u.argent.GetMoney()> prix)
            {
                foreach (var pair in actionToBuy)
                {
                    action.BuyMyActions( pair.Value.Item1, pair.Value.Item2, pair.Key );
                    if (f.actionNumberAndValue.TryGetValue(pair.Key, out result))
                    {
                        
                        f.actionNumberAndValue[pair.Key] = Tuple.Create( (result.Item1 * result.Item2 + pair.Value.Item1 * pair.Value.Item2) / pair.Value.Item2 + result.Item2,
                            pair.Value.Item2 + result.Item2 );
                    }
                    else
                    {
                        f.actionNumberAndValue.Add( pair.Key, Tuple.Create( pair.Value.Item1, pair.Value.Item2 ) );
                    }
                }
                u.argent.UpdateAfterBuy( prix );
                prix = 0.0;
                f.upTab();
                f.UpdateP();
            }
            
        }
        
    }
}
