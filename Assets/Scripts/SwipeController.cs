using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SwipeController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public static SwipeController instance;
    public Transform trejectoryPos;
    public Transform character;

    [Range(0.05f, 0.15f)] public float SwipeSensitivity;
    private Vector3 firstTouchPos;
    private Vector3 dragPos;
    public bool SwipedDown, SwipedUp;

    private void Awake()
    {
        instance = this;
    }
    private void CheckMovement()
    {
        //if (Defines.IS_GAMEFINISH) return;
        Vector3 distanceVal = dragPos - firstTouchPos;

        if (Vector3.Distance(firstTouchPos, dragPos) >= 1f)
        {
            firstTouchPos = dragPos;

            if (Mathf.Abs(distanceVal.x) >= Mathf.Abs(distanceVal.y)) // HORIZONTAL MOVEMENT
            {
                Vector3 pos = new Vector3(character.eulerAngles.x, character.eulerAngles.y, character.eulerAngles.z);
                pos += Vector3.up * distanceVal.x * SwipeSensitivity;
                character.eulerAngles = pos;
            }
            else // VERTİCAL MOVEMENT
            {
                Vector3 pos = new Vector3(trejectoryPos.eulerAngles.x, trejectoryPos.eulerAngles.y, trejectoryPos.eulerAngles.z);
                pos += Vector3.left * distanceVal.y * SwipeSensitivity;
                trejectoryPos.eulerAngles = pos;
            }
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        firstTouchPos = data.position;
        SwipedDown = false;
    }

    public void OnDrag(PointerEventData data)
    {
        dragPos = data.position;
        if (SwipedDown)
        {
            firstTouchPos = data.position;
            return;
        }
        CheckMovement();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        SwipedUp = false;
    }
}