using GildedRoseProblem.Core.Classes.Base;

namespace GildedRoseProblem.Core.Classes.Concrete.Items
{
	/// <summary>
	/// An item of type 'InvalidItem', derives from base Item
	/// </summary>
	public class InvalidItem : Item
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sellindate">Sell In date to set</param>
		/// <param name="quality">Quality to set</param>
		public InvalidItem(int sellindate, int quality)
		{
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
