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
        private List<TransitionFromAny> transitionFromAnyList;

        [Inject]
        private List<Transitions> transitionsList;

        [Inject]
        private List<Transition> transitionList;

    #endregion

    #region Public Methods

        public void Initialize()
        {
            Assert.IsTrue(states.Count > 0 , "no any states.");
            fsm.AddStates(stringStates);
            fsm.AddStates(states);
            fsm.AddTriggerTransitionFromAnyList(triggerTransitionFromAnyList);
            fsm.AddTransitionFromAnyList(transitionFromAnyList);
            fsm.AddTransitionsList(transitionsList);
            fsm.AddTransitionList(transitionList);
            fsm.SetStartState(startStateName);
            fsm.Init();
        }

        public void Tick()
        {
            fsm.OnLogic();
        }

    #endregion
    }
}