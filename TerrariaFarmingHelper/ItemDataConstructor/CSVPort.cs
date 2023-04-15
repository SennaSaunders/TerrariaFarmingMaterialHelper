namespace ItemDataConstructor;

public interface ICSVPort {
	List<Item> ParseData();
}

public class CSVPort : ICSVPort {
	private const string DataPath = @"C:\Users\senna\Desktop\Projects\TerrariaFarmingMaterialHelper\TerrariaFarmingHelper\ItemDataConstructor\Data\";
	public List<Item> ParseData() {
		List<string> csvData = GetCSVs();
		List<DataBlock> dataBlocks = new List<DataBlock>();

		foreach (string csvString in csvData) {
			dataBlocks.Add(new DataBlock(csvString));
		}

		List<Item> items = new List<Item>();
		dataBlocks.ForEach(db => items.AddRange(GetItemsFromDataBlock(db)));
		return items;
	}

	private List<Item> GetItemsFromDataBlock(DataBlock dataBlock) {
		//TODO block created item
		List<DataBlock> craftables = BlockCraftables(dataBlock);
		//TODO block recipes per created item
		//TODO split alt recipes

		FixVersioning(dataBlock);//TODO check does this alter the original item - else return and overwrite

		return null;
	}

	private List<DataBlock> BlockCraftables(DataBlock dataBlock) {
		int col1Idx = 0;
		int col2Idx = 1;

		List<DataBlock> craftables = new List<DataBlock>();

		DataBlock newBlock = new DataBlock();
		while (dataBlock.data.Count > 0) {
			List<string> line = dataBlock.data.First();
			dataBlock.data.Remove(line);
			newBlock.data.Add(line);
			if (line[col2Idx] == "" && line[col1Idx] == "") {//if gap then either next recipe or next craftable
				List<string> nextLine = dataBlock.data.First();
				if (nextLine[col1Idx] != "") {
					craftables.Add(newBlock);
					newBlock = new DataBlock();
				}
			}
		}

		return null;
	}

	private void FixVersioning(DataBlock dataBlock) {
		//TODO fix offset from multi version recipes + remove non Desktop ones
		//1. If element contains version
		//2. bring cell below up
		//3. check which version it is - if PC then keep it

		//for (int y = 0; y < dataBlock.data.GetLength(1); y++) {
		//	if (dataBlock.data[0, y].Contains("version")) {
		//		dataBlock.data[0, y] = dataBlock.data[0, y + 1];
		//		dataBlock.data[0, y + 1] = "";
		//	}
		//}
	}


	public List<string> GetCSVs() {
		List<string> paths = GetCSVPaths();

		List<string> csvData = new List<string>();
		paths.ForEach(p => csvData.Add(File.ReadAllText(p)));
		return csvData;
	}

	private List<string> GetCSVPaths() {
		return Directory.EnumerateFiles(DataPath).ToList();
	}
}

public class DataBlock {
	public List<List<string>> data = new List<List<string>>();

	public DataBlock() { }
	public DataBlock(string csvString) {
		CSVTo2DArray(csvString);
	}
	private void CSVTo2DArray(string csv) {
		List<string> lines = csv.Split("\n").ToList();

		for (int i = 0; i < lines.Count; i++) {
			lines[i] = lines[i].Replace("\r", ""); // strip carriage returns
		}

		List<List<string>> splitLines = new List<List<string>>();

		foreach (var line in lines) {
			List<string> splitLine = line.Split(",").ToList();
			if (splitLine.Count > 1) {
				splitLines.Add(splitLine);
			}
		}

		data = splitLines;
	}
}