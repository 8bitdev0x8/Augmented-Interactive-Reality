using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginReg : MonoBehaviour
{
    public InputField LoginUsername;
    public InputField LoginPassword;
    public InputField RegUsername;
    public InputField RegPassword1;
    public InputField RegPassword2;
    public Text infotext;
    string id;
  

    public void LoginClick()
    {
        StartCoroutine(Login(LoginUsername.text, LoginPassword.text));
    }

    IEnumerator Login(string uname, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", uname);
        form.AddField("loginPass", pass);

        using (UnityWebRequest www = UnityWebRequest.Post("http://parcusinteractive.com/test/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
                
                //Debug.Log(www.downloadHandler.text);
                infotext.text = www.downloadHandler.text;
                if(www.downloadHandler.text == "success")
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                }
            }
        }
    }

    public void RegClick()
    {
        

        if (RegPassword1.text != RegPassword2.text)
        {
            infotext.text = "Password does not match!";
            return;
        }
                        
        StartCoroutine(RegisterUser(RegUsername.text, RegPassword1.text));
    }

    IEnumerator RegisterUser(string uname, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("regUser", uname);
        form.AddField("regPass", pass);

        using (UnityWebRequest www = UnityWebRequest.Post("http://parcusinteractive.com/test/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");

                Debug.Log(www.downloadHandler.text);
                infotext.text = www.downloadHandler.text;
               
                if (www.downloadHandler.text == "done")
                {
                    //PlayerPrefs.SetInt("logged", 1);
                    PlayerPrefs.SetString("name", uname);
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                }
            }
        }
    }





    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
           
            int page = pages.Length - 1;
            Debug.Log("pages: " + pages[4] + " length-1: " + page);

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
            id = " " + webRequest.downloadHandler.text;
            //Debug.Log(id);
        }
        
    }
}
