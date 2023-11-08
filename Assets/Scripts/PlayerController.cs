using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator m_Animator;

    [SerializeField]
    public Rigidbody2D m_rb;

    [SerializeField]
    private ParticleController m_particleController;

    [SerializeField]
    private LayerMask m_WhatIsGround;

    [SerializeField]
    private LayerMask m_WhatIsTrap;

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

    const float k_GroundedRadius = .01f;
    const float k_CheckPointRadius = .15f;

    public float deltaMovement = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //m_Animator.SetFloat("Velocity", m_rb.velocity.y);
        m_Animator.SetBool("isJumping", !m_Grounded);
    }

    private void FixedUpdate()
    {

        bool wasGround = m_Grounded;
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if(!wasGround)
                {
                    m_Animator.SetTrigger("Land");
                    m_particleController.PlayLandingEffect();
                }
            }
        }
    }

    public void Walk()
    {
        m_Animator.SetFloat("Speed", m_Speed);
        Vector3 targetPos = transform.position + transform.right * transform.localScale.x;
        deltaMovement = transform.localScale.x;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * m_Speed);
 
    }

    public void Idle()
    {
        deltaMovement = 0f;
        m_Animator.SetFloat("Speed", 0f);
    }

    public void Jump()
    {
        if(m_Grounded)
        {
            m_particleController.PlayLandingEffect();
            Debug.Log("Jump");
            m_Animator.SetTrigger("TakeOf");
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
                    return CheckBelow(obj);
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
            return Physics2D.OverlapCircle(m_AheadCheckPoint.position, k_CheckPointRadius, m_WhatIsGround);
        }
        else if(obj == "Trap")
        {
            return Physics2D.OverlapCircle(m_AheadCheckPoint.position, k_CheckPointRadius, m_WhatIsTrap);
        }
        return false;
    }

    public bool CheckBelow(string obj)
    {
        if (obj == "Ground")
        {
            return Physics2D.OverlapCircle(m_GroundCheck.position, k_CheckPointRadius, m_WhatIsGround);
        }
        else if (obj == "Trap")
        {
            return Physics2D.OverlapCircle(m_GroundCheck.position, k_CheckPointRadius, m_WhatIsTrap);
        }
        return false;
    } 
    
    public bool IsJumping()
    {
        return !m_Grounded || m_rb.velocity.y > 0f;
    }
}
