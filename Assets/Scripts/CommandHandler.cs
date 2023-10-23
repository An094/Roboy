using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandHandler : MonoBehaviour
{
    private string m_Command;
    [SerializeField]
    private GameObject m_Player;

    private PlayerController m_playerController;

    private string m_Object1;
    private string m_Condition1;
    private string m_Statement1;

    private string m_Object2;
    private string m_Condition2;
    private string m_Statement2;
    
    private string m_Statement3;
    

    private void Awake()
    {
        m_playerController = m_Player.GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //m_Command = "Jump";
        m_Object1 = "Ground";
        m_Condition1 = "Ahead";
        m_Statement1 = "Jump";

        m_Object2 = "Spikes";
        m_Condition2 = "Below";
        m_Statement2 = "Jump";

        m_Statement3 = "Walk";
        //m_Statement3 = "";
    }

    // Update is called once per frame
    void Update()
    {
        string statement = null;
        if(m_Object1 != null && m_Condition1 != null && m_playerController.CheckCondition(m_Object1, m_Condition1))
        {
            statement = m_Statement1;
        }
        else if(m_Object2 != null && m_Condition2 != null && m_playerController.CheckCondition(m_Object2, m_Condition2))
        {
            statement = m_Statement2;
        }
        else
        {
            statement = m_Statement3;
        }

        if(statement.Contains("Walk"))
        {
            m_playerController.Walk();
        }

        if (statement.Contains("Jump") && !m_playerController.IsJumping())
        {
            m_playerController.Jump();
        }

        if(statement.Contains("Flip"))
        {
            m_playerController.Flip();
        }
    }
}
