using UnityEngine;

public class blink3DText : MonoBehaviour {
    
    public float duration = 1.0F;

    /// <summary>
    /// initial color
    /// </summary>
    public Color color0 = Color.red;
    /// <summary>
    /// blinking color
    /// </summary>
    public Color color1 = Color.blue;
    
    
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        
        //blink the color of the text:
        GetComponent<TextMesh>().color = Color.Lerp(color0, color1, t);
    }
}
