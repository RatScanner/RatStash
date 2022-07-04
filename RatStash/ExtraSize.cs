using System;

namespace RatStash;

public class ExtraSize
{
	public int Left = 0;
	public int Right= 0;
	public int Up = 0;
	public int Down = 0;
	public int ForcedLeft = 0;
	public int ForcedRight = 0;
	public int ForcedUp = 0;
	public int ForcedDown = 0;

	public static ExtraSize Merge(ExtraSize op1, ExtraSize op2)
	{
		return new ExtraSize
		{
			Left = Math.Max(op1.Left, op2.Left),
			Right = Math.Max(op1.Right, op2.Right),
			Up = Math.Max(op1.Up, op2.Up),
			Down = Math.Max(op1.Down, op2.Down),
			ForcedLeft = op1.ForcedLeft + op2.ForcedLeft,
			ForcedRight = op1.ForcedRight + op2.ForcedRight,
			ForcedUp = op1.ForcedUp + op2.ForcedUp,
			ForcedDown = op1.ForcedDown + op2.ForcedDown,
		};
	}

	public (int width, int height) Apply(int width, int height)
	{
		return (width + Left + Right + ForcedLeft + ForcedRight, height + Up + Down + ForcedUp + ForcedDown);
	}
}