using UnityEngine;
using UnityEngine.Events;
public class LevelEditor : MonoBehaviour
{
    [SerializeField] private float timeForLevel;
    private TimeBarController SliderController;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    private LayerMask interactableLayer;
    public UnityEvent endGame;

    private void Awake()
    {
        gameObject.tag = "LevelEditor";
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
            SliderController.gameObject.transform.parent.gameObject.SetActive(false);
            Debug.Log("Game Over");
            endGame.Invoke();
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
        endGame.Invoke();
        winScreen.SetActive(true);
        SliderController.gameObject.transform.parent.gameObject.SetActive(false);
        return true;
    }
}
