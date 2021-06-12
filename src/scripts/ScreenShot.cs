using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    [SerializeField] MediaPlayer mediaPlayer;
    bool takePicture;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (takePicture)
        {
            takePicture = false;
            var tempRend = RenderTexture.GetTemporary(source.width, source.height);
            Graphics.Blit(source, tempRend);

            Texture2D tempText = new Texture2D(source.width, source.height, TextureFormat.RGBA32, false);
            Rect rect = new Rect(0, 0, source.width, source.height);
            tempText.ReadPixels(rect, 0, 0, false);
            tempText.Apply();
            mediaPlayer.OpenScreen(tempText);
            RenderTexture.ReleaseTemporary(tempRend);
        }
        Graphics.Blit(source, destination);
    }

    public void TakeScreenShot()
    {
        takePicture = true;
    }
}
