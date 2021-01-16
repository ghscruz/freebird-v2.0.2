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
    
    public GameObject SystemManager;
    private GroupHandler groupHandler;

    void Awake()
    {
        SystemManager = GameObject.FindGameObjectWithTag("SystemManager");
    }

    void Start()
    {
        groupHandler = SystemManager.transform.Find("GroupManager").GetComponent<GroupHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            volume.weight -= 0.20f;
            groupHandler.qtdBirds += 1;
            ally.SetActive(true);
            soundDestroy.GetComponent<AudioSource>().Play();
            radio.GetComponent<AudioSource>().volume += (0.05F * groupHandler.qtdBirds);
            nature.GetComponent<AudioSource>().volume += (0.1f * groupHandler.qtdBirds);
            trigger.SetActive(false);
        }
    }
}
