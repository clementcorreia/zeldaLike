using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float m_SpeedWalk = 1f;
    [SerializeField]
    private float m_SpeedRun = 3f;
    private float m_SpeedCurrent;

    private float m_DetectionRange = 1f;

    private Animator m_Animator = null;
    private bool m_IsWalking = false;
    private string m_direction = "down";

    private void Awake()
    {
        m_SpeedCurrent = m_SpeedWalk;
        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_Animator.SetTrigger("Down");
            m_direction = "down";
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Animator.SetTrigger("Up");
            m_direction = "up";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_Animator.SetTrigger("Left");
            m_direction = "left";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_Animator.SetTrigger("Right");
            m_direction = "right";
        }

        if (Input.GetKey(KeyCode.R))
        {
            m_SpeedCurrent = m_SpeedRun;
        }
        else
        {
            m_SpeedCurrent = m_SpeedWalk;
        }

        m_IsWalking = true;
        if (Input.GetKey(KeyCode.DownArrow)) { }
        else if (Input.GetKey(KeyCode.UpArrow)) { }
        else if (Input.GetKey(KeyCode.LeftArrow)) { }
        else if (Input.GetKey(KeyCode.RightArrow)) { }
        else
        {
            m_IsWalking = false;
        }
        m_Animator.SetBool("isWalking", m_IsWalking);

        Vector3 movement = Vector3.zero;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        transform.position += movement * m_SpeedCurrent * Time.deltaTime;

        DetectPnj();
    }

    public bool DetectPnj()
    {
        RaycastHit2D hitInfo;

        float x = transform.position.x;
        float y = transform.position.y;
        Vector2 direction;
        switch(m_direction)
        {
            case "up":
                direction = new Vector2(x, y + 2*m_DetectionRange);
                break;
            case "left":
                direction = new Vector2(x - 2*m_DetectionRange, y);
                break;
            case "right":
                direction = new Vector2(x + 2*m_DetectionRange, y);
                break;
            default:
                direction = new Vector2(x, y - 2*m_DetectionRange);
                break;
        }

        hitInfo = Physics2D.Raycast(new Vector2(x, y), direction, Mathf.Infinity);
        if(hitInfo)
        {
            if (hitInfo.collider.name == "SndCharacter")
            {
                Debug.Log("Raycast hit" + hitInfo.collider.name);
                return true;
            }
            return false;
        }
        return false;
    }

}
