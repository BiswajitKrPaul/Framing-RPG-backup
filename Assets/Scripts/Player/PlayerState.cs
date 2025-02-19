using UnityEngine;

namespace Player {
    public class PlayerState : MonoBehaviour {
        private string _animName;
        protected PlayerController Player;
        protected StateMachine StateMachine;

        protected Vector2 PlayerVelocity => Player.PlayerRigidBody2D.velocity;
        protected float XInput => Player.XInput;
        protected float YInput => Player.YInput;
        protected bool IsAttacking => Player.IsAttacking;

        public void SetUp(PlayerController pC, StateMachine sM, string animName) {
            Player = pC;
            StateMachine = sM;
            _animName = animName;
        }

        public virtual void Enter() {
            Player.PlayerAnimator.SetBool(_animName, true);
        }

        public virtual void Process() {
        }

        public virtual void PhysicsProcess() {
            if (Mathf.Abs(XInput) == 0 && Mathf.Abs(YInput) == 0) return;
            Player.PlayerAnimator.SetFloat(PlayerConstants.XVelocity, XInput);
            Player.PlayerAnimator.SetFloat(PlayerConstants.YVelocity, YInput);
        }

        public virtual void Exit() {
            Player.PlayerAnimator.SetBool(_animName, false);
        }
    }
}