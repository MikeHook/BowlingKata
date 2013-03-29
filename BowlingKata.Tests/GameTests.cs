using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BowlingKata.Core;
using NUnit.Framework;

namespace BowlingKata.Tests
{
	[TestFixture]
	public class GameTests
	{
		private Game game;

		private void rollMany(int n, int pins)
		{
			for (int i = 0; i < n; i++)
			{
				game.Roll(pins);
			}
		}

		private void rollSpare()
		{
			game.Roll(5);
			game.Roll(5); //spare
		}

		private void rollStrike()
		{
			game.Roll(10); //strike
		}

		[SetUp]
		protected void SetUp()
		{
			game = new Game();
		}

		[Test]
		public void TestGutterGame()
		{
			rollMany(20, 0);
			Assert.That(game.Score(), Is.EqualTo(0));
		}

		[Test]
		public void TestAllOnes()
		{
			rollMany(20, 1);
			Assert.That(game.Score(), Is.EqualTo(20));
		}

		[Test]
		public void TestOneSpare()
		{
			rollSpare();
			game.Roll(3);
			rollMany(17, 0);

			Assert.That(game.Score(), Is.EqualTo(16));
		}

		[Test]
		public void TestOneStrike()
		{
			rollStrike();
			game.Roll(3);
			game.Roll(4);
			rollMany(16, 0);

			Assert.That(game.Score(), Is.EqualTo(24));
		}

		[Test]
		public void TestPerfectGame()
		{			
			rollMany(12, 10);
			Assert.That(game.Score(), Is.EqualTo(300));
		}


		
	}
}
