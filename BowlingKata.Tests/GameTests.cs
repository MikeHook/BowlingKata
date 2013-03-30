using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BowlingKata.Core;

namespace BowlingKata.Tests
{
	[TestFixture]
	public class GameTests
	{
		private Game _game;

		private void Rolls(int rolls, int pinsKnockedDown)
		{
			for (int roll = 0; roll < rolls; roll++)
			{
				_game.Roll(pinsKnockedDown);
			}
		}

		[SetUp]
		public void SetUp()
		{
			_game = new Game();
		}

		[Test]
		public void TestGutterGame()
		{
			Rolls(20, 0);
			Assert.That(_game.Score(), Is.EqualTo(0));
		}

		[Test]
		public void TestAllOnes()
		{
			Rolls(20, 1);
			Assert.That(_game.Score(), Is.EqualTo(20));
		}

		[Test]
		public void TestOneSpare()
		{
			_game.Roll(5);
			_game.Roll(5);
			_game.Roll(3);
			Rolls(17, 0);
			Assert.That(_game.Score(), Is.EqualTo(16));
		}

		[Test]
		public void TestOneStrike()
		{
			_game.Roll(10);
			_game.Roll(3);
			_game.Roll(4);
			Rolls(16, 0);
			Assert.That(_game.Score(), Is.EqualTo(24));
		}

		[Test]
		public void TestPerfectGame()
		{
			Rolls(12, 10);
			Assert.That(_game.Score(), Is.EqualTo(300));
		}
	}
}
