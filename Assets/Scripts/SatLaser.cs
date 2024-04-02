using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SatLaser : MonoBehaviour
{
    public Color laserColor;
    public Color activeLaserColor;
    GameObject goalInFocus;
    int goalsRemaining;

    public TMP_Text goalsLeftText;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        SetLaserColor(laserColor);
        goalsRemaining = GameObject.FindGameObjectsWithTag("Goal").Length;
        goalsLeftText.text = "Goals left: " + goalsRemaining.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakePicture();
        }
    }

    void TakePicture()
    {
        SetLaserColor(activeLaserColor);
        StartCoroutine(ResetColor());
        PlayShutterSound();

        if (goalInFocus != null)
        {
            Destroy(goalInFocus);
            goalInFocus = null;

            goalsRemaining--;
            goalsLeftText.text = "Goals left: " + goalsRemaining.ToString();

            if (goalsRemaining == 0)
            {
                FindObjectOfType<Rotator>().enabled = false;

                winPanel.SetActive(true);
                this.enabled = false;
            }
        }
    }

    void SetLaserColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.25f);
        SetLaserColor(laserColor);
    }

    void PlayShutterSound()
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            goalInFocus = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == goalInFocus)
        {
            goalInFocus = null;
        }
    }
}
