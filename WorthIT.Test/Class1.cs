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
    public class EmployerTest
    {
        [Test]
        public void Constructor_EmployerInfos_Test()
        {
            user u = new user();
            Employer Employer = new Employer( u ); ;
            EmployerInfo E = new EmployerInfo( Employer, "clément", 1000, 2000, "actif", true );

            string result = E.name;
            var empl = E.E;
            int money = E.money;
            int not = E.notoriety;
            string state = E.state;
            bool res = E.achat;

            Assert.That( result, Is.EqualTo( "clément" ) );
            Assert.That( empl, Is.EqualTo( Employer ) );
            Assert.That( money, Is.EqualTo( 1000 ) );
            Assert.That( not, Is.EqualTo( 2000 ) );
            Assert.That( state, Is.EqualTo( "actif" ) );
            Assert.That( res, Is.True );

        }

        [TestCase( 1000, false )]
        [TestCase( 2500, true )]
        [TestCase( 1500, false )]
        public void CheckEmployer_Test( int notoriety, bool expectedResult )
        {
            user u = new user();
            Employer Employer = new Employer( u ); ;
            EmployerInfo E = new EmployerInfo( Employer, "clément", 1000, 2000, "actif", true );

            bool result = E.CheckEmployer( notoriety );

            Assert.That( result, Is.EqualTo(expectedResult) );
        }

        [Test]
        public void EmployerInfos_NewEMployer_Test()
        {
            user u = new user();
            Employer Employer = new Employer( u ); ;
            EmployerInfo E = new EmployerInfo( Employer, "clément", 1000, 2000, "inactif", true );
            E.NewEmployer();
            string result = E.state;

            Assert.That( result, Is.EqualTo( "actif" ) );
        }

        [Test]
        public void EmployerInfos_OldEmployerDelete_Test()
        {
            user u = new user();
            Employer Employer = new Employer( u ); ;
            EmployerInfo E = new EmployerInfo( Employer, "clément", 1000, 2000, "actif", true );

            E.OldEmployerDelete();
            string result = E.state;

            Assert.That( result, Is.EqualTo( "inactif" ) );
        }

        [Test]
        public void EmployerInfos_GetEMployer_Test()
        {
            user u = new user();
            Employer Employer = new Employer( u ); ;
            EmployerInfo E = new EmployerInfo( Employer, "clément", 1000, 2000, "actif", true );

            Tuple<string , int , int , string> result = E.GetEmployer();

            Assert.That( result, Is.EqualTo( Tuple.Create( E.name, E.money, E.notoriety, E.state ) ) );
        }

        [Test]
        public void Employer_ChangeEmployer_Test()
        {
            user u = new user();
            Employer Employer = u.employer;

            Employer.ChangeEmployer( "BNP" );

            string result = "BNP";

            Assert.That( result, Is.EqualTo(Employer.employer) );
        }
    }
}
