using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

namespace RebelHavoc
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Inputs/InputReader")]
    public class InputReader : ScriptableObject, IPlayerActions
    {
		public event UnityAction<Vector2> Move = delegate {};
        public event UnityAction Jump = delegate { };
        public event UnityAction Attack = delegate { };
        public event UnityAction Pause = delegate { };


        [SerializeField] private VirtualJoystick joystick;



        InputSystem_Actions input;
		private void OnEnable()
		{
			if (input == null)
			{
				input = new InputSystem_Actions();
				input.Player.SetCallbacks(this);
			}
		}
		public void EnablePlayerActions()
		{
			input.Enable();
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			switch(context.phase)
			{
				case InputActionPhase.Performed:
				case InputActionPhase.Canceled:
					Move?.Invoke(context.ReadValue<Vector2>());
					break;
				default:
					break;
			}
		}

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Jump?.Invoke(); 
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Attack?.Invoke(); 
            }
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                Pause?.Invoke(); // Invoke the pause event
            }
        }

        public void OnLook(InputAction.CallbackContext context){}
		public void OnInteract(InputAction.CallbackContext context){}
		public void OnCrouch(InputAction.CallbackContext context){}
		public void OnPrevious(InputAction.CallbackContext context){}
		public void OnNext(InputAction.CallbackContext context){}
		public void OnSprint(InputAction.CallbackContext context){}
	}
}
