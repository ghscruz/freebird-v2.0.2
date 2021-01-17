using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParticleTrigger : MonoBehaviour
{

    public ParticleSystem part;
    public GameObject bird;
    public bool enter = false;
    float timeElapsedl1 = 0;
    float timeElapsedl2 = 0;
    float lerpDuration = 7;
    float timeElapsedonExit = 0;
    int particlesl1;
    int particlesl2;

    // Start is called before the first frame update
    void Start()
    {
        particlesl1 = part.maxParticles + 100;
        particlesl2 = particlesl1 + 300;
      
    }    
    // Update is called once per frame
    void Update()
    {
        if(enter)
        {
            if(bird.transform.position.y <= 100 && timeElapsedl1 < lerpDuration)
            {
                part.maxParticles = (int)Mathf.Lerp(part.maxParticles, particlesl1 , timeElapsedl1 / lerpDuration);
                timeElapsedl1 += Time.deltaTime;
            }
            else if(bird.transform.position.y <= 150 && bird.transform.position.y > 100 && timeElapsedl2 < lerpDuration)
            {
                part.maxParticles = (int)Mathf.Lerp(part.maxParticles, particlesl2 , timeElapsedl2 / lerpDuration);
                timeElapsedl2 += Time.deltaTime;
            }

        }
        if(!enter && part.maxParticles > 100)
        {
            part.maxParticles = (int)Mathf.Lerp(part.maxParticles, 100 , timeElapsedonExit / 5);
            timeElapsedonExit += Time.deltaTime;
            
         }
    }

    private void OnTriggerEnter(Collider other)
    {
           
        if (other.tag == "Player")
        {
            enter = true;
        }
     }
    private void OnTriggerExit(Collider other)
    {
           
        if (other.tag == "Player")
        {
            enter = false;
        }

     }
}