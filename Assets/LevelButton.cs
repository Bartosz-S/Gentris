using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private string levelName = string.Empty;
    public void OnChoosingLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
