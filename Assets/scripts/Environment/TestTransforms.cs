using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransforms : MonoBehaviour
{

    // Inicializacion
    void Awake()
    {
        // Executed once
        // We cannot be sure, that other awakes are finished
        // Executed if the object is inactive
        Debug.Log(transform.position);
        Debug.Log(transform.eulerAngles);
        Debug.Log(transform.localScale);

        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        Vector3 scl = transform.localScale;

        Vector2 pos2D = new Vector2(2, 5);
        Vector3 pos3D = new Vector3(2, 5, 8);
    }

    void Start()
    {
        // Executed once
        // This is executed after awake has been called.
        // Executed if the component is active
        Debug.Log("Start " + name);
        Debug.LogWarning("Warning test");
        Debug.LogError("Error test");
    }

    // Update is called once per frame
    void Update()
    {
        // Executed every single frame of the game
        // Used for gameplay logic

        Debug.Log(Time.deltaTime);
        transform.eulerAngles += new Vector3(0, 1 , 0) * Time.deltaTime;
        transform.position += new Vector3(0, 0.001f, 0) * Time.deltaTime;
        transform.localScale += new Vector3(0.001f, 0.001f, 0.001f) * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Executed every fixed step
        // Used for physics
    }

    void LateUpdate()
    {
        // Executed every single frame of the game
        // Executed at the end of the frame
        // For camera control
    }

    void UpdateTransform()
    {

    }
}