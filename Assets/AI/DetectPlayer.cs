using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    [SerializeField]
    private float m_SightRange = 3f;

    [SerializeField]
    private Transform m_Character = null;

    public bool IsCharacterInRange()
    {
        return Vector3.Distance(m_Character.position, transform.position) <= m_SightRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_SightRange);
    }
}
