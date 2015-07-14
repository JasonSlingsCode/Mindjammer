using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Text LabelText;
    private string[] LabelTexts = new string[]
    {
        "The Core Worlds",
        "Commonality Space",
        "The Fringe Worlds",
        "The Outer Worlds"
    };
    public Slider TheSlider;
    public float TheValue;

    void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    public void TheSliderValue()
    {
        TheValue = TheSlider.value;
        LabelText.text = LabelTexts[Mathf.FloorToInt(TheValue)];
    }
}
