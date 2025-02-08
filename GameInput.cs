using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;


    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
            
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

        OnInteractAction?.Invoke(this, EventArgs.Empty);
        //Debug.Log(obj);
        //throw new System.NotImplementedException();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        /*
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = +1;
            //Debug.Log("Up!");
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
            //Debug.Log("Down!");
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
            //Debug.Log("Left!");
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = +1;
            //Debug.Log("Right!");
        }
        */
        inputVector = inputVector.normalized;
        
        //Debug.Log(inputVector);

        return inputVector;

    }
}
