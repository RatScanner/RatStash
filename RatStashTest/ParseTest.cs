using RatStash;
using Xunit;

namespace RatStashTest
{
	public class ParseTest
	{
		[Fact]
		public void ParseItemDatabase()
		{
			Database.Load("..\\..\\..\\TestData\\items.json");
			var item = Database.FindById("5c17664f2e2216398b5a7e3c");
			Assert.NotNull(item);
			var type = item.GetType();
			Assert.Equal(typeof(Handguard), item.GetType());
		}
	}
}
