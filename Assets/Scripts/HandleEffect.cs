using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HandleEffect : MonoBehaviour
{
    public PostProcessVolume volume;
    public GameObject player;
    public GameObject ally;
    public GameObject radio;
    public GameObject nature;
    public GameObject trigger;
    public GameObject soundDestroy;
    private flight birds;

    void Start()
    {
        birds = player.GetComponent<flight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            volume.weight -= 0.20f;
            birds.qtdBirds += 1;
            ally.SetActive(true);
            soundDestroy.GetComponent<AudioSource>().Play();
            radio.GetComponent<AudioSource>().volume += (0.05F * birds.qtdBirds);
            nature.GetComponent<AudioSource>().volume += (0.1f * birds.qtdBirds);
            trigger.SetActive(false);
        }
    }
}
