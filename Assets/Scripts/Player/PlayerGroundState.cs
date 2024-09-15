namespace Player {
    public class PlayerGroundState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void Process() {
            base.Process();
            if (XInput != 0 || YInput != 0) StateMachine.ChangeState(Player.moveState);
        }

        public override void PhysicsProcess() {
            base.PhysicsProcess();
        }

        public override void Exit() {
            base.Exit();
        }
    }
}