using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CircleStamina : MonoBehaviour
{
    public Image ProgressBar;

    private float maxStamina = 1;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static CircleStamina instance;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        ProgressBar.fillAmount = maxStamina;
    }


    public void UseStamina(float amount){
        if(currentStamina - amount >= 0){
            currentStamina -= amount;
            ProgressBar.fillAmount = currentStamina;

            if(regen != null){
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }else{
            Debug.Log("Acabou a stamina");
        }
    }

    public float getStamina(){
        return currentStamina;
    }

    private IEnumerator RegenStamina(){
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina){
            currentStamina += maxStamina / 100;
            ProgressBar.fillAmount = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
