using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool dash;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        [Header("Sensitivity Settings")]
        [Range(0.01f, 10f)]
        public float lookSensitivity = 1.0f;

        [Header("Pause")]
        public bool pause;

#if ENABLE_INPUT_SYSTEM
        // Movement input
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        // Look input
        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        // Jump input
        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        // Sprint input
        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }

        // Dash input
        public void OnDash(InputValue value)
        {
            DashInput(value.isPressed);
        }

        public void OnPause(InputValue value)
        {
            PauseInput(value.isPressed);
        }

#endif

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            // Apply sensitivity scaling
            look = newLookDirection * lookSensitivity;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void DashInput(bool newDashState)
        {
            dash = newDashState;
        }

        public void PauseInput(bool newPauseState)
        {
            pause = newPauseState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
