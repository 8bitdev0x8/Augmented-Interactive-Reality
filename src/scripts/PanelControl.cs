using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PanelControl : MonoBehaviour
{
    public GameObject FrontPanel;
    public GameObject SignInPanel;
    public GameObject LogInPanel;
    public Text infoText;
    
    void Start()
    {

    }


    public void EnableSpanel()
    {
        FrontPanel.SetActive(false);
        SignInPanel.SetActive(true);
    }


    public void EnableLpanel()
    {
        FrontPanel.SetActive(false);
        LogInPanel.SetActive(true);  
    }

    public void back()
    {
        FrontPanel.SetActive(true);
        LogInPanel.SetActive(false);
        SignInPanel.SetActive(false);
        infoText.text = "";
    }

    

    

    

    
}
