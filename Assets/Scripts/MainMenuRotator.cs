using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRotator : MonoBehaviour
{
    [SerializeField]float speed = 10f;
    float angle = 0;
    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.localEulerAngles = Vector3.up * angle;
    }
}
