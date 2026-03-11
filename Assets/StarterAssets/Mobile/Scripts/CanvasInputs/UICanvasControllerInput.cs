using UnityEngine;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        // This script is meant to be used with the UICanvasController prefab
        [Header("Output")]
        public PlayerController starterAssetsInputs;

        // Move is usually a Vector2 representing the direction and magnitude of movement input
        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssetsInputs.MoveInput(virtualMoveDirection.normalized);
        }

        // Look is usually a delta value so we use Vector2
        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            //starterAssetsInputs.LookInput(virtualLookDirection);
        }

        // Jump is triggered by a button press so bool is fine here
        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssetsInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            //starterAssetsInputs.SprintInput(virtualSprintState);
        }
    }
}
