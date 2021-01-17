using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class staminaBar : MonoBehaviour
{
    public Slider StaminaBar;

    private int maxStamina = 100;
    private int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static staminaBar instance;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        StaminaBar.maxValue = maxStamina;
        StaminaBar.value = maxStamina;
    }


    public void UseStamina(int amount){
        if(currentStamina - amount >= 0){
            currentStamina -= amount;
            StaminaBar.value = currentStamina;

            if(regen != null){
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }else{
            Debug.Log("Acabou a stamina");
        }
    }

    public int getStamina(){
        return currentStamina;
    }

    private IEnumerator RegenStamina(){
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina){
            currentStamina += maxStamina / 100;
            StaminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }
}
