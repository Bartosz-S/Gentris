using UnityEngine;
using UnityEngine.UIElements;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] private float timeForLevel;
    private TimeBarController SliderController;
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        SliderController = GameObject.FindGameObjectWithTag("TimeSlider").GetComponent<TimeBarController>();
        SliderController.SetTime(timeForLevel);
        //gameOverScreen = GameObject.FindGameObjectWithTag("GameOver");
    }
    private void Update()
    {
        isGameOver();
    }

    private void isGameOver()
    {
        if (SliderController.RemainTime <= 0 && gameOverScreen.activeSelf == false){
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over");
        }
    }

}
