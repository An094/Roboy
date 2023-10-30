using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Floppy : MonoBehaviour
{
    [SerializeField] private FloppyData m_data;

    [SerializeField] private TMP_Text m_text;

    private DraggableFloppy m_draggableFloppy;

    private void Awake()
    {
        m_draggableFloppy = GetComponent<DraggableFloppy>();
    }

    void Start()
    {
        m_text.text = m_data.name;
    }

    // Update is called once per frame
    public FloppyData.FloppyType GetFloppyType()
    {
        return m_data.m_Type;
    }

    public FloppyData GetFloppyData()
    {
        return m_data;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (m_data.m_Type)
        {
            case FloppyData.FloppyType.Object:
                {
                    if (collision.CompareTag("RedGate") || collision.CompareTag("MenuGate"))
                    {
                        m_draggableFloppy.m_gate = collision.gameObject;
                    }

                    break;
                }
            case FloppyData.FloppyType.Condition:
                {
                    if (collision.CompareTag("GreenGate") || collision.CompareTag("MenuGate"))
                    {
                        m_draggableFloppy.m_gate = collision.gameObject;
                    }

                    break;
                }
            case FloppyData.FloppyType.Statement:
                {
                    if (collision.CompareTag("BlueGate") || collision.CompareTag("MenuGate"))
                    {
                        m_draggableFloppy.m_gate = collision.gameObject;
                    }

                    break;
                }
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (m_data.m_Type)
        {
            case FloppyData.FloppyType.Object:
                {
                    if (collision.CompareTag("RedGate") || collision.CompareTag("MenuGate"))
                    {
                        m_draggableFloppy.m_gate = null;
                    }

                    break;
                }
            case FloppyData.FloppyType.Condition:
                {
                    if (collision.CompareTag("GreenGate") || collision.CompareTag("MenuGate"))
                    {
                        m_draggableFloppy.m_gate = null;
                    }

                    break;
                }
            case FloppyData.FloppyType.Statement:
                {
                    if (collision.CompareTag("BlueGate") || collision.CompareTag("MenuGate"))
                    {
                        m_draggableFloppy.m_gate = null;
                    }

                    break;
                }
            default:
                break;
        }
    }
}
