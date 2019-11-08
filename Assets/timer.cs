using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float waitTime = 5f;
    public float playtime = 10f;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= 1 * Time.deltaTime;
        if (waitTime <= 0)
        {
            playtime -= 1 * Time.deltaTime;
            waitTime = 0;
            if (playtime <= 0)
                playtime = 0;
        }
    }
}
