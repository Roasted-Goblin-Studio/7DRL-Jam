using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComponentButton : MonoBehaviour, IPanelComponent
{
    private Button button;

    public void EnableComponent(bool initialSet /* irrelevant */) 
    {
        button.interactable = true;
    }

    public void DisableComponent(bool initialSet /* irrelevant */) 
    {
        button.interactable = false;
    }

    void Awake() {
        button = GetComponent<Button>();
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
