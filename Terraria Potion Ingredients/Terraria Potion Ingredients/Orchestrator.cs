namespace Terraria_Potion_Ingredients;

public class Orchestrator {

	public void Go() {
		List<Potion> potions = new CSVParser().ReadFile();
		new ShoppingListCreator().WriteCSV(potions);
	}
}