using System;

namespace StateMachineRsch
{
	public class Entity
	{
		public Guid Id { get; set; }
		public string FilePath { get; set; }
		public Guid? UserId { get; set; }

		public override string ToString()
		{
			return $"FP: '{FilePath}'; UId: {UserId}";
		}
	}
}