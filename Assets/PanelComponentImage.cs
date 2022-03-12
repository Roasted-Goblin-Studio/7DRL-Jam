using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComponentImage : MonoBehaviour, IPanelComponent
{
    float fullLerpDuration = 1f; 
    float targetAlpha = 0f;
    
    private Image image;

    IEnumerator Lerp()
    {
        float timeElapsed = 0;
        float lerpDuration = (Mathf.Abs(image.color.a - targetAlpha) / 1f) * fullLerpDuration;
        float startAlpha = image.color.a;
        float newAlpha = 0f;
        while (timeElapsed < lerpDuration)
        {
            newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / lerpDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newAlpha = targetAlpha;
        image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
    }

    public void EnableComponent(bool initialSet) 
    {
        if (initialSet) 
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        } 
        else 
        {
            targetAlpha = 1f;
            StartCoroutine(Lerp());
        }
    }

    public void DisableComponent(bool initialSet) 
    {
        if (initialSet) 
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
        else 
        {
            targetAlpha = 0f;
            StopCoroutine("Lerp");
            StartCoroutine(Lerp());
        }
    }

    void Awake()
    {
        image = GetComponent<Image>();
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
