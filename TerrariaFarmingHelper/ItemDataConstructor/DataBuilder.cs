namespace ItemDataConstructor {
	public class DataBuilder {
		private ICSVAdaptor _csvAdaptor;

		public DataBuilder(ICSVAdaptor csvAdaptor) {
			_csvAdaptor = csvAdaptor;
		}

		public ItemData GetItemData() {
			return new ItemData(_csvAdaptor.GetItems());
		}
	}

	public class ItemData {
		public ItemData(List<Item> items) {
			Items = items;
		}

		public List<Item> Items { get; set; }
	}

	public class Item {
		public string Name { get; set; }
		public List<Recipe> Recipes { get; set; }
	}

	public class Recipe {
		public List<Item> Ingredients { get; set; }
	}
}