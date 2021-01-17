using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTrigger : MonoBehaviour
{
    public GameObject ally;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ally.GetComponent<Ally>().enabled = true;
        }
    }
}
