using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField]
    private Transform m_FollowedObject = null;

    [SerializeField]
    private float m_Speed = 3;

    [SerializeField]
    private float m_ArrivalDistance = 0.5f;

    public void UpdateFollow()
    {
        //Vector3 direction = m_FollowedObject.position - transform.position;
        //direction.Normalize();
        if(Vector3.Distance(transform.position, m_FollowedObject.position) > m_ArrivalDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                m_FollowedObject.position, 
                m_Speed * Time.deltaTime
            );
        }
    }

}
