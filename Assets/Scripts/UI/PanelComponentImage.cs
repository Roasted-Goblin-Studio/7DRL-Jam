using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelComponentImage : MonoBehaviour, IPanelComponent
{
    float fullLerpDuration = 1f; 

    float initialFullLerpDuration = 2f;
    
    private Image image;
    private bool isEnabled = true;

    IEnumerator Lerp(float duration, float target)
    {
        float timeElapsed = 0;
        float lerpDuration = (Mathf.Abs(image.color.a - target) / 1f) * duration;
        float startAlpha = image.color.a;
        float newAlpha = 0f;
        while (timeElapsed < lerpDuration)
        {
            newAlpha = Mathf.Lerp(startAlpha, target, timeElapsed / lerpDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newAlpha = target;
        image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
    }

    public void EnableComponent(bool initialSet) 
    {
        isEnabled = true;
        if (initialSet) 
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
            StartCoroutine(Lerp(initialFullLerpDuration, 1f));
        }       
        else 
        {
            StartCoroutine(Lerp(fullLerpDuration, 1f));
        }
    }

    public void DisableComponent(bool initialSet) 
    {
        isEnabled = false;
        if (initialSet) 
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
        else 
        {
            StopCoroutine("Lerp");
            StartCoroutine(Lerp(fullLerpDuration, 0f));
        }
    }

    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isEnabled)
        {
            EnableComponent(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
