using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Telekinesis : MonoBehaviour
{
    public GameObject rightHand, leftHand;

    private bool hoveringLeft, hoveringRight;

    private GameObject hoveredLeft,hoveredRight;

    Vector3 rightHandPosition;
    Vector3 leftHandPosition;

    // Start is called before the first frame update
    void Start()
    {
        hoveringLeft = false;
        hoveringRight = false;

        hoveredRight = null;
        hoveredLeft = null;

        rightHandPosition = rightHand.transform.position;
        leftHandPosition = leftHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHand.transform.rotation.eulerAngles.z >= 60 && rightHand.transform.rotation.eulerAngles.z <= 300 && hoveredRight != null)
        {
            hoveredRight.transform.position += (rightHand.transform.position - rightHandPosition) * 5;
        }
        
        if (leftHand.transform.rotation.eulerAngles.z >= 60 && leftHand.transform.rotation.eulerAngles.z <= 300 && hoveredLeft != null)
        {
            hoveredLeft.transform.position += (leftHand.transform.position - leftHandPosition) * 5;
        }

        rightHandPosition = rightHand.transform.position;
        leftHandPosition = leftHand.transform.position;

        if ((rightHand.transform.rotation.eulerAngles.z <= 60 || rightHand.transform.rotation.eulerAngles.z >= 300) && !hoveringRight)
        {
            hoveredRight = null;
        }

        if ((leftHand.transform.rotation.eulerAngles.z <= 60 || leftHand.transform.rotation.eulerAngles.z >= 300) && !hoveringLeft)
        {
            hoveredLeft = null;
        }

    }

    public void HoverLeft(HoverEnterEventArgs args)
    {
        if (!hoveringLeft)
        {
            hoveredLeft = GameObject.Find(args.interactableObject.transform.name);
            hoveringLeft = true;
        }
    }

    public void HoverLeftExit(HoverExitEventArgs args)
    {
        hoveringLeft = false;
    }

    public void HoverRight(HoverEnterEventArgs args)
    {
        if (!hoveringRight)
        {
            hoveredRight = GameObject.Find(args.interactableObject.transform.name);

            hoveringRight = true;
        }
    }

    public void HoverRightExit()
    {
        hoveringRight = false;
    }
}
