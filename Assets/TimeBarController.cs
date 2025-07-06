using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarController : MonoBehaviour
{
    private float timeForLevel = 1f;
    private float remainTime { set; get; }
    private Slider slider;
    

    private void Awake()
    {
        remainTime = timeForLevel;
        slider = GetComponent<Slider>();
        slider.maxValue = remainTime;
        slider.minValue = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    public void SetTime(float time)
    {
        timeForLevel = time;
    }
}
