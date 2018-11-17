using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEquipSystem : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;
    [Space(10)]
    public Transform leftHandItem;
    public Transform rightHandItem;
    [Space(10)]
    public Transform cameraRig;

    void Update()
    {
        ManageEquipping();
    }

    void ManageEquipping()
    {
        switch (inputManager.controlMode)
        {
            case 0:
                ManageKeyboardEquipping();
                break;

            case 1:
                ManageJoypadEquipping();
                break;

            case 2:
                ManageHandEquipping();
                break;
        }
    }

    void ManageKeyboardEquipping()
    {

    }

    void ManageJoypadEquipping()
    {

    }

    void ManageHandEquipping()
    {
        Transform leftHandController = cameraRig.GetComponent<SteamVR_ControllerManager>().left.transform;
        Transform rightHandController = cameraRig.GetComponent<SteamVR_ControllerManager>().right.transform;

        SteamVR_TrackedController leftHandProperties = leftHandController.GetComponent<SteamVR_TrackedController>();
        SteamVR_TrackedController rightHandProperties = rightHandController.GetComponent<SteamVR_TrackedController>();


        Transform leftHandSelection = leftHand.GetComponent<VR_equipDetector>().selectedObject;
        Transform rightHandSelection = rightHand.GetComponent<VR_equipDetector>().selectedObject;

        if (leftHandProperties.gripped)
        {
            leftHandItem = leftHandSelection;
        }

        if (rightHandProperties.gripped)
        {
            rightHandItem = rightHandSelection;
        }


        if (leftHandItem)
        {
            Transform leftItemMount = leftHandSelection.GetComponent<itemHandler>().gripMount;

            leftHandItem.parent = leftHand;
            leftHandItem.localPosition = leftItemMount.localPosition;
            leftHandItem.localRotation = leftItemMount.localRotation;
        }

        if (rightHandItem)
        {
            Transform rightItemMount = rightHandSelection.GetComponent<itemHandler>().gripMount;

            rightHandItem.parent = rightHand;
            rightHandItem.localPosition = rightItemMount.localPosition;
			rightHandItem.localRotation = rightItemMount.localRotation;
        }
    }
}
