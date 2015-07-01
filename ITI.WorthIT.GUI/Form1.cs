using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using BrightIdeasSoftware.Design;
using BrightIdeasSoftware.Properties;
using BrightIdeasSoftware;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using WorthITV2;

namespace ITI.WorthIT.GUI
{
    public partial class Form1 : Form
    {
        ListViewItem heldDownItem;
        Point heldDownPoint;
        private Timer timer1 = new Timer();
        private Timer timeTurn = new Timer();
        Timer timerFast = new Timer();
        private int i = 0;
        public int tour = 1;
        public Dictionary <string , LineItem> CurveName = new Dictionary<string, LineItem>();
        public Dictionary <string , LineItem> CurveName2 = new Dictionary<string, LineItem>();
        public Dictionary<string , Tuple<double, int>> actionNumberAndValue = new Dictionary<string, Tuple<double, int>>();
        GameContext thisGame;


        public Form1()
        {

             thisGame = new GameContext();
            InitializeComponent();
            timer1.Tick += new EventHandler( timer1_Tick );
            timeTurn.Tick += new EventHandler( timer2_Tick );
            timeTurn.Interval = 25000;
            timeTurn.Start();
            timer1.Interval = 200;
            timer1.Start();

            typeof( Control ).GetProperty( "DoubleBuffered",
                             System.Reflection.BindingFlags.NonPublic |
                             System.Reflection.BindingFlags.Instance )
               .SetValue( objectListView1, true, null );

            UpdateAll();



        }

        private void timer2_Tick( object sender, EventArgs e )
        {
            Tuple <string, int , int , string> result = thisGame.NextTurn();

            string  pseudo = result.Item1;
            string  argent = Convert.ToString( result.Item2 );
            string notoriété = Convert.ToString( result.Item3 );
            string employer = result.Item4;
            int not = thisGame.ThisUser.MyBank.MyAccount.ThisAccountNotoriety;
            string noto = not.ToString();

            UpdateAll();
            i = 0;
        }

        private void listViewInvisible()
        {
            objectListView1.Visible = false;
            objectListView2.Visible = false;
            objectListView3.Visible = false;
        }

        private void timer1_Tick( object sender, EventArgs e )
        {
            string strString = "";
            NewsPaper news = thisGame.ThisNewsPaper;
            Dictionary <string , string > News = news.GetActivateNews();
            foreach( var pair in News )
            {
                strString += "  Breaking News:  " + pair.Value;
            }
            label6.Text = string.Concat( strString.Substring( i ) );
            if( i >= strString.Length )
            {
                i = 0;
            }

            else
            {
                i++;
            }
        }

        public void showGraph()
        {
            foreach( var pair in thisGame.ThisMarket.ListOfAllMarket)
            {

                double value = pair.Value;
                string C = pair.GetColor();
                string name = pair.Name;
                List<double> L = pair.getGraph();
                int x = 1;
                PointPairList list1 = new PointPairList();
                foreach( double V in L )
                {
                    list1.Add( x, V );
                    x++;
                }
                LineItem myCurve =zedGraphControl1.GraphPane.AddCurve( name, list1, Color.FromName( C ) );
                CurveName.Add( name, myCurve );


                LineItem myCurve2 =zedGraphControl2.GraphPane.AddCurve( name, list1, Color.FromName( C ) );
                CurveName2.Add( name, myCurve2 );

                foreach( var obj in thisGame.ThisMarket.ListOfAllMarket )
                {
                    if( obj.affichage1 == true )
                    {
                        curveVisibility( obj.Name );
                    }
                    else if( obj.affichage1 == false )
                    {
                        curveNoVisibility( obj.Name );
                    }
                    if( obj.affichage2 == true )
                    {
                        curveVisibility2( obj.Name );
                    }
                    else if( obj.affichage2 == false )
                    {
                        curveNoVisibility2( obj.Name );
                    }
                }

                zedGraphControl1.Invalidate();
                zedGraphControl1.AxisChange();
                zedGraphControl2.Invalidate();
                zedGraphControl2.AxisChange();






            }

            tour++;
        }

        private void Employer_Click( object sender, EventArgs e )
        {
        }

        public void UpdateP()
        {

            label4.Text = thisGame.ThisUser.MyBank.MyAccount.ThisAccountMoney.ToString();
            label3.Text = thisGame.ThisUser.MyBank.MyAccount.ThisAccountNotoriety.ToString();
            label5.Text = thisGame.ThisEmployerMarket.MyEmployer().ToString();
            upTab();
            showEmployer();
            showBonus();

        }

        public void upTab()
        {

            List<MarketValue> Ai = thisGame.ThisMarket.GetActionsInfo();
            this.objectListView1.SetObjects( Ai );


        }

        public void showEmployer()
        {
            EmployerMarket E = thisGame.ThisEmployerMarket;
            List<PossibleEmployer> L = E.getEmployerInfo();
            this.objectListView2.SetObjects( L );

        }

        public void showBonus()
        {
            List<Advisors> L = thisGame.ThisAdvise.getBonusInfo();
            this.objectListView3.SetObjects( L );
        }

        private void objectListView1_SubItemChecking( object sender, SubItemCheckingEventArgs e )
        {
            foreach( ListViewItem item in objectListView1.Items )
            {
                string subName = item.SubItems[0].Text;
                if( item.SubItems[5].Text == "True" )
                {
                    thisGame.ThisMarket.changeState( subName, 1, true );
                }
                else if( item.SubItems[5].Text == "False" )
                {
                    thisGame.ThisMarket.changeState( subName, 1, false );
                }
                if( item.SubItems[6].Text == "True" )
                {
                    thisGame.ThisMarket.changeState( subName, 2, true );
                }
                else if( item.SubItems[6].Text == "False" )
                {
                    thisGame.ThisMarket.changeState( subName, 2, false );
                }
            }

            timerFast.Interval = 200;
            timerFast.Start();
            timerFast.Tick += new EventHandler( timer3_Tick );


        }

        private void timer3_Tick( object sender, EventArgs e )
        {

            timerFast.Stop();
            CurveName.Clear();
            CurveName2.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            showGraph();
            upTab();
            showEmployer();
            showBonus();

        }

        private void curveVisibility( string name )
        {
            LineItem MyCurveTest;
            foreach( var pair in CurveName )
            {
                if( CurveName.TryGetValue( name, out MyCurveTest ) )
                {

                    MyCurveTest.IsVisible = true;

                }
            }
        }

        private void curveNoVisibility( string name )
        {
            LineItem MyCurveTest;
            foreach( var pair in CurveName )
            {
                if( CurveName.TryGetValue( name, out MyCurveTest ) )
                {
                    MyCurveTest.IsVisible = false;

                }
            }
        }

        private void curveVisibility2( string name )
        {
            LineItem MyCurveTest;
            foreach( var pair in CurveName2 )
            {
                if( CurveName2.TryGetValue( name, out MyCurveTest ) )
                {

                    MyCurveTest.IsVisible = true;

                }
            }
        }

        private void curveNoVisibility2( string name )
        {
            LineItem MyCurveTest;
            foreach( var pair in CurveName2 )
            {
                if( CurveName2.TryGetValue( name, out MyCurveTest ) )
                {
                    MyCurveTest.IsVisible = false;

                }
            }
        }

        private void objectListView1_MouseDown( object sender, MouseEventArgs e )
        {
            //listView1.AutoArrange = false;
            heldDownItem = objectListView1.GetItemAt( e.X, e.Y );
            if( heldDownItem != null )
            {
                heldDownPoint = new Point( e.X - heldDownItem.Position.X,
                                          e.Y - heldDownItem.Position.Y );
            }
        }
        //MouseMove event handler for your listView1
        private void objectListView1_MouseMove( object sender, MouseEventArgs e )
        {
            if( heldDownItem != null )
            {
                heldDownItem.Position = new Point( e.Location.X - heldDownPoint.X,
                                                  e.Location.Y - heldDownPoint.Y );
            }
        }
        //MouseUp event handler for your listView1
        private void objectListView1_MouseUp( object sender, MouseEventArgs e )
        {
            heldDownItem = null;
            //listView1.AutoArrange = true;         
        }

        private void fimeToolStripMenuItem_Click( object sender, EventArgs e )
        {
            pause();
            PopUpAction popup = new PopUpAction( this, thisGame, thisGame.ThisMarket );
            DialogResult dialogresult = popup.ShowDialog();
            popup.Dispose();
        }

        private void employeurToolStripMenuItem_Click( object sender, EventArgs e )
        {
            pause();
            PopUpEmployer popup = new PopUpEmployer( this, thisGame );
            DialogResult dialogresult = popup.ShowDialog();
            popup.Dispose();
        }

        private void acheterUnBonusToolStripMenuItem_Click( object sender, EventArgs e )
        {
            pause();
            PopUpBonuscs popup = new PopUpBonuscs( this, thisGame );
            DialogResult dialogresult = popup.ShowDialog();
            popup.Dispose();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            label7.Visible = true;
            timeTurn.Stop();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            label7.Visible = false;
            timeTurn.Interval = 25000;
            timeTurn.Start();
        }

        private void button3_Click( object sender, EventArgs e )
        {
            label7.Visible = false;
            timeTurn.Interval = 15000;
            timeTurn.Start();
        }

        private void button4_Click( object sender, EventArgs e )
        {
            label7.Visible = false;
            timeTurn.Interval = 5000;
            timeTurn.Start();
        }

        private void pause()
        {
            label7.Visible = true;
            timeTurn.Stop();
        }

        private void conseilsActifsToolStripMenuItem_Click( object sender, EventArgs e )
        {
            pause();
            PopUpAdvise popup = new PopUpAdvise( this, thisGame);
            DialogResult dialogresult = popup.ShowDialog();
            popup.Dispose();
        }

        private void button5_Click( object sender, EventArgs e )
        {
            string path = @"C:\Dev\S3\testProjet\Sauvegarde\Exemple1.bin";
            using( Stream stream = File.Open( path, FileMode.Create ) )
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize( stream, thisGame );
            }

        }

        private void button6_Click( object sender, EventArgs e )
        {
            string path = @"C:\Dev\S3\testProjet\Sauvegarde\Exemple1.bin";
            GameContext newUser =  LoadFile( path );
            thisGame = newUser;
            UpdateAll();
            
        }

        public GameContext LoadFile (string path)
        {
            try
            {
                System.IO.FileStream _FileStream = new System.IO.FileStream( path, System.IO.FileMode.Open, System.IO.FileAccess.Read );
                System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader( _FileStream );
                long _TotalBytes = new System.IO.FileInfo( path ).Length;
                byte[] _ByteArray = _BinaryReader.ReadBytes( (Int32)_TotalBytes );
                _FileStream.Close();
                _FileStream.Dispose();
                _FileStream = null;
                _BinaryReader.Close();
                System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream( _ByteArray );
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter _BinaryFormatter
	                    = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                _MemoryStream.Position = 0;
                return _BinaryFormatter.Deserialize( _MemoryStream ) as GameContext;

            }
            catch( Exception _Exception )
            {
                Console.WriteLine( "Exception caught in process: {0}", _Exception.ToString() );
                return null;
            }
        }

        public void UpdateAll()
        {
            UpdateP();
            upTab();
            showEmployer();
            showBonus();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            CurveName.Clear();
            CurveName2.Clear();
            showGraph();
        }

        private void Form1_Load( object sender, EventArgs e )
        {

        }
    }
}
