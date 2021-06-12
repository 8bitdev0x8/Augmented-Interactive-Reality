using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashManager : MonoBehaviour
{
    public Text welcometext;
    void Start()
    {
        welcometext.text = "Welcome " + PlayerPrefs.GetString("name");
    }

    public void Explore360()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
