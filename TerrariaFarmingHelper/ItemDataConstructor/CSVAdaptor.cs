namespace ItemDataConstructor;

public interface ICSVAdaptor {
	List<Item> GetItems();
}

public class CSVAdaptor : ICSVAdaptor {
	private ICSVPort _csvPort;

	public CSVAdaptor(ICSVPort csvPort) {
		_csvPort = csvPort;
	}

	public List<Item> GetItems() {
		return _csvPort.ParseData();
	}
}