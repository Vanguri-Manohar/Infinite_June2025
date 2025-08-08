using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProj;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Test_MiniProject
{   [TestFixture]
    public class Class1
    {   [Test]
        public static void Test_Admin()
        {

            string username = "Manohar";
            string password = "Manohar123";
            string Role = Program.AuthenticateAdmin(username,password);
            ClassicAssert.AreEqual("admin", Role);
            

        }
        [Test]
        public static void Test_InValidAdmin()
        {

            string username = "Manohar";
            string password = "Manohar@123";
            string Role = Program.AuthenticateAdmin(username, password);
            ClassicAssert.AreEqual(null, Role);

        }

        [Test]
        public static void Test_ValidUser()
        {

            string username = "Dinesh";
            string password = "Dinesh123";
            var Role = Program.AuthenticateUser(username, password);
            ClassicAssert.AreEqual("user", Role.role);

        }

        [Test]
        public static void Test_InValidUser()
        {

            string username = "Dinesh";
            string password = "Dinesh@123";
            var Role = Program.AuthenticateUser(username, password);
            ClassicAssert.AreNotEqual("user", Role.role);

        }


    }
}
