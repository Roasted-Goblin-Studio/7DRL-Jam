using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHover : MonoBehaviour
{
    public float speed = 1.0f;

    [SerializeField] private Transform startTransform;
    private Vector3 targetPos;

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
        targetPos = new Vector3(transform.position.x, startTransform.position.y, transform.position.z);
        transform.position = targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
         // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            // Swap the position of the cylinder.
            //target.position *= -1.0f;
        }
    }

    void ChangePosition(MenuButton button) {
        targetPos = new Vector3(transform.position.x, button.transform.position.y, transform.position.z);
        //StopCoroutine("Lerp");
        //Debug.Log("Changing position!");
        //StartCoroutine(Lerp(button.transform));
    }
}
