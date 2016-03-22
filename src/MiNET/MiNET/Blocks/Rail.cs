﻿using MiNET.Items;

namespace MiNET.Blocks
{
	public class Rail : Block
	{
		public Rail() : base(66)
		{
			IsTransparent = true;
			IsSolid = false;
			BlastResistance = 3.5f;
			Hardness = 0.7f;
		}

		public override Item GetDrops()
		{
			// No special metadata
			return new ItemBlock(this, 0);
		}
	}
}