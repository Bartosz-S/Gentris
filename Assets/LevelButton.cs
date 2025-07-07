using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private string levelName = string.Empty;
    public void OnChoosingLevel()
    {
        if (levelName == string.Empty)
        {
            return;
        }
        SceneManager.LoadScene(levelName);
    }
}
