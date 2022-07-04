using System.Collections.Generic;

namespace RatStash;

public interface IContainer
{
	public string Id { get; set; }

	public string Name { get; set; }

	public IEnumerable<Item> Items { get; }

	public List<ItemFilter> Filters { get; set; }

	public Item ContainedItem { get; set; }

	public Item ParentItem { get; set; }
}