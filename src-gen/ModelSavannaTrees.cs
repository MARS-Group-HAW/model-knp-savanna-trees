public static class Program {
	public static void Main(string[] args) {
		if (args != null && System.Linq.Enumerable.Any(args, s => s.Equals("-l")))
		{
			Mars.Common.Logging.LoggerFactory.SetLogLevel(Mars.Common.Logging.Enums.LogLevel.Info);
			Mars.Common.Logging.LoggerFactory.ActivateConsoleLogging();
		}
		var description = new Mars.Core.ModelContainer.Entities.ModelDescription();
		description.AddLayer<SavannaTrees.SavannaLayer>();
		description.AddLayer<SavannaTrees.Precipitation>();
		description.AddLayer<SavannaTrees.Temperature>();
		description.AddLayer<SavannaTrees.TreeRaster>();
		description.AddAgent<SavannaTrees.Rafiki, SavannaTrees.SavannaLayer>();
		description.AddAgent<SavannaTrees.Tree, SavannaTrees.SavannaLayer>();
		var task = Mars.Core.SimulationStarter.SimulationStarter.Start(description, args);
		var loopResults = task.Run();
		System.Console.WriteLine($"Simulation execution finished after {loopResults.Iterations} steps");
	}
}
