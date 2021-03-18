using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int tapCount;

    public void TapCounting()
    {
        tapCount++;
    }
    void Start()
    {
        tapCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
