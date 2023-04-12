namespace Terraria_Potion_Ingredients;

public class CSVParser {
	public List<Potion> ReadFile() {
		string path = "Data/" + "Terraria Data - Potions.csv";
		var lines = File.ReadAllLines(path);
		List<Potion> potions = new List<Potion>();

		foreach (string line in lines) {
			potions.Add(ParseLine(line));
		}

		return potions;
	}

	private Potion ParseLine(string line) {
		var splitLine = line.Split(",");
		Potion potion = new Potion() {
			Name = splitLine[0],
			PotionType = splitLine[1],
			Description = splitLine[2],
			DesiredAmount = int.Parse(splitLine[3]),
			Ingredients = ParseIngredients(splitLine[4..])
		};
		return potion;
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