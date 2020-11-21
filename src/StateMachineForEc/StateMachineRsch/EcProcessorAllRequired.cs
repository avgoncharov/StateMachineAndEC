using System;

namespace StateMachineRsch
{
	public class EcProcessorAllRequired:EcProcessorBase
	{
		protected override bool CheckState(Entity entity)
		{
			return string.IsNullOrEmpty(entity.FilePath) != true && entity.UserId.HasValue;
		}

		protected override void ExecuteProcessing(Entity entity)
		{
			Console.WriteLine($"AllRequired: in processing. | {{{{{entity}}}}}");
		}
	}
}