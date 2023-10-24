using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;

    public Vector3 LastPosition;

    private Collider2D _collider;

    private DragController _dragController;

    private Floppy _floppy;

    [SerializeField] private GameObject floppyDisplay;

    private float _movementTile = 30f;

    private System.Nullable<Vector3> _movementDestination;

    private GameObject m_gate;
    //private bool isStayInGate;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _floppy = GetComponent<Floppy>();
        _dragController = FindObjectOfType<DragController>();
    }

    private void FixedUpdate()
    {
        if (_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                //_movementDestination = null;
                return;
            }

            if (transform.position == _movementDestination)
            {
                Gate gate = m_gate.GetComponent<Gate>();
                if (gate != null)
                {
                    gate.OnFloppyPluged(_floppy);
                    _movementDestination = null;
                }
                
            }
            else /*if(isStayInGate)*/
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTile * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (_floppy.GetFloppyType())
        {
            case FloppyData.FloppyType.Object:
                {
                    if (collision.CompareTag("RedGate"))
                    {
                        _movementDestination = collision.transform.position;
                        m_gate = collision.gameObject;
                    }
                    
                    break;
                }
            case FloppyData.FloppyType.Condition:
                {
                    if (collision.CompareTag("GreenGate"))
                    {
                        _movementDestination = collision.transform.position;
                        m_gate = collision.gameObject;
                    }
                    
                    break;
                }
            case FloppyData.FloppyType.Statement:
                {
                    if (collision.CompareTag("BlueGate"))
                    {
                        _movementDestination = collision.transform.position;
                        m_gate = collision.gameObject;
                    }
                    
                    break;
                }
            default:
                break;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (_floppy.GetFloppyType())
        {
            case FloppyData.FloppyType.Object:
                {
                    if (collision.CompareTag("RedGate"))
                    {
                        _movementDestination = null;
                        m_gate = null;
                    }

                    break;
                }
            case FloppyData.FloppyType.Condition:
                {
                    if (collision.CompareTag("GreenGate"))
                    {
                        _movementDestination = null;
                        m_gate = null;
                    }

                    break;
                }
            case FloppyData.FloppyType.Statement:
                {
                    if (collision.CompareTag("BlueGate"))
                    {
                        _movementDestination = null;
                        m_gate = null;
                    }

                    break;
                }
            default:
                break;
        }
    }

    public void InitDrag()
    {
        Vector2 floppyDisplayPos = floppyDisplay.transform.position;
        floppyDisplay.transform.position = new Vector3(floppyDisplayPos.x, floppyDisplayPos.y + 0.1f, 0f) ;
    }

    //[tmp]
    public void Drag()
    {
        Vector2 floppyDisplayPos = floppyDisplay.transform.position;
        floppyDisplay.transform.position = new Vector3(floppyDisplayPos.x, floppyDisplayPos.y, 0f);
    }

    public void Drop()
    {
        Vector2 floppyDisplayPos = floppyDisplay.transform.position;
        floppyDisplay.transform.position = new Vector3(floppyDisplayPos.x, floppyDisplayPos.y - 0.1f, 0f);
    }


    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    isStayInGate = true;
    //}
}
