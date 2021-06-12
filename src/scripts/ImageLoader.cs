using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    public string url = "URL";
    public Renderer thisRenderer;
    
    

    void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine());
    }
    private IEnumerator LoadFromLikeCoroutine()
    {
        Debug.Log("loading..");
        WWW wwwLoader = new WWW(url);
        yield return wwwLoader;

        Debug.Log("loaded");
        thisRenderer.material.color = Color.white;
        thisRenderer.material.mainTexture = wwwLoader.texture;
    }
}
