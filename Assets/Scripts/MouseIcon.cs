using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseIcon : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    [SerializeField] private PlayerInput playerInput;
    private InputAction aimAction;

    public Transform Icon;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        aimAction = playerInput.actions["Aim"];
    }

    private void Start()
    {
        if (playerInput.currentControlScheme == "Keyboard And Mouse")
        { 
            //Cursor.visible = false; 
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        if (playerInput.currentControlScheme == "Keyboard And Mouse")
        {
            // Get the mouse position in world space. Using camDis for the Z axis.
            Vector3 mouse = playerCamera.ScreenToWorldPoint(new Vector3(aimAction.ReadValue<Vector2>().x, aimAction.ReadValue<Vector2>().y, 10));

            Icon.position = mouse;

            //could assign in constructor class???
            if(GetComponentInChildren<LookAtMouse>()!= null)
            Icon.rotation = GetComponentInChildren<LookAtMouse>().art.rotation;

            int playerLayer = GetComponent<PlayerStats>().PlayerID + 5;


            Icon.gameObject.layer = playerLayer;
            

        }
        else
        {
            Icon.gameObject.SetActive(false); 
        }
    }
    

    public Camera GetPlayerCamera()
    {
        return playerCamera;
    }
    //projectile know who we belog to -> communicates when hit to a GameManager, with info on who's projecitle it was -> communicates to player manager -> player -> mouse icon
}
