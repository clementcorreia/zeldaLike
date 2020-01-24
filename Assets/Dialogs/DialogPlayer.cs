using UnityEngine;

public class DialogPlayer : MonoBehaviour
{

    [SerializeField]
    private Dialogue m_Dialog = null;

    [SerializeField]
    private DialogBox m_DialogBox = null;

    private bool m_DialogOpen = false;

    public void PlayDialog()
    {
        m_DialogBox.DisplayDialog(m_Dialog);
    }

    public void CloseDialog()
    {
        m_DialogBox.CloseDialog();
    }

    public void ToggleDialog()
    {
        if(m_DialogOpen)
        {
            CloseDialog();
        }
        else
        {
            PlayDialog();
        }
        m_DialogOpen = !m_DialogOpen;
    }

}
