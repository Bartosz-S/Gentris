using UnityEngine;
using UnityEngine.UIElements;
public class DetectorLogic : MonoBehaviour
{
    enum Type
    {
        Guan,
        Cito,
        Aden,
        Tean
    }
    [SerializeField] private Type acidType;
    private DetectorLogic detected;
    private bool isGlued = false;
    private bool isConnecting = false;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float connectionSpeed = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (isConnecting && !isGlued)
        {
            // Smoothly move to target position and rotation
            transform.parent.position = Vector3.Lerp(transform.parent.position, targetPosition, connectionSpeed * Time.deltaTime);
            transform.parent.rotation = Quaternion.Lerp(transform.parent.rotation, targetRotation, connectionSpeed * Time.deltaTime);
            
            // Check if we've reached the target
            if (Vector3.Distance(transform.parent.position, targetPosition) < 0.01f)
            {
                transform.parent.position = targetPosition;
                transform.parent.rotation = targetRotation;
                isGlued = true;
                isConnecting = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<DetectorLogic>(out detected))
        {
            if(isCorresponding(acidType, detected.acidType) && !isGlued && !isConnecting)
            {
                // Only glue if this object is currently selected by the player
                PlayerController playerController = FindObjectOfType<PlayerController>();
                if (playerController != null && playerController.IsObjectSelected(transform.parent.gameObject))
                {
                    StartConnection(other.gameObject);
                    playerController.ForceReleaseObject();
                    Debug.Log("Connecting...");
                }
            }
        }
       
    }
    private bool isCorresponding(Type acid1, Type acid2)
    {
        if(acid1 == Type.Guan && acid2 == Type.Cito || acid1 == Type.Cito && acid2 == Type.Guan
            || acid1 == Type.Tean && acid2 == Type.Aden || acid1 == Type.Aden && acid2 == Type.Tean)
        {
            return true;
        }
        return false;
    }
    private void StartConnection(GameObject other)
    {
        // Make sure the controlled object has a kinematic rigidbody
        Rigidbody thisRb = transform.parent.GetComponent<Rigidbody>();
        if (thisRb == null)
            thisRb = transform.parent.gameObject.AddComponent<Rigidbody>();
        
        thisRb.isKinematic = true;

        // Set target position and rotation
        targetPosition = other.transform.parent.position; //Vector3(0, 1, 0);

        targetRotation *= other.transform.parent.rotation * Quaternion.Euler(-90, 0, 0);
        
        // Move the controlled object to default layer
        transform.parent.gameObject.layer = 0; // Default layer
        
        isConnecting = true;
    }
}