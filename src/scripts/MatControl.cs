using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MatControl : MonoBehaviour
{
    public Material mat1;
    public Texture2D texture1;
    public string url = "http://parcusinteractive.com/test/uploads/360img.jpg";
    void Start()
    {
        StartCoroutine(GetTexture());
        RenderSettings.skybox = mat1;
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://firebasestorage.googleapis.com/v0/b/augmented-interactive-re-69a5e.appspot.com/o/360image?alt=media&token=7a29e049-9d1e-49a4-8c1a-60209d6366b5");
        yield return www.SendWebRequest();
        
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                texture1 = ((DownloadHandlerTexture)www.downloadHandler).texture;
                mat1.mainTexture = texture1;
               
            }
            Debug.Log("Testing..");
            
            
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                
                mat1.mainTexture = texture;
               
            }
        }, "Select a 360 image", "image/jpg");

        Debug.Log("Permission result: " + permission);
    }

    private void PickVideo()
    {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            Debug.Log("Video path: " + path);
            if (path != null)
            {
                // Play the selected video
                Handheld.PlayFullScreenMovie("file://" + path);
            }
        }, "Select a video");

        Debug.Log("Permission result: " + permission);
    }

    public void SceneReload()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
