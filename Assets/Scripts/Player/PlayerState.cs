using System;
using UnityEngine;

namespace Player {
    public class PlayerState : MonoBehaviour {
        protected PlayerController Player;
        protected StateMachine StateMachine;
        private string _animName;

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
            Player.PlayerAnimator.SetInteger(PlayerConstants.WeaponType, (int)Player.PlayerCurrentWeapon);
            if (XInput == 0 && YInput == 0) return;
            Player.PlayerAnimator.SetFloat(PlayerConstants.XVelocity, XInput);
            Player.PlayerAnimator.SetFloat(PlayerConstants.YVelocity, YInput);
        }

        public virtual void PhysicsProcess() {
        }

        public virtual void Exit() {
            Player.PlayerAnimator.SetBool(_animName, false);
        }
    }
}