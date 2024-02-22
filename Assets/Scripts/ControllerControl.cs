using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerControl : MonoBehaviour
{
    public GameObject controllerOuter;
    public GameObject controllerInner;
    public Vector2 controllerVec;
    public Color activeColor;

    private Vector2 controllerTouchPos;
    private Vector2 controllerInitPos;
    private float controllerRadius;
    private Color idleColor;

    private bool 
        isUp = false, 
        isDown = false, 
        isLeft = false, 
        isRight = false;

    [SerializeField]
    private float moveThreshold = 0.3f;
    [SerializeField]
    private GameObject controlUp;
    [SerializeField]
    private GameObject controlDown;
    [SerializeField]
    private GameObject controlLeft;
    [SerializeField]
    private GameObject controlRight;
    // Start is called before the first frame update
    void Start()
    {
        controllerInitPos = controllerOuter.transform.position;
        controllerRadius = controllerOuter.GetComponent<RectTransform>().sizeDelta.y / 4;

        idleColor = controlUp.GetComponent<Image>().color;
        ColorUtility.TryParseHtmlString("#000000", out activeColor);

        print("Delta Y : " + controllerOuter.GetComponent<RectTransform>().sizeDelta.y);
        print("Radius : " + controllerRadius);
    }

    public void PointerDown()
    {
        Vector2 initPos = Input.mousePosition;
        controllerTouchPos = controllerOuter.transform.position;
        controllerVec = (initPos - controllerTouchPos);
        controllerVec = Vector2.ClampMagnitude(controllerVec, 60)/60;
        //print(controllerVec);
        float controllerDist = Vector2.Distance(initPos, controllerTouchPos);
        if (controllerDist < controllerRadius)
        {
            controllerInner.transform.position = controllerTouchPos + controllerVec * controllerDist;
        }
        else
        {
            controllerInner.transform.position = controllerTouchPos + controllerVec * controllerRadius;
        }

    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        //print(dragPos);
        controllerVec = (dragPos - controllerTouchPos);
        controllerVec = Vector2.ClampMagnitude(controllerVec, 60) / 60;

        float controllerDist = Vector2.Distance(dragPos, controllerTouchPos);

        if (controllerDist < controllerRadius)
        {
            controllerInner.transform.position = controllerTouchPos + controllerVec * controllerDist;
        }
        else
        {
            controllerInner.transform.position = controllerTouchPos + controllerVec * controllerRadius;
        }
    }

    public void PointerUp()
    {
        controllerVec = Vector2.zero;
        controllerInner.transform.position = controllerInitPos;
        controllerOuter.transform.position = controllerInitPos;
    }

    public bool IsUp()
    {
        return isUp;
    }
    public bool IsDown()
    {
        return isDown;
    }
    public bool IsRight()
    {
        return isRight;
    }

    public bool IsLeft()
    {
        return isLeft;
    }
    // Update is called once per frame
    void Update()
    {
        //Atas
        if (controllerVec.y > moveThreshold)
        {
            controlUp.GetComponent<Image>().color = activeColor;
            isUp = true;
        } else
        {
            controlUp.GetComponent<Image>().color = idleColor;
            isUp = false;
        }

        //Bawah
        if (controllerVec.y < -moveThreshold)
        {
            controlDown.GetComponent<Image>().color = activeColor;
            isDown = true;
        }
        else
        {
            controlDown.GetComponent<Image>().color = idleColor;
            isDown = false;
        }

        //Kanan
        if (controllerVec.x > moveThreshold)
        {
            controlRight.GetComponent<Image>().color = activeColor;
            isRight = true;
        }
        else
        {
            controlRight.GetComponent<Image>().color = idleColor;
            isRight = false;
        }

        //Kiri
        if (controllerVec.x < -moveThreshold)
        {
            controlLeft.GetComponent<Image>().color = activeColor;
            isLeft = true;
        }
        else
        {
            controlLeft.GetComponent<Image>().color = idleColor;
            isLeft = false;
        }
    }
}
