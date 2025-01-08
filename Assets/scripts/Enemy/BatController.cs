using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float speed = 4f;
    public float AITick = 1f;

    public Rigidbody2D cRigidbody;
    public SpriteRenderer cRenderer;
    public Seeker cSeeker;
    public Transform player;

    private Path path;
    private int currentPoint;
    public Transform[] waypoints;
    public float detDistance = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdatePath", 0f, AITick); //
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;   
            currentPoint = 0;
        }
    }

    void UpdatePath()
    {
        cSeeker.StartPath(cRigidbody.position, player.position, OnPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //solucion profe
        Vector3 dirPlayer = player.position-transform.position;
       

        if (dirPlayer.magnitude < 5f)
        {
            if (path != null)
            {
                Vector3 dir = path.vectorPath[currentPoint] - transform.position;

                cRigidbody.velocity = dir.normalized * speed;


                if (dir.magnitude < 0.01 && currentPoint < path.vectorPath.Count)
                {
                    currentPoint = currentPoint + 1;
                }
            }
        }

        //idea de chat (no lo voy a negar muy God la idea)
        /*
        float distancia = Vector2.Distance(transform.position, player.position);
        if (distancia < detDistance)
        {
            Vector3 dir = path.vectorPath[currentPoint] - transform.position;

            cRigidbody.velocity = dir.normalized * speed;


            if (dir.magnitude < 0.01 && currentPoint < path.vectorPath.Count)
            {
                currentPoint = currentPoint + 1;
            }
        }
        */
        //intente hacer que patrullara pero ni idea/ son las 23 y tengo sueño (me he despertado a las 3 hoy)
        /*
        else
        {
            Vector3 dir = waypoints[currentPoint].position - transform.position;
            dir.y = 0;

            // Bucle de la patrol
            if (dir.magnitude < 0.1f)
            {
                currentPoint = (currentPoint + 1) % waypoints.Length;
                Debug.Log("He llegado al waypoint");
            }

            cRigidbody.velocity = new Vector2(dir.normalized.x * speed, cRigidbody.velocity.y);
        }
        */
        



        // If enemy in range, we look for the player
        // Otherwise we return to our origin point

        //codigo del monstruo pegado a ver si funcionaba (pd no funciona solo pegandolo ni moviendolo un poco)
        /*
        Vector3 playerDir = player.transform.position - transform.position; //Posicion jugador - posicion enemigo


        if (playerDir.magnitude < detDistance && playerDir.x > 0) // El jugador esta dentro del rango y lo estoy viendo
        {
            Debug.Log("El enemigo persige al jugador");

            cRigidbody.velocity = new Vector2(playerDir.normalized.x * speed, cRigidbody.velocity.y);
        }

        if (playerDir.magnitude < detDistance && playerDir.x > 0) // El jugador esta dentro del rango y lo estoy viendo
        {
            Debug.Log("El enemigo persige al jugador");

            cRigidbody.velocity = new Vector2(playerDir.normalized.x * speed, cRigidbody.velocity.y);
        }
        */
        //testeando el path != null, si quito el ! no se mueve el murcielago (no se porque)
        /*
        if (path == null)
        {

            Vector3 dir = path.vectorPath[currentPoint] - transform.position;

            cRigidbody.velocity = dir.normalized * speed;


            if (dir.magnitude < 0.01 && currentPoint < path.vectorPath.Count)
            {
                currentPoint = currentPoint + 1;
            }
        }
        */



        //Codigo base sin modificar
        /*
        else if (path != null)
        {

            Vector3 dir = path.vectorPath[currentPoint] - transform.position;

            cRigidbody.velocity = dir.normalized * speed;


            if (dir.magnitude < 0.01 && currentPoint < path.vectorPath.Count)
            {
                currentPoint = currentPoint + 1;
            }
        }
        */
    }
}
