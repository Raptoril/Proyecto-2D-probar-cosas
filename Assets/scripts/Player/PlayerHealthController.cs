using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Count the number of lives of the player
public class PlayerHealthController : MonoBehaviour
{
    public int maxLives = 5; // Initial live number.
    public int lives; // Live number

    public float dmgDelay = 0.5f;

    private UIHealth UIHealth;

    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
        UIHealth = FindObjectOfType<UIHealth>(); // Conseguir UIHealth de la escena
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        if(lives > 0)
            lives = lives - 1;

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", true);
        StartCoroutine(HurtDelay());

        UIHealth.UpdateHealth(lives);

        PlayerAudioController hAudio = gameObject.GetComponent<PlayerAudioController>();
        hAudio.Damage();

        Debug.Log("The player has taken damage.");
    }

    IEnumerator HurtDelay()
    {
        yield return new WaitForSeconds(dmgDelay);

        PlayerController hCtr = gameObject.GetComponent<PlayerController>();
        hCtr.cAnimator.SetBool("Hurt", false);
    }

    public void Regenerate()
    {
        lives = lives + 1;
        UIHealth.UpdateHealth(lives);

        Debug.Log("The player has gained one hp.");
    }
}
