using System;
using NUnit.Framework;
using Rafaela.DDD.Test.Implementations;

namespace Rafaela.DDD.Test
{
    [TestFixture]
    public class ValueObjectShould
    {
        private Address _address;
        [SetUp]
        public void Setup() => _address = new Address("Baker Street","London","29BD12");
        
        [Test]
        public void Return_False_When_Comparing_To_Null()
        {
            var actual1 = _address.Equals(null);
            var actual2 = _address == null;

            
            Assert.IsFalse(actual1);
            Assert.IsFalse(actual2);
        }
        
        [Test]
        public void Return_True_When_Comparing_To_Self_Reference()
        {
            ValueObject address2 = _address;

            var actual1 = _address.Equals(address2);
            var actual2 = _address == address2;

            
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual1);
        }

        [Test]
        public void Return_False_When_Comparing_Other_Reference_Type()
        {
            var obj = new Object();

            var actual1 = _address.Equals(obj);
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
            bool actual2 = _address == obj;
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast

            Assert.IsFalse(actual1);
            Assert.IsFalse(actual2);
        }

        [Test]
        public void Return_False_When_Comparing_And_One_Object_Is_Null()
        {
            Address nullAddress = null;

            var actual = nullAddress == _address;
            
            Assert.IsFalse(actual);
        }
        
        [Test]
        public void Return_True_When_Both_Instance_Is_Uninitialized()
        {
            Address nullAddress1 = null;
            Address nullAddress2 = null;

            var actual = nullAddress1 == nullAddress2;
            
            Assert.IsTrue(actual);
        }
        
        [Test]
        public void Return_True_When_Both_Instances_Have_Same_Values()
        {
            Address address1 = _address;
            Address address2 = new Address("Baker Street","London","29BD12");

            var actual1 = address1 == address2;
            var actual2 = address1.Equals(address2);
            
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
        }

        [Test]
        public void Case_Intensive_Compare_Strings()
        {
            Address address1 = _address;
            Address address2 = new Address("Baker Street","LondoN","29BD12");

            var actual1 = address1 == address2;
            var actual2 = address1.Equals(address2);
            
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);
        }
    }
}