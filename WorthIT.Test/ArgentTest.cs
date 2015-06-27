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
    public class ArgentTest
    {
        [TestCase( 200,1.0,1.5,100 ,700,1050  )]
        [TestCase( 500,1.5,1.0,100 , 1000,950)]
        [TestCase( 1000,2.0,1.0,500,1500,500)]
        [TestCase( 10000, 1.0, 3.5, 10000, 10500, 26000 )]
        public void SellAction_Argent_Test(int price, double Gvalue, double value, int number, int expectedNewPrice, int expectedNewNot)
        {
            user u = new user();
            u.argent.SellAction( price, Gvalue, value, number );
            int result = u.argent.GetMoney();
            int resultNotoriety = u.argent.getNotoriety();
            Assert.That( result, Is.EqualTo( expectedNewPrice ) );
            Assert.That(resultNotoriety, Is.EqualTo(expectedNewNot));
            
        }

        [TestCase(500,200,500,800)]
        [TestCase(200,500,200,500)]
        [TestCase(100,1500,100,-500)]
        public void UpdateNotorietyAfterNewEmployer_Argent_Test(int NewSalary, int NotToTake, int ExpectedSalary, int ExpectedNot)
        {
            user u = new user();
            u.argent.UpdateNotorietyAfterNewEmployer( NotToTake, NewSalary);
            int result = u.argent.getNotoriety();
            int result2 = u.argent.salary;

            Assert.That( result, Is.EqualTo( ExpectedNot ) );
            Assert.That(result2, Is.EqualTo(ExpectedSalary));
        }
    }
}
