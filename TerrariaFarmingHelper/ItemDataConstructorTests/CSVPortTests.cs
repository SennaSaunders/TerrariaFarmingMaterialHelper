using FluentAssertions;
using ItemDataConstructor;

namespace ItemDataConstructorTests {
	public class CSVPortTests {
		private CSVPort _csvPort;

		public CSVPortTests() {
			_csvPort = new CSVPort();
		}

		[Fact]
		public void ShouldRetrieveCSVFileNames() {
			//Act
			var csvPaths = _csvPort.GetCSVs();
			//Assert
			csvPaths.Should().NotBeNullOrEmpty();
		}

		[Fact]
		public void ShouldGetItemsWhenParsingData() {
			//Act
			var items = _csvPort.ParseData();
			//Assert
			items.Should().NotBeNullOrEmpty();
		}
	}
}