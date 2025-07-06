using UnityEngine;
public class LevelEditor : MonoBehaviour
{
    [SerializeField] private float timeForLevel;
    private TimeBarController SliderController;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    private LayerMask interactableLayer;

    private void Awake()
    {
        SliderController = GameObject.FindGameObjectWithTag("TimeSlider").GetComponent<TimeBarController>();
        SliderController.TimeForLevel = timeForLevel;
        interactableLayer = LayerMask.NameToLayer("Movable");
    }

    private void Start()
    {
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void Update()
    {
        isGameOver();
        isWon();
    }

    private bool isGameOver()
    {
        if (SliderController.RemainTime <= 0 && gameOverScreen.activeSelf == false){
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over");
            return true;
        }
        return false;
    }
    private bool isWon()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == interactableLayer)
            {
                return false;
            }
        }
        winScreen.SetActive(true);
        return true;
    }
}
