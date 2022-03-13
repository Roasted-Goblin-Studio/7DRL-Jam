using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    private IPanelComponent[] components;

    public void EnablePanel(bool initialSet) 
    {
        gameObject.SetActive(true);
        if (gameObject.activeSelf) {
            components = GetComponentsInChildren<IPanelComponent>();
            foreach (IPanelComponent component in components) {
                component.EnableComponent(initialSet);
            }
        }
    }

    public void DisablePanel(bool initialSet) 
    {
        if (gameObject.activeSelf) {
            components = GetComponentsInChildren<IPanelComponent>();
            foreach (IPanelComponent component in components) 
            {
                component.DisableComponent(initialSet);
            }
        }
    }

    void Awake() 
    {
        components = GetComponentsInChildren<IPanelComponent>();
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
