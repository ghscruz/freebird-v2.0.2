
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class flight : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float speedUp;
    public float speedBoost;
    public GameObject songBoost;
    public int qtdBirds = 0;
    public GameObject resetar;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float translation = 0.5F * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float sobe = Input.GetAxis("Vertical") * speedUp;
        float boost = Input.GetAxis("Boost") * speedBoost;

        translation *= Time.deltaTime;
        boost *= Time.deltaTime;
        rotation *= Time.deltaTime;
        sobe *= Time.deltaTime;

        if(boost > 0 && CircleStamina.instance.getStamina() > 0.01f)
        {
            songBoost.GetComponent<AudioSource>().volume = 1.0F;
            transform.Translate(0, 0, translation + boost);
            CircleStamina.instance.UseStamina(0.01f);
        }
        else
        {
            songBoost.GetComponent<AudioSource>().volume = 0.0F;
            transform.Translate(0, 0, translation);
        }
        
        transform.Rotate(sobe, 0, rotation);

        if (rotation > 0)
        {
            transform.Rotate(0, 0, -4f);
        }
        else if (rotation < 0)
        {
            transform.Rotate(0, 0, 4f);
        }

        if(qtdBirds == 4)
        {
            resetar.SetActive(true); 
        }
    }
}