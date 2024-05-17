using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaDeCores : MonoBehaviour
{
    // Start is called before the first frame update

    public Color[] cores;

    void Start()
    {
        if (cores.Length == 0)
        {
            Debug.LogWarning("Crie uma ou mais cores na lista.");
        return;        
        }


        Color c = cores[Random.Range(0, cores.Length - 1)];
        GetComponent<Renderer>().material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
