using RatStash;
using Xunit;

namespace RatStashTest;

public class ExtensionsTest
{
	[Fact]
	public void SplitString()
	{
		var (left, right) = "1,2,3".Split(",", false);
		Assert.Equal("1", left);
		Assert.Equal("2,3", right);
	}

	[Fact]
	public void SplitStringReverse()
	{
		var (left, right) = "1,2,3".Split(",", true);
		Assert.Equal("1,2", left);
		Assert.Equal("3", right);
	}

	[Fact]
	public void ReverseString()
	{
		Assert.Equal("321-cbA", "Abc-123".Reverse());
	}
}