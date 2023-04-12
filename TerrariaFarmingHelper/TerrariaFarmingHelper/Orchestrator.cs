namespace TerrariaFarmingHelper;

public class Orchestrator {

	public void Go() {
		List<Item> items = new CSVParser().ReadFile();
		new ShoppingListCreator().WriteCSV(items);
	}
}