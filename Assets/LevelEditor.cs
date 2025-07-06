using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    [SerializeField] private float timeForLevel;
    private TimeBarController SliderController;

    private void Awake()
    {
        SliderController = GameObject.FindGameObjectWithTag("TimeSlider").GetComponent<TimeBarController>();
        SliderController.SetTime(timeForLevel);
    }
    

    private void isGameOver()
    {
        //if(SliderController.)
    }

}
