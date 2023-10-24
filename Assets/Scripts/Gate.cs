using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    [SerializeField] private TMP_Text m_text;
    private Floppy m_FloppyPlugedIn;

    // Start is called before the first frame update
    void Start()
    {
        m_text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFloppyPluged(Floppy _floppy)
    {
        if(m_FloppyPlugedIn == null)
        {
            m_FloppyPlugedIn = _floppy;
            m_text.enabled = true;
            m_text.text = _floppy.GetFloppyData().m_DiskName;
            _floppy.gameObject.SetActive(false);
        }
    }

    public bool IsHoldingFloppy()
    {
        return m_FloppyPlugedIn == null ? false : true;
    }

    public void ReleaseFloppy()
    {
        if(m_FloppyPlugedIn != null)
        {
            m_FloppyPlugedIn.gameObject.SetActive(true);
            m_text.text = null;
            m_text.enabled = false;
            m_FloppyPlugedIn = null;
        }
    }
}
