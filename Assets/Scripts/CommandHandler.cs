using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class CommandHandler : MonoBehaviour
{
    enum SceneType
    {
        Menu,
        Level
    }
    [SerializeField]
    private GameObject m_Player;

    [SerializeField]
    private SceneType m_type;

    [SerializeField] private TMP_Text m_ObjectText1;
    [SerializeField] private TMP_Text m_ConditionText1;
    [SerializeField] private TMP_Text m_StatementText1;

    [SerializeField] private TMP_Text m_ObjectText2;
    [SerializeField] private TMP_Text m_ConditionText2;
    [SerializeField] private TMP_Text m_StatementText2;

    [SerializeField] private TMP_Text m_StatementText3;



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
        m_Object1 = "";
        m_Condition1 = "";
        m_Statement1 = "";

        m_Object2 = "";
        m_Condition2 = "";
        m_Statement2 = "";

        m_Statement3 = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(m_type == SceneType.Menu)
        {
            string nextScene = m_StatementText3.text;
            GameObject menuControllerGO = GameObject.FindGameObjectWithTag("MenuController");
            MenuController menuController = menuControllerGO.GetComponent<MenuController>();
            if (nextScene.Contains("Play"))
            {
                menuController.Load("LevelSelection");
            }
            else if(nextScene.Contains("Quit"))
            {
                Application.Quit();
            }
            return;

        }

        m_Object1 = m_ObjectText1 == null? null : m_ObjectText1.text;
        m_Condition1 = m_ConditionText1 == null? null : m_ConditionText1.text;
        m_Statement1 = m_StatementText1 == null? null : m_StatementText1.text;

        m_Object2 = m_ObjectText2 == null? null : m_ObjectText2.text;
        m_Condition2 = m_ConditionText2 == null? null : m_ConditionText2.text;
        m_Statement2 = m_StatementText2 == null? null : m_StatementText2.text;

        m_Statement3 = m_StatementText3 == null? null : m_StatementText3.text;

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

        if (statement == null)
        {
            m_playerController.Idle();
            return;
        }
        if(statement.Contains("Walk"))
        {
            m_playerController.Walk();
        }
        else
        {
            m_playerController.Idle();
        }

        if (statement.Contains("Jump") && !m_playerController.IsJumping())
        {
            m_playerController.Jump();
        }

        if(statement.Contains("Flip"))
        {
            m_playerController.Flip();
        }

        if (statement.Contains("Crouch") && !m_playerController.IsCrouch)
        {
            StartCoroutine(m_playerController.Crouch());
            Debug.Log("Crouch");
        }

    }
}
