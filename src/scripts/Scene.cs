using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene : MonoBehaviour
{
    
    public void SigninPage()
    {
         SceneManager.LoadScene(0);

    }

    public void Dashboard()
    {
         SceneManager.LoadScene(1);
    }

    public void AIR()
    {
         SceneManager.LoadScene(2);
    }

    public void RenderViewer()
    {
         SceneManager.LoadScene(3);
    }


}
