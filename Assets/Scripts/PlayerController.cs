using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    private Rigidbody2D m_rb;

    [SerializeField]
    private LayerMask m_WhatIsGround;

    [SerializeField]
    private LayerMask m_WhatIsSpikes;

    [SerializeField]
    private Transform m_GroundCheck;

    [SerializeField]
    private Transform m_AheadCheckPoint;

    [SerializeField]
    private Transform m_BehindCheckPoint;

    [SerializeField]
    private Transform m_BelowCheckPoint;

    [SerializeField]
    private float m_Speed;

    [SerializeField]
    private float m_JumpForce;

    private bool m_Grounded = true;

    const float k_GroundedRadius = .15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;

            }
        }
    }

    public void Walk()
    {
        m_Animator.SetFloat("Speed", m_Speed);
        Vector3 targetPos = transform.position + transform.right * transform.localScale.x;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * m_Speed);
    }

    public void Jump()
    {
        if(m_Grounded)
        {
            m_Animator.SetTrigger("Jump");
            m_rb.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
            m_Grounded = false;
        }
        

    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public bool CheckCondition(string obj, string condition)
    {
        switch (condition)
        {
            case "Ahead":
                {
                    return CheckAhead(obj);
                    break;
                }
            case "Below":
                {
                    return true;
                    break;
                }
            case "Behind":
                {
                    return true;
                    break;
                }
            default:
                return false;
                break;
        }
    }

    public bool CheckAhead(string obj)
    {
        if(obj == "Ground")
        {
            return Physics2D.OverlapCircle(m_AheadCheckPoint.position, k_GroundedRadius, m_WhatIsGround);
        }
        else if(obj == "Spikes")
        {
            return Physics2D.OverlapCircle(m_AheadCheckPoint.position, k_GroundedRadius, m_WhatIsSpikes);
        }
        return false;
    }
}
