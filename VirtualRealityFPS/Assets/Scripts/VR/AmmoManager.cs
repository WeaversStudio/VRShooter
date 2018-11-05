using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
	 
	private SteamVR_Controller.Device controller;
	private SteamVR_TrackedController trackedcontroller;
	private SteamVR_TrackedObject trackedobj;
	public int Magzinecapacity;
	public int ammo;
	public GameObject righthand;
	public GameObject lefthand;
	public GameObject lefthandwithmagzine;
	public GameObject lefthandwithmagzineused;
	public TextMesh Reloadmessage;


	// Use this for initialization
	void Start () 
	{
		trackedobj = GetComponentInParent<SteamVR_TrackedObject> ();
		trackedcontroller = GetComponentInParent<SteamVR_TrackedController> ();
		Magzinecapacity = 30;
		ammo = 60;
	}
	
	// Update is called once per frame
	void Update ()
	{

		controller = SteamVR_Controller.Input ((int)trackedobj.index);

		if (VRShoot.isshooting == true && Magzinecapacity > 0) 
		{
			Magzinecapacity--;
		}
		if (Magzinecapacity == 0 && ammo > 30) 
		{
			Reloadmessage.text = "You gotta reload";
		}
		if (Magzinecapacity != 0 && ammo != 0) 
		{
			Reloadmessage.text = "";

		}

		if (Magzinecapacity == 0 && ammo <= 30 && ammo > 0) 
		{
			Reloadmessage.text = "You gotta reload";
		}

		if (ammo == 0 && Magzinecapacity == 0) 
		{

			Debug.Log("Get Some ammo");
		}
		if (trackedcontroller.gripped)
		{
			lefthandwithmagzineused.SetActive (true);
		}
	}



	void OnTriggerEnter(Collider col)
	{
		

		if (col.gameObject.tag == "HandActivation") 
		{
			lefthand.SetActive (true);
		}

	}
		
	public void Reload()
	{
		int ammotobefull = 30 - Magzinecapacity;
		Magzinecapacity += ammotobefull;
		ammo -= ammotobefull;
	}

}
