using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    public void gyro ()
    {
        button.SetActive(false);
        button2.SetActive(true);
        Camera.main.GetComponent<mouse>().enabled = false;
        Camera.main.GetComponent<GyroControl>().enabled = true;
    }

    public void touch ()
    {
        Camera.main.GetComponent<GyroControl>().enabled = false;
        Camera.main.GetComponent<mouse>().enabled = true;
        button.SetActive(true);
        button2.SetActive(false);

    }

}