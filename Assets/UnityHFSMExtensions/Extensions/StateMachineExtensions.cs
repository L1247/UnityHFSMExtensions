#region

using System.Collections.Generic;
using UnityHFSM;
using UnityHFSMExtensions.Interfaces;
using Transition = UnityHFSMExtensions.Interfaces.Transition;

#endregion

namespace UnityHFSMExtensions.Extensions
{
    public static class StateMachineExtensions
    {
    #region Public Methods

        public static void AddStateByInstance(this StateMachine stateMachine , State state)
        {
            stateMachine.AddState(state.GetType().Name , state);
        }

        public static void AddStates(this StateMachine stateMachine , List<string> states)
        {
            states.ForEach(state => stateMachine.AddState(state));
        }

        public static void AddStates(this StateMachine stateMachine , List<State> states)
        {
            states.ForEach(state => stateMachine.AddState(state.GetType().Name , state));
        }

        public static void AddTransitionFromAnyList(this StateMachine stateMachine , List<TransitionFromAny> list)
        {
            list.ForEach(t => stateMachine.AddTransitionFromAny(t.ToState , _ => t.Condition));
        }

        public static void AddTransitionList(this StateMachine stateMachine , List<Transition> transitions)
        {
            transitions.ForEach(t => stateMachine.AddTransition(t.FromStates , t.ToState , _ => t.Condition));
        }

        public static void AddTransitionsList(this StateMachine stateMachine , List<Transitions> transitions)
        {
            foreach (var t in transitions)
                t.FromStates
                 .ForEach(from => stateMachine.AddTransition(from , t.ToState , _ => t.Condition));
        }

        public static void AddTriggerTransitionFromAnyList(this StateMachine stateMachine , List<TriggerTransitionFromAny> list)
        {
            list.ForEach(t => stateMachine.AddTriggerTransitionFromAny(t.Trigger , t.ToState));
        }

        public static string GetCurrentStateName(this StateMachine stateMachine)
        {
            return stateMachine.ActiveStateName;
            // return stateMachine.GetState(stateMachine.ActiveStateName).GetType().Name;
        }

        public static bool HasState(this StateMachine stateMachine , string stateName)
        {
            var state = stateMachine.GetState(stateName);
            if (state == null) return false;
            return state.GetType().Name == stateName;
        }

    #endregion
    }
}