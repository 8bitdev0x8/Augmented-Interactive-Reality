using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ShareButton : MonoBehaviour
{
    [SerializeField] GameObject share;
    [SerializeField] GameObject close;

    public void ClickShare()
    {
        StartCoroutine( TakeScreenshotAndShare() );
        //share.SetActive(false);
        //close.SetActive(false);
    }

    private IEnumerator TakeScreenshotAndShare()
{
    yield return null;
    share.SetActive(false);
    close.SetActive(false);
    
	yield return new WaitForEndOfFrame();


	Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGBA32, false );
	ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
	ss.Apply();

	string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
	File.WriteAllBytes( filePath, ss.EncodeToPNG() );
    share.SetActive(true);
    close.SetActive(true);

	// To avoid memory leaks
	Destroy( ss );
    

	new NativeShare().AddFile( filePath )
		.SetSubject( "#AIR-APP" ).SetText( "#AIR-APP" )
		//.SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget ) )
		.Share();

}
}
