using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public float scale;
    public Slider slider;

    void Start()
    {
        //Cache the Slider variables
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    void OnEnable()
    {
        //Subscribe to the Slider Click event
        slider.onValueChanged.AddListener(delegate { sliderCallBack(slider.value); });
    }

    //Will be called when Slider changes
    public void sliderCallBack(float value)
    {
        Debug.Log("Slider Changed: " + value);
        scale = slider.value;
    }
    // Update is called once per frame
    private void Update()
    {
        transform.localPosition = new Vector3(0, scale, -2.268);
        PlayerPrefs.SetFloat("Hight", scale);
    }
}

