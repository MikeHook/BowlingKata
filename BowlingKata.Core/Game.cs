using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingKata.Core
{
	public class Game
	{
		private int currentRoll = 0;
		private int[] rolls = new int[21];
		

		public void Roll(int pins)
		{
			rolls[currentRoll] = pins;			
			currentRoll++;
		}

		public int Score() 
		{
			int score = 0;
			int frameIndex = 0;
			for(int frame = 0; frame < 10; frame++)
			{
				if (IsSpare(frameIndex))
				{
					score += 10 + rolls[frameIndex + 2];
					frameIndex += 2;
				}
				else if (IsStrike(frameIndex))
				{
					score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
					frameIndex += 1;
				}
				else
				{
					score += rolls[frameIndex] + rolls[frameIndex + 1];
					frameIndex += 2;
				}			
			}

			return score;
		}

		public bool IsSpare(int frameIndex)
		{
			return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
		}

		public bool IsStrike(int frameIndex)
		{
			return rolls[frameIndex] == 10;
		}

	}
}
