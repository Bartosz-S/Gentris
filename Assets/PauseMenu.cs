using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void ReturnToGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
