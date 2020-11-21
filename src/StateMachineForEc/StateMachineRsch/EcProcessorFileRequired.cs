using System;

namespace StateMachineRsch
{
	public class EcProcessorFileRequired:EcProcessorBase
	{
		protected override bool CheckState(Entity entity)
		{
			return string.IsNullOrEmpty(entity.FilePath) != true;
		}

		protected override void ExecuteProcessing(Entity entity)
		{
			Console.WriteLine($"FileOnlyRequired: in processing. | {{{entity}}}");
		}
	}
}