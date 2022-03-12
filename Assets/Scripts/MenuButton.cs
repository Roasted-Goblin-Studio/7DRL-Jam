using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPanelComponent
{
    public enum eMenuButton {
        Start, Options, Exit
    };

    public eMenuButton type;
    private bool isEnabled = true;

    public delegate void OnMenuButtonHover(MenuButton button);
    public static event OnMenuButtonHover onMenuButtonHover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableComponent(bool initialSet) 
    {
        isEnabled = true;
    }

    public void DisableComponent(bool initialSet) 
    {
        isEnabled = false;
    }

    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
   {
        if (isEnabled) 
        {
            //Output to console the GameObject's name and the following message
            Debug.Log("Cursor Entering " + name + " GameObject");
            onMenuButtonHover?.Invoke(this);
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
    }
}
