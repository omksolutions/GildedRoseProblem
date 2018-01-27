using System.Collections.Generic;
using GildedRoseProblem.Core.Classes.Base;

namespace GildedRoseProblem.Core.Interfaces.InventoryManager
{
	/// <summary>
	/// Interface for Inventory Manager
	/// </summary>
    public interface IInventoryManager
    {
		/// <summary>
		/// Inventory list property
		/// </summary>
		List<Item> Inventory { get; }

		/// <summary>
		/// Add Item
		/// </summary>
		/// <param name="theItem">Item to add</param>
		void AddItem(Item theItem);

		/// <summary>
		/// Remove item - INCOMPLETE
		/// </summary>
		/// <param name="itemID">Item to remove via ID</param>
		void RemoveItem(int itemID);

		/// <summary>
		/// Update Item - INCOMPLETE
		/// </summary>
		/// <param name="itemID">Item to update via ID</param>
		void UpdateItem(int itemID);

		/// <summary>
		/// Update the inventory
		/// </summary>
		/// <param name="numOfDays">Number of days to update, default is 1</param>
		void UpdateInventory(int numOfDays = 1);

		/// <summary>
		/// Print out the inventory on console
		/// </summary>
		void PrintInventory();

	}
}
