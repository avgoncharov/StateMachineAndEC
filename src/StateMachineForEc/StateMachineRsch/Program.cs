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
			var controller = new Controller(new EcProcessorAllRequired());
			Console.WriteLine("\n\tStart AllReq");
			foreach (var entity in arr)
			{
				Console.WriteLine("------------------------");
				Console.WriteLine($"Entity: {{{entity}}}");
				
				controller.Entity = entity;
				
				controller.HandleMessage(string.Empty);
			}
			Console.WriteLine();
			Console.WriteLine("Complete AllReq");
		}

		private static void DoForEcFileReq(Entity[] arr)
		{
			var controller = new Controller(new EcProcessorFileRequired());
			Console.WriteLine("\n\tStart FileReq");
			foreach (var entity in arr)
			{
				Console.WriteLine("------------------------");
				Console.WriteLine($"Entity: {{{entity}}}");
				controller.Entity = entity;
				
				controller.HandleMessage(string.Empty);
			}
			Console.WriteLine("Complete FileReq");
		}
	}
}