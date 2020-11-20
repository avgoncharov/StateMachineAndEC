using System;

namespace StateMachineRsch
{
	public class EcProcessorFileRequired:EcProcessorBase
	{
		public EcProcessorFileRequired(Entity entity) : base(entity)
		{
		}

		protected override void CheckState()
		{
			NextTrigger = string.IsNullOrEmpty(Entity.FilePath) != true 
				? Trigger.OnProcess 
				: Trigger.OnComplete;
		}

		protected override void StartProcessing()
		{
			Console.WriteLine("FileOnlyRequired: in processing.");
			NextTrigger = Trigger.OnComplete;
		}
	}
}