using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GildedRoseProblem.Core.Classes.Base;
using GildedRoseProblem.Infrastructure.Classes.DIServices;

namespace GildedRoseProblem.Core.Classes.Concrete.Items
{
	/// <summary>
	/// An item of type 'Normal', derives from base Item
	/// </summary>
	public class Normal : Item
    {
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="sellindate">Sell In date to set</param>
		/// <param name="quality">Quality to set</param>
		public Normal(int sellindate, int quality)
		{
			_sellIn = sellindate;
			_quality = quality;
			_itemDegradeRateInitial = Convert.ToInt32(DIServices.Provider.GetService<IConfiguration>()["NormalDegrade"]);
			_itemDegradeRate = _itemDegradeRateInitial;
		}

		/// <summary>
		/// Custom definition of ProcessUpdate
		/// </summary>
		public override void ProcessUpdate()
		{
			_sellIn = _sellIn - 1;

			CheckForIncreasedDegrade();
			
			_quality = _quality - _itemDegradeRate;

			EnforceBasicConstraints();
		}
    }
}
