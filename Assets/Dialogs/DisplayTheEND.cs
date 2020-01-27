using UnityEngine;
using UnityEngine.UI;

public class DisplayTheEND : MonoBehaviour
{
	public Button myButton;
    public Image image;
    public Text text;
 
    // Start is called before the first frame update
    void Start()
    {
    	Button btn = myButton.GetComponent<Button>();
    	btn.onClick.AddListener(displayTheEnd);
    }

    void displayTheEnd() {
        image.enabled = !image.enabled;
        text.enabled = !text.enabled;
    }

}
