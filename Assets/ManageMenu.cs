using UnityEditor.SearchService;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class ManageMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectLevel;

    private void Awake()
    {
        mainMenu.SetActive(true);
        selectLevel.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelSelect()
    {
        mainMenu.SetActive(false);
        selectLevel.SetActive(true);
    }
}
