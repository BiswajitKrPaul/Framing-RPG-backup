using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player {
    public class PlayerMoveState : PlayerState {
        [SerializeField] private float moveSpeed;

        public override void Enter() {
            base.Enter();
        }

        public override void Process() {
            base.Process();
            var speedVector = new Vector2(XInput, YInput);
            Player.SetVelocity(speedVector * moveSpeed);
            if (Player.PlayerRigidBody2D.velocity == Vector2.zero)
                StateMachine.ChangeState(Player.groundState);
        }

        public override void PhysicsProcess() {
            base.PhysicsProcess();
        }

        public override void Exit() {
            base.Exit();
        }
    }
}