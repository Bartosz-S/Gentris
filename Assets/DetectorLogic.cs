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
                Glue(other.gameObject);
                Debug.Log("Glued!");
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
        other.transform.parent.position = transform.parent.position;
        other.transform.parent.parent = transform.parent;
        isGlued = true;
    }
}
