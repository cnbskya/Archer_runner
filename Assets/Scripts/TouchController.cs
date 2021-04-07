using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static TouchController Instance;

    [SerializeField] Transform runn_e;
    [SerializeField] Transform minClampTr, maxClampTr;
    public GameObject character;
    public GameObject slideBow;

    [SerializeField] float moveSensitivity;

    private Vector2 moveLastPos;
    private PointerEventData mousePosHolder;

    private void Awake()
    {
        Instance = this;
    }

	private void Update()
	{
        if (FindObjectOfType<Character>().isCharacterForward)
        {
            runn_e = character.transform;
        }
        else
        {
            runn_e = slideBow.transform;
        }
    }

	public void OnDrag(PointerEventData eventData)
    {
        mousePosHolder = eventData;
        TouchDetectionMovement(mousePosHolder);
    }

    private void TouchDetectionMovement(PointerEventData eventData)
    {
        if (moveLastPos == Vector2.zero) moveLastPos = eventData.position;

        Vector2 difVec = eventData.position - moveLastPos;

        //MOVEMENT
        runn_e.localPosition += new Vector3(difVec.x, 0f, 0f) * moveSensitivity;
        moveLastPos = eventData.position;

        //CLAMP
        Vector3 clampedPos = runn_e.localPosition;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minClampTr.localPosition.x, maxClampTr.localPosition.x);
        runn_e.localPosition = clampedPos;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moveLastPos = Vector2.zero;

        if (mousePosHolder != null)
        {
            mousePosHolder.position = Vector2.zero;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mousePosHolder = eventData;
    }
}