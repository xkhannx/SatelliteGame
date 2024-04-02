using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float angAcc = 10f;
    float rotateSpeedHor = 5f;
    float rotateSpeedVer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateSpeedHor -= angAcc * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        rotateSpeedVer += angAcc * Time.deltaTime * Input.GetAxisRaw("Vertical");

        transform.Rotate(Camera.main.transform.up, rotateSpeedHor * Time.deltaTime, Space.World);
        transform.Rotate(Camera.main.transform.right, rotateSpeedVer * Time.deltaTime, Space.World);
    }
}
