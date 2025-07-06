using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    private float timeForLevel = 1f;
    public float TimeForLevel
    {
        set { timeForLevel = value; }
        get { return timeForLevel; }
    }
    private float remainTime;
    public float RemainTime
    {
        get { return remainTime; }
    }
    private Slider slider;
    

    private void Awake()
    {
        remainTime = TimeForLevel;
        slider = GetComponent<Slider>();
        slider.minValue = 0;
    }
    private void Start()
    {
        remainTime = TimeForLevel;
        slider.maxValue = remainTime;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        slider.value = remainTime;
    }
    private void UpdateTime()
    {
        remainTime -= Time.deltaTime;
    }
}
