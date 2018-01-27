using GildedRoseProblem.Core.Classes.Base;

namespace GildedRoseProblem.Core.Classes.Concrete.Items
{
	/// <summary>
	/// An item of type 'Legendary', derives from base Item
	/// </summary>
	public class Legendary : Item
    {
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sellindate">Sell In date to set</param>
		/// <param name="quality">Quality to set</param>
		public Legendary(int sellindate, int quality)
		{
			_sellIn = sellindate;
			_quality = quality;
		}

		/// <summary>
		/// Custom definition of ProcessUpdate
		/// </summary>
		public override void ProcessUpdate()
		{
			EnforceBasicConstraints();
		}
	}
}
