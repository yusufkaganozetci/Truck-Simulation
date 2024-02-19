using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*if (Input.touchPressureSupported) Debug.Log("Pressure supported");
        else Debug.Log("Pressure not supported");*/
    }

    // Update is called once per frame
    void Update()
    {
        //HandleTouchPressure();
    }

    private void HandleTouchPressure()
    {
        
        
        for (int i=0;i<Input.touchCount;i++)
        {
            Debug.Log(Input.touches[i].pressure);
        }
    }
}
