﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingKata.Core
{
	public class Game
	{
		private int[] rolls = new int[21];
		private int currentRoll = 0;

		public void Roll(int pins)
		{		
			rolls[currentRoll++] = pins;
		}

		public int Score() 
		{
			int score = 0;
			int frameIndex = 0;
			for (int frame = 0; frame < 10; frame++)
			{
				if (isStrike(frameIndex)) 
				{
					score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
					frameIndex ++;
				}				
				else if (isSpare(frameIndex)) 
				{
					score += 10 + rolls[frameIndex + 2];
					frameIndex += 2;
				}
				else
				{
					score += rolls[frameIndex] + rolls[frameIndex + 1];
					frameIndex += 2;
				}		

			}

			return score;
		}

		private bool isStrike(int frameIndex)
		{
			return rolls[frameIndex] == 10;
		}

		private bool isSpare(int frameIndex)
		{
			return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
		}

	}
}
