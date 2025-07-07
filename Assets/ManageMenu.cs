using UnityEngine;

public class ManageMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectLevel;

    private void Awake()
    {
        mainMenu.SetActive(true);
        selectLevel.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
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
    public void OnExitButton()
    {
        Application.Quit();
    }
}
