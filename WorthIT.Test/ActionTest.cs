using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using testProjet;

namespace WorthIT.Test
{
    [TestFixture]
    public class ActionTest
    {
        [Test]
        public void Action_SellAction_Test()
        {
            user u = new user();
            testProjet.Action A = new testProjet.Action(u);
            ActionsInfo AI = new ActionsInfo( A, "Ford2", 1.0, 1.08, 0, "Voiture", 100, true, true, "Black" );
            A.A.Add( "Ford2", AI );
            A.SellAction( "Ford2", 100, 1.0 );
            int result = A.A["Ford2"].possess;

            Assert.That( result, Is.EqualTo( 0 ) );
            int result2 = u.argent.GetMoney();
            Assert.That( result2, Is.EqualTo( 600 ) );

            
        }
    }
}
