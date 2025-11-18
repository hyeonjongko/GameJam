using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    Slider _slider;
    private float _Time;

    private float _add = 1.0;
    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_slider.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경을 합니다.
            _slider.value -= Time.deltaTime;
        }
    }
}
