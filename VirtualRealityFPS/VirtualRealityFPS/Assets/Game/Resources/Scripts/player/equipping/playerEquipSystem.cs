using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEquipSystem : MonoBehaviour {

    public Transform leftHandItem;
    public Transform rightHandItem;

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
        Transform leftHandController;
        Transform rightHandController;
    }
}
