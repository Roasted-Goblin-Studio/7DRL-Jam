using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelComponentParticles : MonoBehaviour, IPanelComponent
{
    private ParticleSystem particles;

    public void EnableComponent(bool initialSet) 
    {
        particles.Play();
    }

    public void DisableComponent(bool initialSet)
     {
        particles.Stop();
    }

    void Awake() 
    {
        particles = GetComponent<ParticleSystem>();
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
