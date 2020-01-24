using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [SerializeField]
    private Image m_CharacterAvatar = null;

    [SerializeField]
    private Text m_Text = null;

    private void Awake()
    {
        CloseDialog();
    }

    public void DisplayDialog(Dialogue _Dialog)
    {
        m_CharacterAvatar.sprite = _Dialog.GetSpeakerAvatar();
        m_Text.text = _Dialog.GetText();
        gameObject.SetActive(true);
    }

    public void CloseDialog()
    {
        gameObject.SetActive(false);
    }

}
