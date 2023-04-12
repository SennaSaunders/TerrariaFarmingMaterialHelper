namespace TerrariaFarmingHelper;

public class Item {
	public string Name { get; set; }
	public string Description { get; set; }
	public int DesiredAmount { get; set; }
	public List<Ingredient> Ingredients { get; set; }
}