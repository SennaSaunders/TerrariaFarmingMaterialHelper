using System.Reflection;

namespace Terraria_Potion_Ingredients;

public class ShoppingListCreator {
	private const string RepoName = "TerrariaPotionIngredientHelper";
	private const string ProjName = "Terraria Potion Ingredients";
	private const string Separator = "\\";
	private const string FileName = "ShoppingList.csv";
	private const string DataFolderName = "Data";

	public void WriteCSV(List<Potion> potions) {
		Dictionary<string, int> ingredients = GetIngredientCounts(potions);
		List<string> lines = BuildCSVLines(ingredients);
		string path = GetSavePath();

		File.WriteAllLines(path, lines);
	}

	private static string GetSavePath() {
		//get relative path
		string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
		var splitName = execPath.Split(Separator).ToList();
		var repoNameIdx = splitName.FindIndex(sn => sn == RepoName);

		//build path
		var path = "";
		for (int i = 0; i <= repoNameIdx; i++) {
			path += splitName[i] + Separator;
		}

		path += ProjName + Separator + ProjName + Separator + DataFolderName + Separator + FileName;
		return path;
	}


	private static List<string> BuildCSVLines(Dictionary<string, int> ingredients) {
		List<string> lines = new List<string>() { "Ingredient,Count" };
		foreach (KeyValuePair<string, int> ingredient in ingredients) {
			lines.Add($"{ingredient.Key},{ingredient.Value}");
		}

		return lines;
	}

	private static Dictionary<string, int> GetIngredientCounts(List<Potion> potions) {
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

		return ingredients;
	}
}