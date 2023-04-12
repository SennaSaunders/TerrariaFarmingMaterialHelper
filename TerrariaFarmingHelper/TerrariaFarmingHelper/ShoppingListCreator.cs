using System.Reflection;

namespace TerrariaFarmingHelper;

public class ShoppingListCreator {
	private const string RepoName = "TerrariaFarmingIngredientHelper";
	private const string ProjName = "TerrariaFarmingHelper";
	private const string Separator = "\\";
	private const string FileName = "ShoppingList.csv";
	private const string DataFolderName = "Data";

	public void WriteCSV(List<Item> items) {
		Dictionary<string, int> ingredients = GetIngredientCounts(items);
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

	private static Dictionary<string, int> GetIngredientCounts(List<Item> items) {
		Dictionary<string, int> ingredients = new Dictionary<string, int>();
		foreach (Item item in items) {
			foreach (Ingredient itemIngredient in item.Ingredients) {
				int newIngredientCount = item.DesiredAmount * itemIngredient.Count;
				;
				if (ingredients.ContainsKey(itemIngredient.Name)) {
					ingredients[itemIngredient.Name] += newIngredientCount;
				} else {
					ingredients.Add(itemIngredient.Name, newIngredientCount);
				}
			}
		}

		return ingredients;
	}
}