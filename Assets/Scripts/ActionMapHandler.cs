using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionMapHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    public void SetActionMap(string actionName)
    {
        playerInput.SwitchCurrentActionMap(actionName);
    }
}
