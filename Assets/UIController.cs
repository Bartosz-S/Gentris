using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    private void Awake()
    {

    }
    private void OnEnable()
    {
        playerInput.SwitchCurrentActionMap("UI");

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
