using Microsoft.VisualStudio.TestTools.UnitTesting;
using GildedRoseProblem.Core.Enums;
using GildedRoseProblem.Core.Interfaces.InventoryManager;
using GildedRoseProblem.Core.Classes.Concrete.Items.Specific;
using GildedRoseProblem.Core.Classes.Concrete.Items;
using GildedRoseProblem.Core.Classes.Concrete.InventoryManager;

namespace GildedRoseUnitTests.CoreTests
{
	[TestClass]
	public class InventoryManagerTests
	{
		private IInventoryManager invManager = new InventoryManager();

		[TestInitialize]
		public void Initialize()
		{
		}

		[TestMethod]
		public void FullInventoryUpdateTest()
		{
			invManager.AddItem(new AgedBrie(1, 1) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new BackstagePasses(-1, 2) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			invManager.AddItem(new BackstagePasses(9, 2) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 3 });
			invManager.AddItem(new Legendary(2, 2) { Name = "Sulfuras", Type = ItemTypes.Legendary, UniqueID = 4 });
			invManager.AddItem(new Normal(-1, 55) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 5 });
			invManager.AddItem(new Normal(2, 2) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 6 });
			invManager.AddItem(new InvalidItem(2, 2) { Name = "INVALID ITEM", Type = ItemTypes.Unknown, UniqueID = 7 });
			invManager.AddItem(new Conjured(2, 2) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 8 });
			invManager.AddItem(new Conjured(-1, 5) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 9 });

			invManager.UpdateInventory();

			Assert.AreEqual("Aged Brie", invManager.Inventory[0].Name);
			Assert.AreEqual(0, invManager.Inventory[0].SellIn);
			Assert.AreEqual(2, invManager.Inventory[0].Quality);
			Assert.AreEqual("Backstage passes", invManager.Inventory[1].Name);
			Assert.AreEqual(-2, invManager.Inventory[1].SellIn);
			Assert.AreEqual(0, invManager.Inventory[1].Quality);
			Assert.AreEqual("Backstage passes", invManager.Inventory[2].Name);
			Assert.AreEqual(8, invManager.Inventory[2].SellIn);
			Assert.AreEqual(4, invManager.Inventory[2].Quality);
			Assert.AreEqual("Sulfuras", invManager.Inventory[3].Name);
			Assert.AreEqual(2, invManager.Inventory[3].SellIn);
			Assert.AreEqual(2, invManager.Inventory[3].Quality);
			Assert.AreEqual("Normal Item", invManager.Inventory[4].Name);
			Assert.AreEqual(-2, invManager.Inventory[4].SellIn);
			Assert.AreEqual(50, invManager.Inventory[4].Quality);
			Assert.AreEqual("Normal Item", invManager.Inventory[5].Name);
			Assert.AreEqual(1, invManager.Inventory[5].SellIn);
			Assert.AreEqual(1, invManager.Inventory[5].Quality);
			Assert.AreEqual("INVALID ITEM", invManager.Inventory[6].Name);
			Assert.AreEqual("Conjured", invManager.Inventory[7].Name);
			Assert.AreEqual(1, invManager.Inventory[7].SellIn);
			Assert.AreEqual(0, invManager.Inventory[7].Quality);
			Assert.AreEqual("Conjured", invManager.Inventory[8].Name);
			Assert.AreEqual(-2, invManager.Inventory[8].SellIn);
			Assert.AreEqual(1, invManager.Inventory[8].Quality);

		}

		[TestMethod]
		public void InvalidInventoryInputAllZeroTest()
		{
			invManager.AddItem(new AgedBrie(0, 0) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new BackstagePasses(0, 0) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			invManager.AddItem(new Normal(0, 0) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 3 });
			invManager.AddItem(new Conjured(0, 0) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 4 });
			invManager.AddItem(new Legendary(2, 2) { Name = "Sulfuras", Type = ItemTypes.Legendary, UniqueID = 5 });

			invManager.UpdateInventory();

			Assert.AreEqual(-1, invManager.Inventory[0].SellIn);
			Assert.AreEqual(2, invManager.Inventory[0].Quality);
			Assert.AreEqual(-1, invManager.Inventory[1].SellIn);
			Assert.AreEqual(0, invManager.Inventory[1].Quality);
			Assert.AreEqual(-1, invManager.Inventory[2].SellIn);
			Assert.AreEqual(0, invManager.Inventory[2].Quality);
			Assert.AreEqual(-1, invManager.Inventory[3].SellIn);
			Assert.AreEqual(0, invManager.Inventory[3].Quality);
			Assert.AreEqual(2, invManager.Inventory[4].SellIn);
			Assert.AreEqual(2, invManager.Inventory[4].Quality);
		}

		[TestMethod]
		public void InvalidInventoryInputAllNegativeTest()
		{
			invManager.AddItem(new AgedBrie(-1, -1) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new BackstagePasses(-1, -1) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			invManager.AddItem(new Normal(-1, -1) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 3 });
			invManager.AddItem(new Conjured(-1, -1) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 4 });
			invManager.AddItem(new Legendary(-1, -1) { Name = "Sulfuras", Type = ItemTypes.Legendary, UniqueID = 5 });

			invManager.UpdateInventory();

			Assert.AreEqual(-2, invManager.Inventory[0].SellIn);
			Assert.AreEqual(1, invManager.Inventory[0].Quality);
			Assert.AreEqual(-2, invManager.Inventory[1].SellIn);
			Assert.AreEqual(0, invManager.Inventory[1].Quality);
			Assert.AreEqual(-2, invManager.Inventory[2].SellIn);
			Assert.AreEqual(0, invManager.Inventory[2].Quality);
			Assert.AreEqual(-2, invManager.Inventory[3].SellIn);
			Assert.AreEqual(0, invManager.Inventory[3].Quality);
			Assert.AreEqual(-1, invManager.Inventory[4].SellIn);
			Assert.AreEqual(0, invManager.Inventory[4].Quality);
		}

		[TestMethod]
		public void InvalidInventoryInputQualityLimitExceedTest()
		{
			invManager.AddItem(new AgedBrie(1, 55) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new BackstagePasses(1, 55) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			invManager.AddItem(new Normal(1, 55) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 3 });
			invManager.AddItem(new Conjured(1, 55) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 4 });
			invManager.AddItem(new Legendary(1, 55) { Name = "Sulfuras", Type = ItemTypes.Legendary, UniqueID = 5 });

			invManager.UpdateInventory();

			Assert.AreEqual(0, invManager.Inventory[0].SellIn);
			Assert.AreEqual(50, invManager.Inventory[0].Quality);
			Assert.AreEqual(0, invManager.Inventory[1].SellIn);
			Assert.AreEqual(50, invManager.Inventory[1].Quality);
			Assert.AreEqual(0, invManager.Inventory[2].SellIn);
			Assert.AreEqual(50, invManager.Inventory[2].Quality);
			Assert.AreEqual(0, invManager.Inventory[3].SellIn);
			Assert.AreEqual(50, invManager.Inventory[3].Quality);
			Assert.AreEqual(1, invManager.Inventory[4].SellIn);
			Assert.AreEqual(50, invManager.Inventory[4].Quality);
		}

		[TestMethod]
		public void InvalidInventoryInputQualityExceedWithNegativeDate()
		{
			invManager.AddItem(new AgedBrie(0, 55) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new BackstagePasses(0, 55) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			invManager.AddItem(new Normal(0, 55) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 3 });
			invManager.AddItem(new Conjured(0, 55) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 4 });
			invManager.AddItem(new Legendary(0, 55) { Name = "Sulfuras", Type = ItemTypes.Legendary, UniqueID = 5 });

			invManager.UpdateInventory();

			Assert.AreEqual(-1, invManager.Inventory[0].SellIn);
			Assert.AreEqual(50, invManager.Inventory[0].Quality);
			Assert.AreEqual(-1, invManager.Inventory[1].SellIn);
			Assert.AreEqual(0, invManager.Inventory[1].Quality);
			Assert.AreEqual(-1, invManager.Inventory[2].SellIn);
			Assert.AreEqual(50, invManager.Inventory[2].Quality);
			Assert.AreEqual(-1, invManager.Inventory[3].SellIn);
			Assert.AreEqual(50, invManager.Inventory[3].Quality);
			Assert.AreEqual(0, invManager.Inventory[4].SellIn);
			Assert.AreEqual(50, invManager.Inventory[4].Quality);
		}

		[TestMethod]
		public void AgedBrieQualityIncreaseWithTimeTest()
		{
			invManager.AddItem(new AgedBrie(2, 5) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new AgedBrie(1, 5) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 2 });

			invManager.UpdateInventory(4);

			Assert.AreEqual(-2, invManager.Inventory[0].SellIn);
			Assert.AreEqual(11, invManager.Inventory[0].Quality);
			Assert.AreEqual(-3, invManager.Inventory[1].SellIn);
			Assert.AreEqual(12, invManager.Inventory[1].Quality);
		}

		[TestMethod]
		public void BackstagePassesIncreaseWithTimeTest()
		{
			invManager.AddItem(new BackstagePasses(15, 15) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 1 });
			invManager.AddItem(new BackstagePasses(10, 15) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			invManager.AddItem(new BackstagePasses(5, 15) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 3 });

			invManager.UpdateInventory(6);

			Assert.AreEqual(9, invManager.Inventory[0].SellIn);
			Assert.AreEqual(23, invManager.Inventory[0].Quality);
			Assert.AreEqual(4, invManager.Inventory[1].SellIn);
			Assert.AreEqual(29, invManager.Inventory[1].Quality);
			Assert.AreEqual(-1, invManager.Inventory[2].SellIn);
			Assert.AreEqual(0, invManager.Inventory[2].Quality);
		}

		[TestMethod]
		public void NormalItemDegradeTest()
		{
			invManager.AddItem(new Normal(3, 10) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 1 });
			invManager.AddItem(new Normal(0, 10) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 2 });

			invManager.UpdateInventory(2);

			Assert.AreEqual(1, invManager.Inventory[0].SellIn);
			Assert.AreEqual(8, invManager.Inventory[0].Quality);
			Assert.AreEqual(-2, invManager.Inventory[1].SellIn);
			Assert.AreEqual(6, invManager.Inventory[1].Quality);
		}

		[TestMethod]
		public void ConjuredItemDegradeTest()
		{
			invManager.AddItem(new Conjured(3, 10) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 1 });
			invManager.AddItem(new Conjured(0, 10) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 2 });

			invManager.UpdateInventory(2);

			Assert.AreEqual(1, invManager.Inventory[0].SellIn);
			Assert.AreEqual(6, invManager.Inventory[0].Quality);
			Assert.AreEqual(-2, invManager.Inventory[1].SellIn);
			Assert.AreEqual(2, invManager.Inventory[1].Quality);
		}

		[TestCleanup]
		public void Cleanup()
		{
			invManager.Inventory.Clear();
		}
    }
}
