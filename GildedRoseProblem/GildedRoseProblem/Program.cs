using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GildedRoseProblem.Core.Enums;
using GildedRoseProblem.Infrastructure.Classes.DIServices;
using GildedRoseProblem.Core.Interfaces.InventoryManager;
using GildedRoseProblem.Core.Classes.Base;
using GildedRoseProblem.Core.Classes.Concrete.Items;
using GildedRoseProblem.Core.Classes.Concrete.Items.Specific;
using GildedRoseProblem.Core.Classes.Concrete.InventoryManager;

namespace GildedRoseProblem
{
    class Program
    {
        static void Main(string[] args)
        {
			IInventoryManager inventoryManager = DIServices.Provider.GetService<IInventoryManager>();

			//Test Input
			inventoryManager.AddItem(new AgedBrie(1,1) { Name = "Aged Brie", Type = ItemTypes.Special, UniqueID = 1 });
			inventoryManager.AddItem(new BackstagePasses(-1, 2) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 2 });
			inventoryManager.AddItem(new BackstagePasses(9, 2) { Name = "Backstage passes", Type = ItemTypes.Special, UniqueID = 3 });
			inventoryManager.AddItem(new Legendary(2, 2) { Name = "Sulfuras", Type = ItemTypes.Legendary, UniqueID = 4 });
			inventoryManager.AddItem(new Normal(-1, 55) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 5 });
			inventoryManager.AddItem(new Normal(2, 2) { Name = "Normal Item", Type = ItemTypes.Normal, UniqueID = 6 });
			inventoryManager.AddItem(new InvalidItem(2, 2) { Name = "INVALID ITEM", Type = ItemTypes.Unknown, UniqueID = 7 });
			inventoryManager.AddItem(new Conjured(2, 2) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 8 });
			inventoryManager.AddItem(new Conjured(-1, 5) { Name = "Conjured", Type = ItemTypes.Conjured, UniqueID = 9 });

			inventoryManager.UpdateInventory(1);
			inventoryManager.PrintInventory();
			
			Console.ReadLine();
        }
    }
}
