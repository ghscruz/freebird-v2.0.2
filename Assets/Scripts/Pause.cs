using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject canvasPause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                canvasPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                canvasPause.SetActive(false);
            }
        }
    }
}
