using System;
using System.Collections.Generic;
using GildedRoseProblem.Core.Classes.Base;
using GildedRoseProblem.Core.Classes.Concrete.Items;
using GildedRoseProblem.Core.Interfaces.InventoryManager;

namespace GildedRoseProblem.Core.Classes.Concrete.InventoryManager
{
	/// <summary>
	/// Inventory manager module, implements IInventoryManager
	/// </summary>
    public class InventoryManager : IInventoryManager
    {
		/// <summary>
		/// Item list field
		/// </summary>
		private List<Item> items = null;

		/// <summary>
		/// public Item Inventory Property
		/// </summary>
		public List<Item> Inventory { get { return items; } }

		/// <summary>
		/// Constructor
		/// </summary>
		public InventoryManager()
		{
			if (items == null)
			{
				items = new List<Item>();
			}
		}

		/// <summary>
		/// Add Item
		/// </summary>
		/// <param name="theItem">Item to add</param>
		public void AddItem(Item theItem)
		{
			if (theItem != null && items != null)
			{
				items.Add(theItem);
			}
		}

		/// <summary>
		/// Remove item - INCOMPLETE
		/// </summary>
		/// <param name="itemID">Item to remove via ID</param>
		public void RemoveItem(int itemID)
		{
		}

		/// <summary>
		/// Update Item - INCOMPLETE
		/// </summary>
		/// <param name="itemID">Item to update via ID</param>
		public void UpdateItem(int itemID)
		{
		}

		/// <summary>
		/// Update the inventory
		/// </summary>
		/// <param name="numOfDays">Number of days to update, default is 1</param>
		public void UpdateInventory(int numOfDays = 1)
		{
			if (items != null && items.Count > 0)
			{
				for (int i = 0; i < numOfDays; i++)
				{
					foreach (Item itm in items)
					{
						itm.ProcessUpdate();
					}
				}
			}
		}

		/// <summary>
		/// Utility - print out the inventory on console
		/// </summary>
		public void PrintInventory()
		{
			foreach (Item itm in items)
			{
				if (itm is InvalidItem)
				{
					Console.WriteLine("NO SUCH ITEM");
				}
				else
				{
					Console.WriteLine("{0} {1} {2}", itm.Name, itm.SellIn, itm.Quality);
				}
			}
		}
	}
}
