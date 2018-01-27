using GildedRoseProblem.Core.Enums;
using GildedRoseProblem.Core.Interfaces.Base;

namespace GildedRoseProblem.Core.Classes.Base
{
	/// <summary>
	/// Item base class, also derives from IBaseItem for basic/common functionality
	/// </summary>
	public abstract class Item : IBaseItem
	{
		/// <summary>
		/// Original item degrade rate field
		/// </summary>
		protected int _itemDegradeRateInitial = 0;

		/// <summary>
		/// Current item degrade rate field
		/// </summary>
		protected int _itemDegradeRate = 0;

		/// <summary>
		/// Sell In number of days field
		/// </summary>
		protected int _sellIn = 0;

		/// <summary>
		/// Quality value field
		/// </summary>
		protected int _quality = 0;

		/// <summary>
		/// Unique item identifier - For future considerations
		/// </summary>
		public int UniqueID { get; set; }

		/// <summary>
		/// Item name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// SellIn public propery
		/// </summary>
		public int SellIn { get { return _sellIn; } }

		/// <summary>
		/// Quality public property
		/// </summary>
		public int Quality { get { return _quality; } }

		/// <summary>
		/// Item Type enum - future considerations
		/// </summary>
		public ItemTypes Type { get; set; }

		/// <summary>
		/// Main update method by which an item performs its update logic, to be implemented individually
		/// </summary>
		public abstract void ProcessUpdate();

		/// <summary>
		/// Check for any global constraints - default implementation
		/// </summary>
		public virtual void EnforceBasicConstraints()
		{
			if (_quality < 0)
			{
				_quality = 0;
			}

			else if (_quality > 50)
			{
				_quality = 50;
			}
		}

		/// <summary>
		/// Check if increased rate of decay needs to be set for an item - default implenetation
		/// </summary>
		public virtual void CheckForIncreasedDegrade()
		{
			if (_sellIn < 0)
			{
				_itemDegradeRate = 2 * _itemDegradeRateInitial;
			}
		}
	}
}
