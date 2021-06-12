using UnityEngine;
using System.Collections;
 
public class changeimage : MonoBehaviour
{
    public Cubemap cube;
    public string url = "http://i.imgur.com/mkdBN4b.jpg";
    private Color[] imageColors;
    private Texture2D loadedImage;
    public WWW www;
    private int size = 1024;
    public Material skyboxMat;
 
    void Start()
    {
        loadedImage = new Texture2D(size * 12, size, TextureFormat.RGB24, false);
        StartCoroutine(loadImage());
    }
 
    IEnumerator loadImage()
    {
        www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(loadedImage);
 
        cube = new Cubemap(size, TextureFormat.RGB24, false);
        imageColors = loadedImage.GetPixels(0, 0, size, size);
        cube.SetPixels(imageColors, CubemapFace.PositiveX);
        imageColors = loadedImage.GetPixels(size, 0, size, size);
        cube.SetPixels(imageColors, CubemapFace.NegativeX);
        imageColors = loadedImage.GetPixels(size * 2, 0, size, size);
        cube.SetPixels(imageColors, CubemapFace.PositiveY);
        imageColors = loadedImage.GetPixels(size * 3, 0, size, size);
        cube.SetPixels(imageColors, CubemapFace.NegativeY);
        imageColors = loadedImage.GetPixels(size * 4, 0, size, size);
        cube.SetPixels(imageColors, CubemapFace.PositiveZ);
        imageColors = loadedImage.GetPixels(size * 5, 0, size, size);
        cube.SetPixels(imageColors, CubemapFace.NegativeZ);
        cube.Apply();
 
        skyboxMat.SetTexture("_Tex", cube);
        RenderSettings.skybox = skyboxMat;
    }
}