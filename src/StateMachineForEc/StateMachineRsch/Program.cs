using System;

namespace StateMachineRsch
{
	
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Entity[] arr = new[]
			{
				new Entity { },
				new Entity {FilePath = "ABC"},
				new Entity {UserId = Guid.NewGuid()},
				new Entity {UserId = Guid.NewGuid(), FilePath = "CCC"}
			};

			DoForEcFileReq(arr);
			DoForEcAllReq(arr);



			//Console.WriteLine(pr);
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