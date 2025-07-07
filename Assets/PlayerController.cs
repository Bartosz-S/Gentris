using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private Controller controller;
    private InputAction Moving;
    private bool hovering = false;
    [SerializeField] private Vector2 mousePosition = Vector2.zero;
    private Ray mouseRay;
    private RaycastHit hit;
    private Camera mainCam;
    [SerializeField] private float maxSpeed;
    private bool selected = false;
    private GameObject selectedObj;
    private Vector2 followPoint;
    [SerializeField] private float defaultZAxis = 6f;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private GameObject PauseMenu;
    private InputAction Pausing;
    private Color selectedObjColor;
    private LevelEditor lvlEdit;
       
    private void Awake()
    {
        controller = new Controller();
        mainCam = Camera.main;
        if(GameObject.FindGameObjectWithTag("LevelEditor") != null)
        {
            lvlEdit = GameObject.FindGameObjectWithTag("LevelEditor").GetComponent<LevelEditor>();
            lvlEdit.endGame.AddListener(DisableMoving);
        }
    }
    private void OnEnable()
    {
        playerInput.SwitchCurrentActionMap("Player");
        Moving = controller.Player.CatchObject;
        Pausing = controller.Player.Pause;
        EnableMoving();
        Pausing.performed += PauseGame;
        controller.Enable();
    }
    private void OnDisable()
    {
        DisableMoving();
        Pausing.performed -= PauseGame;
        controller.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        mousePosition = Mouse.current.position.ReadValue();
        mouseRay = mainCam.ScreenPointToRay(mousePosition);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * 200, Color.red);
        if (selected)
        {
            MoveObject();
        }
    }
    private void MoveObject()
    {
        if (PauseMenu.activeSelf || selectedObj == null)
        {
            return;
        }
        Physics.Raycast(mouseRay, out hit);
        followPoint = new Vector2(hit.point.x, hit.point.y);
        
        Rigidbody rb = selectedObj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 targetPosition = new Vector3(followPoint.x, followPoint.y, defaultZAxis);
            
            if (rb.isKinematic)
            {
                // For kinematic rigidbodies, use MovePosition for proper physics integration
                rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, lerpSpeed * 10 * Time.deltaTime));
            }
            else
            {
                // For non-kinematic rigidbodies, use velocity-based movement
                Vector3 direction = (targetPosition - rb.position).normalized;
                float distance = Vector3.Distance(rb.position, targetPosition);
                rb.linearVelocity = direction * Mathf.Min(distance * lerpSpeed, maxSpeed);
            }
        }
        else
        {
            // Fallback to transform manipulation if no rigidbody
            if (Mathf.Abs(selectedObj.transform.position.x - followPoint.x) > 0.01f
                && Mathf.Abs(selectedObj.transform.position.y - followPoint.y) > 0.01f)
            {
                selectedObj.transform.position = new Vector3(Vector2.Lerp(selectedObj.transform.position, followPoint, lerpSpeed*Time.deltaTime).x,
                    Vector2.Lerp(selectedObj.transform.position, followPoint, lerpSpeed*Time.deltaTime).y, defaultZAxis);
            }
        }
    }
    private void catchObject(InputAction.CallbackContext context)
    {
        hovering = true;
        if (hovering)
        {
            if (Physics.Raycast(mouseRay, out hit))
            {
                selectedObj = hit.collider.gameObject;
                //defaultZAxis = selectedObj.transform.position.z;
                followPoint = new Vector3(hit.point.x, hit.point.y, defaultZAxis);
                if(selectedObj.layer == LayerMask.NameToLayer("Movable")){
                    selected = true;
                }
                else
                {
                    selected = false;
                }
            }
        }
        Debug.Log("Catched");
    }
    private void releaseObject(InputAction.CallbackContext context)
    {
        selected = false;
        Debug.Log("Released");
    }
    
    // Public method to check if a specific object is selected
    public bool IsObjectSelected(GameObject obj)
    {
        return selected && selectedObj == obj;
    }
    
    // Public method to force release the selected object
    public void ForceReleaseObject()
    {
        selected = false;
        selectedObj = null;
        Debug.Log("Force Released");
    }
    
    private void PauseGame(InputAction.CallbackContext context)
    {
        if (!PauseMenu.activeSelf && Time.timeScale == 1)
        {
            PauseMenu.SetActive(true);
            DisableMoving();
        }
        else
        {
            PauseMenu.SetActive(false);
            EnableMoving();
        }
    }
    private void OnMouseOver()
    {
        hovering = true;
        if(selectedObj != null)
        {
            selectedObjColor = selectedObj.GetComponent<Renderer>().material.color;
            selectedObj.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    private void OnMouseExit()
    {
        hovering = false;
        if (selectedObj != null)
        {
            selectedObj.GetComponent<Renderer>().material.color = selectedObjColor;
        }
    }

    private void DisableMoving()
    {
        Moving.started -= catchObject;
        Moving.canceled -= releaseObject;
        selectedObj = null;
    }
    private void EnableMoving()
    {
        Moving.started += catchObject;
        Moving.canceled += releaseObject;
        selectedObj = null;
    }
}