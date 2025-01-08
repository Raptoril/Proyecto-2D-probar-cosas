using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public float damageForce = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Entramos dentro del trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto tiene PlayerHealthController
        PlayerHealthController hCtr = collision.gameObject.GetComponent<PlayerHealthController>();
        if (hCtr != null)
        {
            hCtr.Damage(); // Aplicar daño
        }
        else
        {
            Debug.LogWarning($"El objeto {collision.name} no tiene un componente PlayerHealthController.");
        }

        // Verificar si el objeto tiene Rigidbody2D
        Rigidbody2D cRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (cRigidbody != null)
        {
            cRigidbody.AddForce(Vector2.up * damageForce, ForceMode2D.Impulse); // Aplicar fuerza
        }
        else
        {
            Debug.LogWarning($"El objeto {collision.name} no tiene un componente Rigidbody2D.");
        }

        Debug.Log($"Objeto que colisionó: {collision.name}");
    }
}

