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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<DetectorLogic>(out detected))
        {
            if(isCorresponding(acidType, detected.acidType) && !isGlued)
            {
                // Only glue if this object is currently selected by the player
                PlayerController playerController = FindObjectOfType<PlayerController>();
                if (playerController != null && playerController.IsObjectSelected(transform.parent.gameObject))
                {
                    Glue(other.gameObject);
                    playerController.ForceReleaseObject();
                    Debug.Log("Glued!");
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
    private void Glue(GameObject other)
    {
        // Get the rigidbodies of both objects
        Rigidbody thisRb = transform.parent.GetComponent<Rigidbody>();
        Rigidbody otherRb = other.transform.parent.GetComponent<Rigidbody>();
        
        // Make the controlled object non-kinematic so it can be affected by the joint
        thisRb.isKinematic = false;
        
        // Match the rotation of the other object
        transform.parent.eulerAngles = other.transform.parent.eulerAngles;
        
        // Create spring joint on the controlled object
        SpringJoint springJoint = transform.parent.gameObject.AddComponent<SpringJoint>();
        springJoint.connectedBody = otherRb;
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = Vector3.zero;
        springJoint.anchor = Vector3.zero;
        
        // Configure spring properties for a natural connection
        springJoint.spring = 500f;
        springJoint.damper = 100f;
        springJoint.minDistance = 0f;
        springJoint.maxDistance = 0.1f;
        
        // Move the controlled object to default layer
        transform.parent.gameObject.layer = 0; // Default layer
        
        isGlued = true;
    }
}