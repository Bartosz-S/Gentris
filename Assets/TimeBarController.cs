using TMPro;
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
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject textObject;
    [SerializeField] private GameObject sliderFill;
    [SerializeField] Color[] colors = new Color[4];
    [SerializeField] private float lerpDur = 1f;
    private Color textColor;
    private Color fillColor;
    private float percentage = 1;
    private TextMeshProUGUI tmpugui;
    private Image image;
    private float lerpTime = 0f;

    private void Awake()
    {
        remainTime = TimeForLevel;
        slider = GetComponent<Slider>();
        slider.minValue = 0;
        tmpugui = textObject.GetComponent<TextMeshProUGUI>();
        image = sliderFill.GetComponent<Image>();
        textColor = colors[0];
        fillColor = colors[0];
    }
    private void Start()
    {
        
        remainTime = TimeForLevel;
        slider.maxValue = remainTime;
        UpdatePercentage();
    }


    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale < 0.95f)
        {
            return;
        }
        UpdateTime();
        UpdateSlider();
        ChangeColors();
    }

    private void UpdateSlider()
    {
        slider.value = remainTime;
        percentage = remainTime / timeForLevel;
    }
    private void UpdateTime()
    {
        remainTime -= Time.deltaTime;
    }
    private void ChangeColors()
    {
        UpdatePercentage();
        if(percentage < 0.25f)
        {
            /*textColor = Color.Lerp(textColor, colors[1], lerpSpeed * Time.deltaTime);
            fillColor = Color.Lerp(fillColor, colors[1], lerpSpeed * Time.deltaTime);
            Debug.Log("Changed!");*/
            textColor = colors[3];
            fillColor = colors[3];
            Debug.Log(fillColor.ToString());
        }
        else if (percentage < 0.5f)
        {
            textColor = colors[2];
            fillColor = colors[2];
            Debug.Log(fillColor.ToString());
        }
        else if (percentage < 0.75f)
        {
            textColor = colors[1];
            fillColor = colors[1];
            Debug.Log(fillColor.ToString());
        }
        
        if(tmpugui.color != textColor)
        {
            lerpTime = 0f;
            lerpTime += Time.deltaTime / lerpDur;
            tmpugui.color = Color.Lerp(tmpugui.color, textColor, lerpTime);
            image.color = Color.Lerp(image.color, fillColor, lerpTime);

            if (lerpTime >= 1f)
            {
                lerpTime = 0f;
            }
        }
        

    }
    private void UpdatePercentage()
    {
        percentage = remainTime / timeForLevel;
    }
}
