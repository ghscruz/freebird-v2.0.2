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

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        int stamina = 100;
        float translation = 0.5F * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        float sobe = Input.GetAxis("Vertical") * speedUp;
        float boost = Input.GetAxis("Boost") * speedBoost;

        translation *= Time.deltaTime;
        boost *= Time.deltaTime;
        rotation *= Time.deltaTime;
        sobe *= Time.deltaTime;

    // Debug.Log(staminaBar.instance.getStamina());

        // if(boost > 0 && staminaBar.instance.currentStamina > 15)
        // if(boost > 0)
        if(boost > 0 && staminaBar.instance.getStamina() > 0)
        {
            songBoost.GetComponent<AudioSource>().volume = 1.0F;
            transform.Translate(0, 0, translation + boost);
            staminaBar.instance.UseStamina(1);
        }
        else
        {
            songBoost.GetComponent<AudioSource>().volume = 0.0F;
            transform.Translate(0, 0, translation);
        }
        
        transform.Rotate(sobe, rotation, 0);

        if (rotation > 0)
        {
            transform.Rotate(0, 0, -2f);
        }
        else if (rotation < 0)
        {
            transform.Rotate(0, 0, 2f);
        }
    }
}