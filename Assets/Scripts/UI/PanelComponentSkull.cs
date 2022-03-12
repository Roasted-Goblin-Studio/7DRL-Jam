using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComponentSkull : MonoBehaviour, IPanelComponent
{
    private Animator animator;
    private Image image;

    void Awake()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void EnableComponent(bool initialSet) 
    {
        animator.Play("Blink");
    }

    public void DisableComponent(bool initialSet) 
    {
        animator.Play("Skull Disappear");
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
