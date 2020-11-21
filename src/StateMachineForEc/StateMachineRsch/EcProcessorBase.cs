using System;
using Stateless;
using Stateless.Graph;

namespace StateMachineRsch
{
	public abstract class EcProcessorBase: IEcProcessor
	{
		protected EcProcessorBase()
		{
			_state = State.Init;
			_stM = new StateMachine<State, Trigger>(()=>_state, s=>_state = s);
			
			_stM.Configure(State.Init)
				.Permit(Trigger.OnCheckState, State.ChekState);

			_stM.Configure(State.ChekState)
				.OnEntry(() => InnerCheckState())
				.Permit(Trigger.OnProcess, State.InProcess)
				.Permit(Trigger.OnComplete, State.Complete);

			_stM.Configure(State.InProcess)
				.OnEntry(() => InnerExecuteProcessing())
				.Permit(Trigger.OnComplete, State.Complete);

			_stM.Configure(State.Complete)
				.OnEntry(() => OnComplete());
		}

		
		public void Process(Entity entity)
		{
			Reset(entity);

			while (_stM.State != State.Complete)
			{
				_stM.Fire(_nextTrigger);
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


		protected abstract bool CheckState(Entity entity);
		

		protected abstract void ExecuteProcessing(Entity entity);


		private void InnerCheckState()
		{
			_nextTrigger = CheckState(_entity) ? Trigger.OnProcess : Trigger.OnComplete;
		}


		private void InnerExecuteProcessing()
		{
			ExecuteProcessing(_entity);
			_nextTrigger = Trigger.OnComplete;
		}


		private void OnComplete()
		{
			Console.WriteLine($"Complete in {this.GetType().Name}");
		}
		
		
		private void Reset(Entity entity)
		{
			_entity = entity;
			_state = State.Init;
			_nextTrigger = Trigger.OnCheckState;
		}
		

		private enum State
		{
			Init,
			ChekState,
			InProcess,
			Complete
		}
		
		private readonly StateMachine<State, Trigger> _stM;
		private Entity _entity;
		private State _state;
		private Trigger _nextTrigger;
	}
}