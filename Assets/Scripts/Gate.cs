using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Gate : MonoBehaviour, IPointerClickHandler
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
            AudioManager.Instance.PlaySFX("Insert");
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(IsHoldingFloppy())
        {
            ReleaseFloppy();
            AudioManager.Instance.PlaySFX("Pickup");
        }
    }
}
