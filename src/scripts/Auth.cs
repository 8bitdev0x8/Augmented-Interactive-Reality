using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auth : MonoBehaviour
{
  public GameObject WelcomePanel;
  public GameObject signinPanel;
  

  public void OpenPanel()
  {
    WelcomePanel.SetActive(false);
    signinPanel.SetActive(true);
      
  }

  public void Back()
  {
    WelcomePanel.SetActive(true);
    signinPanel.SetActive(false);
  }

  public void signIN()
  {
      SceneManager.LoadScene(1);
  }

  public void airlg()
  {
      SceneManager.LoadScene(3);
  }

}
