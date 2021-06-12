using UnityEngine;
using UnityEngine.UI;

public class ContentBehaviour : MonoBehaviour
{
    private Slider RotateSlider;
    
    public float RotMin;
    public float RotMax;

    bool rotatestatus = true;
    
    void SliderUpdate(float value)
    {
        if (rotatestatus == true)
            {
        transform.localEulerAngles = new Vector3(transform.rotation.x, value , transform.rotation.z );
            }
    }

    public void RemoveButtonDown()
    {
        Destroy(gameObject);
    }
   
   public void rotateobject()
    {
        
            rotatestatus = true;
            RotateSlider = GameObject.Find("SliderRotation").GetComponent<Slider>();
            RotateSlider.minValue = RotMin;
            RotateSlider.maxValue = RotMax;
            if (rotatestatus == true)
            {
            RotateSlider.onValueChanged.AddListener(SliderUpdate);
            }

        
    }

    
    
}
