using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupHandler : MonoBehaviour
{
    public int qtdBirds = 0;
    public GameObject textResetar;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (qtdBirds == 4)
        {
            textResetar.SetActive(true);
        }
    }
}
