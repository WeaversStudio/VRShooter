using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRShoot : MonoBehaviour {



	private SteamVR_TrackedController trackcontroller;
	public SteamVR_Controller.Device controller;
	private SteamVR_TrackedObject trackedobject;
	private GameObject m4;
	public GameObject decals;
	public static bool isshooting;
	[SerializeField]
	private LayerMask mask;
	public AmmoManager ammomanger;
	private Vector3 rayoffset = new Vector3(0.1f,0.1f,0);

	void Awake()
	{

		trackedobject = GetComponent<SteamVR_TrackedObject> ();
		trackcontroller = GetComponent<SteamVR_TrackedController> ();
	}
	void Update () 
	{
		controller = SteamVR_Controller.Input ((int)trackedobject.index);


		//Single Shot 
		if (controller.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Shoot ();
			isshooting = true;
			//controller.TriggerHapticPulse (500);
		}
			//Burst Shot 
		/*if (trackcontroller.triggerPressed)) 
		{
			Shoot ();
		}
        */

		else 
		{
			isshooting = false;
		}

	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position+rayoffset,-transform.up, out hit, 100f, mask)) 
		{
			Debug.DrawRay (transform.position, -transform.up,Color.red);
			//Destroy (hit.transform.gameObject);

			if (ammomanger.Magzinecapacity > 0) 
			{
				GameObject Decalsused = Instantiate (decals);
				decals.transform.position = hit.point;
				decals.transform.rotation = Quaternion.FromToRotation (Vector3.back, hit.normal);
				Destroy (Decalsused, 5f);
			}
		}
	}
}
