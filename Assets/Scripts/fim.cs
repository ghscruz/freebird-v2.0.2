using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fim : MonoBehaviour
{
    public GameObject camera;
    public GameObject target;
    public GameObject bird;
    public GameObject canvasMensagem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("sceneFim");
        }
     }
}
