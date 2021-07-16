using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.started || context.performed)
        {
            Vector2 value = context.ReadValue<Vector2>();
            PlayerManager.Instance.playerMove.SetMoveInput(value);
        }
        if(context.canceled)
        {
            PlayerManager.Instance.playerMove.SetMoveInput(Vector2.zero);
        }
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        Vector2 value = context.ReadValue<Vector2>();
        PlayerManager.Instance.playerMove.SetRotInput(value);
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            PlayerManager.Instance.playerShot.Shot();
        }
    }
}
