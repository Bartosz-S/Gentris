using NUnit.Framework;
using UnityEditor.SearchService;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ManageMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectLevel;

    private void Awake()
    {
        mainMenu.SetActive(true);
        selectLevel.SetActive(false);
        
    }

    public void OnLevelSelectButton()
    {
        mainMenu.SetActive(false);
        selectLevel.SetActive(true);
    }
    public void OnBackToMain()
    {
        mainMenu.SetActive(true);
        selectLevel.SetActive(false);
    }
}
