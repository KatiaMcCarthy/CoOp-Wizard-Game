using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform m_transform;
    public Transform art;   //public so aimin scripts can access the correct rotation

    [SerializeField] private GameObject aimIndicator;

    [SerializeField] private PlayerInput playerInput;
    private InputAction aimAction;
    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        aimAction = playerInput.actions["Aim"];
        m_transform = this.transform;
        playerCamera = GetComponentInParent<MouseIcon>().GetPlayerCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.currentControlScheme == "Keyboard And Mouse")
        {
            //mouse aiming

            // Distance from camera to object.  We need this to get the proper calculation.
            float camDis = playerCamera.transform.position.y - m_transform.position.y;

            // Get the mouse position in world space. Using camDis for the Z axis.
            Vector3 mouse = playerCamera.ScreenToWorldPoint(new Vector3(aimAction.ReadValue<Vector2>().x, aimAction.ReadValue<Vector2>().y, camDis));

            float AngleRad = Mathf.Atan2(mouse.y - m_transform.position.y, mouse.x - m_transform.position.x);
            float angle = (180 / Mathf.PI) * AngleRad;

            art.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
        else
        {
            //controller aiming

            //will need to make this grow depending on how long you have the button held down
            
            //get the direction of the stick, use that to determine our facing?
            Vector2 aimDirection = aimAction.ReadValue<Vector2>() * 5;
       
            // Distance from camera to object.  We need this to get the proper calculation.
            float camDis = playerCamera.transform.position.y - m_transform.position.y;

            // Get the mouse position in world space. Using camDis for the Z axis.
            Vector3 mouse =
                new Vector3(aimDirection.x + transform.position.x, aimDirection.y + transform.position.y, camDis);
            
            aimIndicator.transform.position = mouse;

            float AngleRad = Mathf.Atan2(mouse.y - m_transform.position.y, mouse.x - m_transform.position.x);
            float angle = (180 / Mathf.PI) * AngleRad;

            art.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        }
    }
}
