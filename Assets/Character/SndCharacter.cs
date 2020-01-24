using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SndCharacter : MonoBehaviour
{

    public float m_detectionRange = 3f;
    public LayerMask m_PlayerDetection;
    private GameObject[] m_Players = null;
    private bool m_PlayerInRange = false;
    private bool m_BubbleOpen = false;
    private Animator m_Animator = null;
    private AudioSource m_AudioData;
    private DialogPlayer m_DialogPlayer = null;

    private void Start()
    {
        m_AudioData = GetComponent<AudioSource>();
        m_DialogPlayer = GetComponent<DialogPlayer>();
    }

    void Awake()
    {
        m_Players = GameObject.FindGameObjectsWithTag("Player");
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        if(m_PlayerInRange)
        {
            m_Animator.SetBool("isAwake", true);
            if (m_DialogPlayer && Input.GetKeyDown(KeyCode.Space))
            {
                m_BubbleOpen = !m_BubbleOpen;
                if (m_DialogPlayer) 
                {
                    m_AudioData.Play(0);
                }
                if(m_BubbleOpen)
                {
                    m_DialogPlayer.PlayDialog();
                }
                else
                {
                    m_DialogPlayer.CloseDialog();
                }
            }
        }
        else
        {
            m_Animator.SetBool("isAwake", false);
            m_BubbleOpen = false;
            m_DialogPlayer.CloseDialog();
        }
    }

    public void DetectPlayer()
    {
        m_PlayerInRange = false;
        if (m_Players.Length > 0)
        {
            Vector3 toPlayer = m_Players[0].transform.position - transform.position;
            if (toPlayer.sqrMagnitude < m_detectionRange)
            {
                m_PlayerInRange = true;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, m_detectionRange / 2);
    }
}
