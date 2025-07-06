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

}
