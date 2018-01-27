using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using GildedRoseProblem.Core.Interfaces.InventoryManager;
using GildedRoseProblem.Core.Classes.Concrete.InventoryManager;

namespace GildedRoseProblem.Infrastructure.Classes.DIServices
{
	/// <summary>
	/// DI Services Encapsulation
	/// </summary>
    public static class DIServices
    {
		/// <summary>
		/// ServiceCollection singleton instance
		/// </summary>
		private static readonly IServiceCollection services = new ServiceCollection();
		private static readonly IServiceProvider provider;

		/// <summary>
		/// Service property
		/// </summary>
		public static IServiceProvider Provider { get { return provider; } }

		/// <summary>
		/// Register and Initialize the Microsoft DI container
		/// </summary>
		static DIServices()
		{
			RegisterComponents();
			provider = services.BuildServiceProvider();
		}

		/// <summary>
		/// Place to register our dependency components
		/// </summary>
		private static void RegisterComponents()
		{
			services.AddSingleton<IInventoryManager, InventoryManager>();
			services.Add(new ServiceDescriptor(typeof(IConfiguration), provider => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(),  ServiceLifetime.Singleton));
		}
    }
}
