
namespace GildedRoseProblem.Core.Interfaces.Base
{
	/// <summary>
	/// Interface for Base Item
	/// </summary>
	public interface IBaseItem
	{
		/// <summary>
		/// SellIn as Property
		/// </summary>
		int SellIn { get; }

		/// <summary>
		/// Quality as Property
		/// </summary>
		int Quality { get; }

		/// <summary>
		/// Process item update logic
		/// </summary>
		void ProcessUpdate();

		/// <summary>
		/// Enforce some basic constraints for all classes
		/// </summary>
		void EnforceBasicConstraints();

		/// <summary>
		/// Check if we need to increase rate of degrade, past sell by date
		/// </summary>
		void CheckForIncreasedDegrade();

	}
}
