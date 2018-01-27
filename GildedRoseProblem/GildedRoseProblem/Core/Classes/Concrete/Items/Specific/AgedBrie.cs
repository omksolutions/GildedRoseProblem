namespace GildedRoseProblem.Core.Classes.Concrete.Items.Specific
{
	/// <summary>
	/// An item of type 'Aged Brie', derives from Special
	/// </summary>
	public class AgedBrie : Special
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sellindate">Sell In date to set</param>
		/// <param name="quality">Quality to set</param>
		public AgedBrie(int sellindate, int quality) : base(sellindate, quality)
		{
		}

		/// <summary>
		/// Custom definition of ProcessUpdate
		/// </summary>
		public override void ProcessUpdate()
		{
			_sellIn = _sellIn - 1;

			//NOTE - May not be needed for Aged Brie
			CheckForIncreasedDegrade();
			
			_quality = _quality + _itemDegradeRate;

			EnforceBasicConstraints();
		}
	}
}
