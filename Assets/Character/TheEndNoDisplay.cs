using UnityEngine;
using UnityEngine.UI;

public class TheEndNoDisplay : MonoBehaviour
{
	public Image image;
	public Text text;
 
    // Start is called before the first frame update
    void Start()
    {
        // Turns the image off.
        image.enabled = false;
        text.enabled = false;
    }
}
