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

    private float _movementTile = 15f;

    private System.Nullable<Vector3> _movementDestination;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _floppy = GetComponent<Floppy>();
        _dragController = FindObjectOfType<DragController>();
    }

    private void FixedUpdate()
    {
        if(_movementDestination.HasValue)
        {
            if (IsDragging)
            {
                //_movementDestination = null;
                return;
            }

            if (transform.position == _movementDestination)
            {
                _movementDestination = null;
            }
            else
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
                    }
                    
                    break;
                }
            case FloppyData.FloppyType.Condition:
                {
                    if (collision.CompareTag("BlueGate"))
                    {
                        _movementDestination = collision.transform.position;
                    }
                    
                    break;
                }
            case FloppyData.FloppyType.Statement:
                {
                    if (collision.CompareTag("GreenGate"))
                    {
                        _movementDestination = collision.transform.position;
                    }
                    
                    break;
                }
            default:
                break;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _movementDestination = null;
    }
}
