using System;

namespace StateMachineRsch
{
	public static class Program
	{
		public static void Main()
		{
			Console.WriteLine("Start.");
			var arr = new []
			{
				new Entity { },
				new Entity {FilePath = "ABC"},
				new Entity {UserId = Guid.NewGuid()},
				new Entity {UserId = Guid.NewGuid(), FilePath = "CCC"}
			};

			DoForEcFileReq(arr);
			DoForEcAllReq(arr);
			
			Console.WriteLine();
			Console.WriteLine("All completed.");
			
		}

		private static void DoForEcAllReq(Entity[] arr)
		{
			Console.WriteLine("Start AllReq");
			foreach (var entity in arr)
			{
				Console.WriteLine("------------------------");
				Console.WriteLine($"Entity: {{{entity}}}");
				
				var sm = new EcProcessorAllRequired(entity);
				sm.Execute();
			}
			Console.WriteLine();
			Console.WriteLine("Complete AllReq");
		}

		private static void DoForEcFileReq(Entity[] arr)
		{
			Console.WriteLine("Start FileReq");
			foreach (var entity in arr)
			{
				Console.WriteLine("------------------------");
				Console.WriteLine($"Entity: {{{entity}}}");
				
				var sm = new EcProcessorFileRequired(entity);
				sm.Execute();
			}
			Console.WriteLine("Complete FileReq");
		}
	}
}