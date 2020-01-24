using UnityEngine;

// Ajoute un menu dans unity pour créer un asset de type Dialogue
[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
    [SerializeField, TextArea]
    private string m_Text = string.Empty;

    [SerializeField]
    private Sprite m_SpeakerAvatar = null;

    public string GetText()
    {
        return m_Text;
    }

    public Sprite GetSpeakerAvatar()
    {
        return m_SpeakerAvatar;
    }

}
