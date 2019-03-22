using System;
using NUnit.Framework;
using Rafaela.DDD.Test.Implementations;

namespace Rafaela.DDD.Test
{
    [TestFixture]
    public class EntityShould
    {
        [Test]
        public void Throw_ArgumentException_If_We_Pass_Default_Value_To_Constructor()
        {            
            Assert.Throws<ArgumentException>(() =>
            {
                var case2 = new Product(default(Guid));                
            });            
        }

        [Test]
        public void Assign_Passed_Id_To_Public_Id_Property()
        {
            var guid = Guid.NewGuid();
            var product = new Product(guid);
            
            Assert.AreEqual(guid, product.Id);
        }

        [Test]
        public void Return_False_When_Comparing_To_Other_Reference_Type()
        {
            var guid1 = Guid.NewGuid();
            var product = new Product(guid1);
            var obj = new object();

            var actual1 = product.Equals(obj);
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
            bool actual2 = product == obj;
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast

            Assert.IsFalse(actual1);
            Assert.IsFalse(actual2);

        }


        [Test]
        public void Return_True_When_Comparing_To_Other_Entity_Which_Has_Same_Id()
        {
            var guid = Guid.NewGuid();
            var product1 = new Product(guid);
            var product2 = new Product(guid);

            var actual1 = product1.Equals(product2);
            var actual2 = product1 == product2;
            
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);            
        }
        
        [Test]
        public void Return_False_When_Comparing_To_Other_Entity_Which_Has_Different_Id()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var product1 = new Product(guid1);
            var product2 = new Product(guid2);

            var actual1 = product1.Equals(product2);
            var actual2 = product1 == product2;
            
            Assert.False(actual1);
            Assert.False(actual2);            
        }
        
        [Test]
        public void Return_False_When_Comparing_To_Other_Entity_Which_Is_Null()
        {
            var guid = Guid.NewGuid();

            var product1 = new Product(guid);
            Entity<Guid> product2 = null;

            var actual1 = product1.Equals(product2);
            var actual2 = product1.Equals((object) product2);
            var actual3 = product1 == product2;

            
            Assert.IsFalse(actual1);
            Assert.IsFalse(actual2); 
            Assert.IsFalse(actual3);
        }

        [Test]
        public void Return_True_When_Comparing_To_Self_Reference()
        {
            var p1 = new Product(Guid.NewGuid());
            var p2 = p1;

            var actual1 = p1.Equals(p2);
            var actual2 = p1 == p2;
            
            Assert.IsTrue(actual1);
            Assert.IsTrue(actual2);

        }
        
        [Test]
        public void Return_True_When_Comparing_Uninitialized_objects()
        {
            Entity<Guid> p1 = null;
            Entity<Guid> p2 = null;

            var actual1 = p1 == p2;

            Assert.IsTrue(actual1);           
        }
        
    }
}