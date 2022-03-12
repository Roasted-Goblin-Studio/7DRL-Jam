using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComponentSlider : MonoBehaviour, IPanelComponent
{
    private Slider slider;

    public void EnableComponent(bool initialSet) 
    {
        slider.interactable = true;
    }

    public void DisableComponent(bool initialSet) 
    {
        slider.interactable = false;
    }
    
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
