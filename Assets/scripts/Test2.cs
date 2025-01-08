using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void Awake()
    {
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
        Test2 test = gameObject.GetComponent<Test2>();

        Debug.Log(render);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
