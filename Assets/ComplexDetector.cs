using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComplexDetector : MonoBehaviour
{
    [SerializeField] private List<GameObject> jointed = new List<GameObject>();
    private List<DetectorLogic> detectors = new List<DetectorLogic>();
    private float x=0,y=0,z=0;
    private Vector3 resultVector = new Vector3(0, 0, 0);
    private bool canConnect = false;

    private void Awake()
    {
        DetectorLogic d;
        foreach (GameObject go in jointed)
        {
            go.TryGetComponent<DetectorLogic>(out d);
            detectors.Add(d);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void checkCanConnect()
    {
        foreach(DetectorLogic d in detectors)
        {
            canConnect = !(canConnect || d.CanConnect);
        }
    }
}
