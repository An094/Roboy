using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableFloppy : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    Transform parentAfterDrag;

    [SerializeField] private Transform m_floppyDisplay;

    [HideInInspector]
    public GameObject m_gate;
    //{
    //    get { return m_gate; }
    //    set
    //    {
    //        if (value != null)
    //        {
    //            Gate gate = value.GetComponent<Gate>();
    //            if (gate != null)
    //            {
    //                gate.OnFloppyPluged(m_floppy);
    //            }
    //        }
    //    }
    //}
    private Floppy m_floppy;

    private void Awake()
    {
        m_floppy = GetComponent<Floppy>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        //m_floppyDisplay.position = new Vector2(transform.position.x, transform.position.y + 25);
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = Input.mousePosition;
        }
        else if (Input.touchCount > 0)
        {
            transform.position = Input.GetTouch(0).position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        //m_floppyDisplay.position = new Vector2(transform.position.x, transform.position.y);
        if (m_gate != null)
        {
            Gate gate = m_gate.GetComponent<Gate>();
            if(gate != null)
            {
                gate.OnFloppyPluged(m_floppy);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_floppyDisplay.position = new Vector2(transform.position.x, transform.position.y + 25);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_floppyDisplay.position = new Vector2(transform.position.x, transform.position.y);
    }
}
