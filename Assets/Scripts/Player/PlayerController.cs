using UnityEngine;
using UnityEngine.InputSystem;

namespace Player {
    public class PlayerController : MonoBehaviour {
        #region Weapons

        public WeaponType playerCurrentWeapon = WeaponType.None;

        #endregion

        private void Awake() {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
            _moveInputActions = _playerInputActions.Player.Movement;
            _playerInputActions.Player.Attack.performed += OnAttackOnPerformed;
            _playerInputActions.Player.Weapon.performed += OnWeaponEquippedPerformed;
            groundState.SetUp(this, stateMachine, PlayerConstants.Idle);
            moveState.SetUp(this, stateMachine, PlayerConstants.IsWalking);
        }

        private void Start() {
            stateMachine.Initialize(groundState);
        }

        private void Update() {
            stateMachine.CurrentState.Process();
            GetInputs();
        }

        private void FixedUpdate() {
            stateMachine.CurrentState.PhysicsProcess();
        }

        private void OnWeaponEquippedPerformed(InputAction.CallbackContext context) {
            if (!context.performed) return;
            SetWeaponType(context);
        }

        private void SetWeaponType(InputAction.CallbackContext context) {
            playerCurrentWeapon = context.control.displayName.ToLower() switch {
                "1" => WeaponType.Hoe,
                "2" => WeaponType.None,
                "x" => WeaponType.None,
                _ => WeaponType.None
            };
            SetAnimatorLayerWeight();
        }

        private void SetAnimatorLayerWeight() {
            RemoveAllLayers();
            if (playerCurrentWeapon == WeaponType.None)
                animator.SetLayerWeight(animator.GetLayerIndex(PlayerConstants.BaseLayer), 1);
            else
                animator.SetLayerWeight(animator.GetLayerIndex(PlayerConstants.HoeLayer), 1);
        }

        private void RemoveAllLayers() {
            animator.SetLayerWeight(animator.GetLayerIndex(PlayerConstants.BaseLayer), 0);
            animator.SetLayerWeight(animator.GetLayerIndex(PlayerConstants.HoeLayer), 0);
        }


        private void OnAttackOnPerformed(InputAction.CallbackContext context) {
            if (!context.performed) return;
            IsAttacking = !IsAttacking;
            Debug.Log("Attacking");
        }


        private void GetInputs() {
            _movementDirection = _moveInputActions.ReadValue<Vector2>();
        }

        public void SetVelocity(Vector2 velocity) {
            rb.velocity = velocity;
        }

        #region PlayerInputActions

        private PlayerInputActions _playerInputActions;
        private InputAction _moveInputActions;

        #endregion


        #region MovementVectors

        private Vector2 _movementDirection;
        public bool IsAttacking { get; private set; }
        public float XInput => _movementDirection.x;
        public float YInput => _movementDirection.y;
        public Animator PlayerAnimator => animator;
        public Rigidbody2D PlayerRigidBody2D => rb;

        #endregion


        #region Player States Info

        [Header("Player States Info")] [SerializeField]
        private StateMachine stateMachine;

        public PlayerGroundState groundState;
        public PlayerMoveState moveState;

        #endregion


        #region Components

        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rb;

        #endregion
    }
}