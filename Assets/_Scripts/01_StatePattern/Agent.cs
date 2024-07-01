using Platformer.Sates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Platformer
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Agent : MonoBehaviour
    {
        public AgentData agentData;


        [HideInInspector]
        public AgentAnimations animationManager;

        [HideInInspector]
        public Rigidbody2D rb2d;

        public AgentGroundedDetector groundSensor;
        private AgentClimbDetector climbSensor;
        [HideInInspector]
        public AgentRenderer agentRenderer;

        public State currentState = null;
        public State previousState = null;
        [SerializeField]
        private State TransitionIdle;

        public IAgentInput agentInput;

        [HideInInspector]
        public AgentWeaponManager agentWeapon;
        //public WeaponData weaponData;
        public StateFactory stateFactory;

        public bool IsGrounded { get => groundSensor.isGrounded; }

        public bool CanClimb { get => climbSensor.CanClimb; }

        private Damagable damagable;

        [Header("State Debugging:")]
        public string stateName = "";

        [field: SerializeField]
        public UnityEvent OnRespawnRequired { get; set; }
        [field: SerializeField]
        public UnityEvent OnAgentDied { get; set; }

        private void Awake()
        {
            agentInput = GetComponentInParent<IAgentInput>();

            rb2d = GetComponent<Rigidbody2D>();

            groundSensor = GetComponentInChildren<AgentGroundedDetector>();
            climbSensor = GetComponentInChildren<AgentClimbDetector>();
            animationManager = GetComponentInChildren<AgentAnimations>();
            agentWeapon = GetComponentInChildren<AgentWeaponManager>();
            stateFactory = GetComponentInChildren<StateFactory>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();

            damagable = GetComponent<Damagable>();
        }


        private void Start()
        {

            foreach (var state in GetComponentsInChildren<State>())
            {
                state.InitializeState(this);
            }
            InitializeAgent(true);

            //stateName = currentState.GetType().ToString();
            agentInput.OnWeaponChange += SwapWeapon;

        }

        public void InitializeAgent(bool resetHealth = false)
        {
            TransitionToState(TransitionIdle, null);
            if(resetHealth)
                damagable.Initialize(agentData.health);
        }

        // Update is called once per frame
        void Update()
        {
            groundSensor.CheckIsGrounded();
            currentState.StateUpdate();


        }

        private void FixedUpdate()
        {
            
            currentState.StateFixedUpdate();

        }

        private void DisplayState()
        {
            if (previousState == null || previousState.GetType() != currentState.GetType())
            {
                stateName = currentState.GetType().ToString();
            }
        }

        public void TransitionToState(State desiredState, State callingState)
        {
            
            if (currentState != null)
            {
                currentState.Exit();
            }
                
            if (desiredState == null)
                return;

            previousState = currentState;
            currentState = desiredState;
            currentState.Enter();

            DisplayState();
        }
        //public void TransitionToState(Type stateType)
        //{
        //    var newState = stateManager.GetAppropriateState(stateType);
        //    if (newState == null)
        //        return;
        //    previousState = currentState;

        //    if (currentState != null)
        //        currentState.Exit();

        //    currentState = newState;

        //    currentState.Enter();

        //    if(previousState == null)
        //        previousState = currentState;

        //    DisplayState();
        //}

        public void GetHit()
        {
            currentState.GetHit();
        }

        public void AgentDied()
        {
            if (damagable.CurrentHealth > 0)
            {
                OnRespawnRequired?.Invoke();
            }
            else
            {
                currentState.Die();
            }


        }

        public void PickUp(WeaponData data)
        {
            if (agentWeapon == null)
                return;
            agentWeapon.PickUpWeapon(data);
        }

        public void SwapWeapon()
        {
            if (agentWeapon == null)
                return;
            agentWeapon.SwapWeapon();
        }
    }
}


