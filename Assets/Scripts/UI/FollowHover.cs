using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHover : MonoBehaviour, IPanelComponent
{
    public float speed = 1.0f;

    [SerializeField] private Transform startTransform;
    private float lerpDuration = .5f; 
    private Vector3 targetPos;
    private bool isEnabled = true;

    public void EnableComponent(bool initialSet) {
        isEnabled = true;
        targetPos = new Vector3(transform.position.x, startTransform.position.y, transform.position.z);
        transform.position = targetPos;    
    }

    public void DisableComponent(bool initialSet) {
        isEnabled = false;
        if (!initialSet) 
        {

        }
    }

    void OnEnable() {
        MenuButton.onMenuButtonHover += ChangePosition;
    }

    void OnDisable() {
        MenuButton.onMenuButtonHover -= ChangePosition;   
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
        if (isEnabled) {
            // Move to hovered item
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
    }

    void ChangePosition(MenuButton button) {
        targetPos = new Vector3(transform.position.x, button.transform.position.y, transform.position.z);
    }
}
