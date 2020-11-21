namespace StateMachineRsch
{
	public class Controller
	{
		public Controller(IEcProcessor ecProcessor)
		{
			_ecProcessor = ecProcessor;
		}

		
		public Entity Entity { get; set; }

		
		public void HandleMessage(string message)
		{
			_ecProcessor.Process(Entity);
		}
		
		
		private readonly IEcProcessor _ecProcessor;
	}
}