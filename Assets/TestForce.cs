using UnityEngine;
using UnityEngine.InputSystem;

public class TestForce : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float speed = 1f;
    Controller controller;
    InputAction moving;
    
    private void Awake()
    {
        controller = new Controller();
        moving = controller.Player.Move;
    }
    
    private void OnEnable()
    {
        controller.Enable();
    }
    
    private void OnDisable()
    {
        controller.Disable();
    }

    void Update()
    {
        float rotationAmount = 0f;
        if (Keyboard.current.qKey.isPressed)
        {
            rotationAmount = -rotationSpeed * Time.deltaTime;
        }
        if (Keyboard.current.eKey.isPressed)
        {
            rotationAmount = rotationSpeed * Time.deltaTime;
        }
        
        if (rotationAmount != 0)
        {
            transform.Rotate(0, rotationAmount, 0);
        }
        
        transform.Translate(moving.ReadValue<Vector2>() * speed * Time.deltaTime);
    }
}