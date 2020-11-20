using System;

namespace StateMachineRsch
{
	public class EcProcessorAllRequired:EcProcessorBase
	{
		public EcProcessorAllRequired(Entity entity) : base(entity)
		{
		}

		protected override void CheckState()
		{
			NextTrigger = (string.IsNullOrEmpty(Entity.FilePath) != true && Entity.UserId.HasValue) 
				? Trigger.OnProcess 
				: Trigger.OnComplete;
		}

		protected override void ExecuteProcessing()
		{
			Console.WriteLine("AllRequired: in processing.");
			NextTrigger = Trigger.OnComplete;
		}
	}
}