using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHover : MonoBehaviour
{
    [SerializeField] private float lerpDuration = .5f; 

    void OnEnable() {
        MenuButton.onMenuButtonHover += ChangePosition;
    }

    IEnumerator Lerp(Transform buttonTransform)
    {
        float timeElapsed = 0;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x, buttonTransform.position.y, startPos.z);
        while (timeElapsed < lerpDuration)
        {
            float t = timeElapsed / lerpDuration;
            t = t * t * (3f - 2f * t);
            transform.position = Vector3.Lerp(startPos, endPos, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangePosition(MenuButton button) {
        StopCoroutine("Lerp");
        Debug.Log("Changing position!");
        StartCoroutine(Lerp(button.transform));
    }
}
