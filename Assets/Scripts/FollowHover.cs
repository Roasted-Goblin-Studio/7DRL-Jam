using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHover : MonoBehaviour, IPanelComponent
{
    public float speed = 1.0f;

    [SerializeField] private Transform startTransform;
    private float lerpDuration = .5f; 
    private Vector3 targetPos;

    public void EnableComponent(bool initialSet) {
        targetPos = new Vector3(transform.position.x, startTransform.position.y, transform.position.z);
        transform.position = targetPos;    
    }

    public void DisableComponent(bool initialSet) {

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
        // Move to hovered item
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }

    void ChangePosition(MenuButton button) {
        Debug.Log("CHANGE!");
        targetPos = new Vector3(transform.position.x, button.transform.position.y, transform.position.z);
    }
}
