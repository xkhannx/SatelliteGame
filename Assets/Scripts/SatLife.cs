using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatLife : MonoBehaviour
{
    public GameObject lossPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<Rotator>().enabled = false;

            lossPanel.SetActive(true);

            Destroy(transform.parent.gameObject);
        }
    }
}
