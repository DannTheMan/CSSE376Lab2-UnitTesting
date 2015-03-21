using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		private readonly DateTime dateThatFlightLeaves = DateTime.Now;

		[Test()]
		public void TestThatFlightInitializes()
		{
			var target = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(1), 1);
			Assert.IsNotNull(target);
		}

		[Test()]
		public void TestThatFlightHasCorrectBasePriceForOneDay()
		{
			var target = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(1), 1);
			Assert.AreEqual(220, target.getBasePrice());
		}

		[Test()]
		public void TestThatFlightHasCorrectBasePriceForTwoDays()
		{
			var target = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(2), 1);
			Assert.AreEqual(240, target.getBasePrice());
		}

		[Test()]
		public void TestThatFlightHasCorrectBasePriceForTenDays()
		{
			var target = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(10), 1);
			Assert.AreEqual(400, target.getBasePrice());
		}

		[Test()]
		public void TestThatFlightsAreEqual()
		{
			var targetA = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(10), 1);
			var targetB = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(10), 1);
			Assert.AreEqual(targetA, targetB);
		}

		[Test()]
		public void TestThatFlightsAreNotEqual()
		{
			var targetA = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(10), 1);
			var targetB = new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(4), 1);
			Assert.That(targetA, Is.Not.EqualTo(targetB));
		}

		[Test()]
	    [ExpectedException(typeof(InvalidOperationException))]
	    public void TestThatFlightThrowsOnBadDates()
	    {
	    	new Flight(dateThatFlightLeaves.AddDays(10), dateThatFlightLeaves, 10);
	    }

	    [Test()]
	    [ExpectedException(typeof(ArgumentOutOfRangeException))]
	    public void TestThatFlightThrowsOnBadMiles()
	    {
	    	new Flight(dateThatFlightLeaves, dateThatFlightLeaves.AddDays(1), -5);
	    }

	}
}
