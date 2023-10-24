using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    private bool _isDragActive = false;

    private Vector2 _screenPosition;

    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_isDragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                Drop();
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);


        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                    return;
                }
                else
                {
                    draggable = hit.transform.gameObject.GetComponentInParent<Draggable>();
                    {
                        if(draggable != null)
                        {
                            _lastDragged = draggable;
                            InitDrag();
                            return;
                        }
                    }
                }

                Gate gate = hit.transform.gameObject.GetComponent<Gate>();
                if(gate != null)
                {
                    if(gate.IsHoldingFloppy())
                    {
                        Debug.Log("Gate");
                        gate.ReleaseFloppy();
                    }
                   
                }
            }
        }
    }

    void InitDrag()
    {
        _lastDragged.InitDrag();
        _lastDragged.LastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
    }

    void Drag()
    {
        _lastDragged.Drag();
        _lastDragged.transform.position = new Vector3(_worldPosition.x, _worldPosition.y, 0f);
    }

    void Drop()
    {
        _lastDragged.Drop();
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool isDragging)
    {
        _isDragActive = _lastDragged.IsDragging = isDragging;
    }
}
