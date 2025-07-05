using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Controller controller;
    private InputAction Moving;
    private GameObject catchedGameObject;
    private bool hovering = false;

    private void Awake()
    {
        controller = new Controller();
        Moving = controller.Player.CatchObject;
    }

    private void OnEnable()
    {
        Moving.started += catchObject;
        Moving.canceled += releaseObject;
        controller.Enable();
    }
    private void OnDisable()
    {
        Moving.started -= catchObject;
        Moving.canceled -= releaseObject;
        controller.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void catchObject(InputAction.CallbackContext context)
    {
        if (hovering)
        {

        }
        Debug.Log("Catched");
    }
    private void releaseObject(InputAction.CallbackContext context)
    {
        Debug.Log("Released");
    }

    private void OnMouseOver()
    {
        hovering = true;
    }
    private void OnMouseExit()
    {
        hovering = false;
    }
}
