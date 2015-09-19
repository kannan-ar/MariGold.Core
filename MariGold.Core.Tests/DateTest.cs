namespace MariGold.Core.Tests
{
    using System;
    using NUnit.Framework;
    using MariGold;

    [TestFixture]
    public class DateTest
    {
        [Test]
        public void DateAndDateTimeEqualTest()
        {
            Date d1 = "10/10/2015";
            DateTime d2 = new DateTime(2015, 10, 10);

            Assert.AreEqual(d1, d2);
        }

        [Test]
        public void DateFormatTest()
        {
            Date d1 = new Date();
            DateTime d2 = new DateTime(2015, 1, 28);

            d1.SetDate("28/01/2015", "dd/MM/yyyy");

            Assert.AreEqual(d1, d2);
        }

        [Test]
        public void SetInvalidDate()
        {
            Date d = "10/10/2015";

            Assert.IsTrue(d.HasValue);

            d = "100/52/5855";

            Assert.IsTrue(!d.HasValue);
        }

        [Test]
        public void DateAssignmentTest()
        {
            DateTime d1 = new DateTime(2015, 1, 15);
            DateTime d2 = new DateTime(2015, 1, 15);

            Date d = d1;

            DateTime d3 = d;

            Assert.AreEqual(d2, d3);
        }

        [Test]
        public void DateEqualTest()
        {
            Date d1 = "10/10/2015";
            Date d2 = "10/10/2015";

            Assert.AreEqual(d1, d2);
        }

        [Test]
        public void DateNotEqualTest()
        {
            Date d1 = "12/10/2015";
            Date d2 = "10/12/2015";

            Assert.AreNotEqual(d1, d2);
        }

        [Test]
        public void DateGreaterThanTest()
        {
            Date d1 = "10/10/2015";
            Date d2 = "11/10/2015";

            Assert.IsTrue(d2 > d1);
        }

        [Test]
        public void DateGreaterThanOrEqualTest()
        {
            Date d1 = "10/10/2015";
            Date d2 = "11/10/2015";

            Assert.IsTrue(d2 >= d1);
        }

        [Test]
        public void DateLessThanTest()
        {
            Date d1 = "10/10/2015";
            Date d2 = "11/10/2015";

            Assert.IsTrue(d1 < d2);
        }

        [Test]
        public void DateLessThanOrEqualTest()
        {
            Date d1 = "10/10/2015";
            Date d2 = "11/10/2015";

            Assert.IsTrue(d1 <= d2);
        }
        
        [Test]
        public void ValueNullExceptionTest()
        {
        	Date d1="";
        	
        	Assert.Throws<NullReferenceException>(()=>{d1.ToDateTime();},"value");
        }
    }
}
