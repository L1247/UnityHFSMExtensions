#region

using UnityEngine;
using UnityEngine.Assertions;
using UnityHFSM;
using UnityHFSMExtensions.Interfaces;
using UnityHFSMExtensions.Main;
using UnityHFSMExtensions.Zenject;
using Zenject;
using Transition = UnityHFSMExtensions.Interfaces.Transition;

#endregion

namespace UnityHFSMExtensions.Extensions
{
    public static class FSMContainerExtensions
    {
    #region Public Methods

        public static void Bind_FSM(this DiContainer container)
        {
            // Assert.IsTrue(container.HasBinding<FsmManager>() == false ,
            // $"already binding {GetColorString(Color.red , "[FsmManage]")}");
            Bind_StateMachine(container);
            container.BindInitializableExecutionOrder<FsmManager>(-1000);
            container.BindInterfacesAndSelfTo<FsmManager>().AsSingle().NonLazy().IfNotBound();
        }

        public static void Bind_Start_State(this DiContainer container , string stateName)
        {
            container.BindInstance(stateName).WithId(FsmZenjectIds.StartStateName);
        }

        public static void Bind_State<T>(this DiContainer container) where T : State
        {
            container.Bind(typeof(State)).To<T>().AsSingle();
        }

        public static void Bind_State(this DiContainer container , string stateName)
        {
            container.BindInstance(stateName).WithId(FsmZenjectIds.States);
        }

        public static void Bind_StateMachine(this DiContainer container)
        {
            Assert.IsTrue(container.HasBinding<StateMachine>() == false ,
                          $"already binding {GetColorString(Color.red , "StateMachine")}");
            container.Bind<StateMachine>().AsSingle().IfNotBound();
        }

        public static void Bind_Transition<T>(this DiContainer container) where T : Transition
        {
            container.Bind(typeof(Transition)).To<T>().AsSingle();
        }

        public static void Bind_TransitionFromAny<T>(this DiContainer container) where T : TransitionFromAny
        {
            container.Bind(typeof(TransitionFromAny)).To<T>().AsSingle();
        }

        public static void Bind_Transitions<T>(this DiContainer container) where T : Transitions
        {
            container.Bind(typeof(Transitions)).To<T>().AsSingle();
        }

        public static void Bind_TriggerTransitionFromAny<T>(this DiContainer container) where T : TriggerTransitionFromAny
        {
            container.Bind(typeof(TriggerTransitionFromAny)).To<T>().AsSingle();
        }

        public static void Bind_TriggerTransitions<T>(this DiContainer container) where T : TriggerTransitions
        {
            container.Bind(typeof(TriggerTransitions)).To<T>().AsSingle();
        }

        public static string GetColorString(Color color , string str)
        {
            var colorText = color == Color.red ? "red" : "white";
            return $"<color={colorText}>{str}</color>";
        }

    #endregion
    }
}