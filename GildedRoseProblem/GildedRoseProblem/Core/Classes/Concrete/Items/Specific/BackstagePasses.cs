namespace GildedRoseProblem.Core.Classes.Concrete.Items.Specific
{
	/// <summary>
	/// An item of type 'Backstage passes', derives from Special
	/// </summary>
	public class BackstagePasses : Special
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sellindate">Sell In date to set</param>
		/// <param name="quality">Quality to set</param>
		public BackstagePasses(int sellindate, int quality) : base(sellindate, quality)
		{
		}

		/// <summary>
		/// Custom definition of ProcessUpdate
		/// </summary>
		public override void ProcessUpdate()
		{
			_sellIn = _sellIn - 1;

			if (_sellIn <= 10)
			{
				_itemDegradeRate = 2;
			}

			if (_sellIn <= 5)
			{
				_itemDegradeRate = 3;
			}

			_quality = _quality + _itemDegradeRate;

			if (_sellIn < 0)
			{
				_quality = 0;
			}

			EnforceBasicConstraints();
		}
	}
}
