using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NewCommandHandler : MonoBehaviour
{
    enum SceneType
    {
        Menu,
        Level
    }
    //[SerializeField]
    //private GameObject m_Player;
    [SerializeField]
    private PlayerController m_playerController;


    [SerializeField]
    private SceneType m_type;

    [SerializeField] private TMP_Text m_AheadObjectText;
    [SerializeField] private TMP_Text m_AheadCommandText;
    [SerializeField] private TMP_Text m_BelowObjectText;
    [SerializeField] private TMP_Text m_BelowCommandText;
    [SerializeField] private TMP_Text m_BehindObjectText;
    [SerializeField] private TMP_Text m_BehindCommandText;

    [SerializeField] private TMP_Text m_ElseCommandText;
    
    private string m_AheadObjectStr;
    private string m_AheadCommandStr;
    private string m_BelowObjectStr;
    private string m_BelowCommandStr;
    private string m_BehindObjectStr;
    private string m_BehindCommandStr;

    private string m_ElseCommandStr;

    // Start is called before the first frame update
    void Start()
    {
        m_AheadObjectStr = "";
        m_BelowObjectStr = "";
        m_BehindObjectStr = "";
        m_AheadCommandStr = "";
        m_BelowCommandStr = "";
        m_BehindCommandStr = "";

        m_ElseCommandStr = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (m_type == SceneType.Menu)
        {
            string nextScene = m_ElseCommandText.text;
            GameObject menuControllerGO = GameObject.FindGameObjectWithTag("MenuController");
            MenuController menuController = menuControllerGO.GetComponent<MenuController>();
            if (nextScene.Contains("Play"))
            {
                menuController.Load("LevelSelection");
            }
            else if (nextScene.Contains("Setting"))
            {
                menuController.Load("Setting");
            }
            else if (nextScene.Contains("Quit"))
            {
                Application.Quit();
            }
            return;

        }

        m_AheadObjectStr = m_AheadObjectText ? m_AheadObjectText.text : null;
        m_BelowObjectStr = m_BelowObjectText ? m_BelowObjectText.text : null;
        m_BehindObjectStr = m_BehindObjectText ? m_BelowObjectText.text : null;
        m_AheadCommandStr = m_AheadCommandText ? m_AheadCommandText.text : null;
        m_BelowCommandStr = m_BelowCommandText ? m_BelowCommandText.text : null;
        m_BehindCommandStr = m_BehindCommandText ? m_BehindCommandText.text : null;
        m_ElseCommandStr = m_ElseCommandText ? m_ElseCommandText.text : null;

        string statement = "";
        bool useIfStatement = false;
        if (m_AheadObjectStr != null &&  m_playerController.CheckCondition(m_AheadObjectStr, "Ahead"))
        {
            useIfStatement = true;
            statement += m_AheadCommandStr;
        }

        if (m_BelowObjectStr != null && m_playerController.CheckCondition(m_BelowObjectStr, "Below"))
        {
            useIfStatement = true;
            statement += m_BelowCommandStr;
        }

        if (m_BehindObjectStr != null && m_playerController.CheckCondition(m_BehindObjectStr, "Behind"))
        {
            useIfStatement = true;
            statement += m_BehindCommandStr;
        }

        if(!useIfStatement)
        {
            statement = m_ElseCommandStr;
        }

        if (statement == null)
        {
            m_playerController.Idle();
            return;
        }
        if (statement.Contains("Walk"))
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

        if (statement.Contains("Flip"))
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
