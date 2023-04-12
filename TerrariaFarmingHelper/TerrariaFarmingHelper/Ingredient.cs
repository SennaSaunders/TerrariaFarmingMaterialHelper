namespace TerrariaFarmingHelper;

public class Ingredient {
	public string Name { get; set; }
	public int Count { get; set; }

	public Ingredient(string name, int count) {
		Name = name;
		Count = count;
	}
}