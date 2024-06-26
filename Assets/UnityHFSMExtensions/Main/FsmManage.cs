#region

using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityHFSM;
using UnityHFSMExtensions.Extensions;
using UnityHFSMExtensions.Interfaces;
using UnityHFSMExtensions.Zenject;
using Zenject;
using Transition = UnityHFSMExtensions.Interfaces.Transition;

#endregion

namespace UnityHFSMExtensions.Main
{
    public class FsmManager : IInitializable , ITickable
    {
    #region Public Variables

        /// <summary>
        ///     is Initialized
        /// </summary>
        public bool Initialized { get; private set; }

    #endregion

    #region Private Variables

        [Inject]
        private List<State> states;

        [Inject(Id = FsmZenjectIds.States)]
        private List<string> stringStates;

        [Inject]
        private StateMachine fsm;

        [Inject(Id = FsmZenjectIds.StartStateName)]
        private string startStateName;

        [Inject]
        private List<TriggerTransitionFromAny> triggerTransitionFromAnyList;

        [Inject]
        private List<TriggerTransitions> triggerTransitionsList;

        [Inject]
        private List<TransitionFromAny> transitionFromAnyList;

        [Inject]
        private List<Transitions> transitionsList;

        [Inject]
        private List<Transition> transitionList;

    #endregion

    #region Public Methods

        public void ChangeState(string stateName)
        {
            fsm.RequestStateChange(stateName , true);
        }

        public string GetCurrentStateName()
        {
            return fsm.GetCurrentStateName();
        }

        public T GetState<T>() where T : State
        {
            return (T)fsm.GetState(typeof(T).Name);
        }

        public StateBase<string> GetState(string stateName)
        {
            return fsm.GetState(stateName);
        }

        public void Initialize()
        {
            Init();
        }

        public void Tick()
        {
            if (Initialized == false) return;
            fsm.OnLogic();
        }

        public void Trigger(string trigger)
        {
            fsm.Trigger(trigger);
        }

    #endregion

    #region Private Methods

        /// <summary>
        ///     Manual initialize.
        /// </summary>
        private void Init()
        {
            if (Initialized) return;
            Assert.IsTrue(states.Count > 0 || stringStates.Count > 0 , "has no state.");
            fsm.AddStates(stringStates);
            fsm.AddStates(states);
            fsm.AddTriggerTransitionFromAnyList(triggerTransitionFromAnyList);
            fsm.AddTriggerTransitions(triggerTransitionsList);
            fsm.AddTransitionFromAnyList(transitionFromAnyList);
            fsm.AddTransitionsList(transitionsList);
            fsm.AddTransitionList(transitionList);
            fsm.SetStartState(startStateName);
            fsm.Init();
            Initialized = true;
        }

    #endregion
    }
}