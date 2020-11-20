using System;
using Stateless;
using Stateless.Graph;

namespace StateMachineRsch
{
	public abstract class EcProcessorBase
	{
		protected EcProcessorBase(Entity entity)
		{
			Entity = entity;
			NextTrigger = Trigger.OnCheckState;

			_stM.Configure(State.Init)
				.Permit(Trigger.OnCheckState, State.ChekState);

			_stM.Configure(State.ChekState)
				.OnEntry(() => CheckState())
				.Permit(Trigger.OnProcess, State.InProcess)
				.Permit(Trigger.OnComplete, State.Complete);

			_stM.Configure(State.InProcess)
				.OnEntry(() => ExecuteProcessing())
				.Permit(Trigger.OnComplete, State.Complete);

			_stM.Configure(State.Complete)
				.OnEntry(() => OnComplete());
		}

		
		public void Execute()
		{
			while (_stM.State != State.Complete)
			{
				_stM.Fire(NextTrigger);
			}
		}
		
		
		public override string ToString()
		{
			return UmlDotGraph.Format(_stM.GetInfo());
		}


		protected enum Trigger
		{
			OnCheckState,
			OnProcess,
			OnComplete
		}


		protected Trigger NextTrigger { get; set; }


		protected Entity Entity { get; set; }


		protected abstract void CheckState();
		

		protected abstract void ExecuteProcessing();
		
		
		private void OnComplete()
		{
			Console.WriteLine($"Complete in {this.GetType().Name}");
		}
		

		private enum State
		{
			Init,
			ChekState,
			InProcess,
			Complete
		}
		private readonly StateMachine<State, Trigger> _stM = new StateMachine<State, Trigger>(State.Init);
	}
}