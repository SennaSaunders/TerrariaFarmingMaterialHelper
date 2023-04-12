namespace Terraria_Potion_Ingredients;

public class Potion {
	public string Name { get; set; }
	public string PotionType { get; set; }
	public string Description { get; set; }
	public int DesiredAmount { get; set; }
	public List<Ingredient> Ingredients { get; set; }
}