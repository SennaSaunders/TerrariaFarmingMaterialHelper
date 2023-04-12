namespace Terraria_Potion_Ingredients;

public class Orchestrator {
	
	public void Go() {
		List<Potion> potions = new CSVParser().ReadFile();
		new ShoppingListCreator().WriteCSV(potions);
	}
}

public class ShoppingListCreator {
	public void WriteCSV(List<Potion> potions) {
		Dictionary<string, int> ingredients = new Dictionary<string, int>();
		foreach (Potion potion in potions) {
			foreach (Ingredient potionIngredient in potion.Ingredients) {
				int newIngredientCount = potion.DesiredAmount * potionIngredient.Count;
				;
				if (ingredients.ContainsKey(potionIngredient.Name)) {
					ingredients[potionIngredient.Name] += newIngredientCount;
				} else {
					ingredients.Add(potionIngredient.Name, newIngredientCount);
				}
			}
		}

		List<string> lines = new List<string>(){"Ingredient,Count"};
		foreach (KeyValuePair<string, int> ingredient in ingredients) {
			lines.Add($"{ingredient.Key},{ingredient.Value}");
		}

		string path = "Data/ShoppingList.csv";
		File.WriteAllLines(path, lines);
	}
}

public class Potion {
	public string Name { get; set; }
	public string PotionType { get; set; }
	public string Description { get; set; }
	public int DesiredAmount { get; set; }
	public List<Ingredient> Ingredients { get; set; }
}

public class Ingredient {
	public string Name { get; set; }
	public int Count { get; set; }

	public Ingredient(string name, int count) {
		Name = name;
		Count = count;
	}
}