namespace TerrariaFarmingHelper;

public class CSVParser {
	public List<Item> ReadFile() {
		string path = "Data/" + "ItemFarmingData.csv";
		var lines = File.ReadAllLines(path).ToList();
		lines.RemoveAt(0);//removes heading line
		List<Item> items = new List<Item>();

		foreach (string line in lines) {
			items.Add(ParseLine(line));
		}

		return items;
	}

	private Item ParseLine(string line) {
		var splitLine = line.Split(",");
		Item item = new Item() {
			Name = splitLine[0],
			Description = splitLine[1],
			DesiredAmount = int.Parse(splitLine[2]),
			Ingredients = ParseIngredients(splitLine[3..])
		};
		return item;
	}

	private List<Ingredient> ParseIngredients(string[] ingredientArr) {
		List<Ingredient> ingredients = new List<Ingredient>();
		for (int i = 0; i < ingredientArr.Length; i += 2) {
			string name = ingredientArr[i];
			if (name != "") {
				int count = int.Parse(ingredientArr[i + 1]);
				ingredients.Add(new Ingredient(name, count));
			}
		}
		return ingredients;
	}
}