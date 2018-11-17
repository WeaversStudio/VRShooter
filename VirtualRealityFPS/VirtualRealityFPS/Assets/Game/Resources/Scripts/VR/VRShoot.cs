using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class VRShoot : MonoBehaviour {


	public static VRShoot instance;
	[Header("Decals Setting")]
	public GameObject decals;
	public List<GameObject> decalspool;
	public int decalpoolcount;




	[Header("BulletParticleSystemSetting")]
	public GameObject bulletparticlesystem;
	public List<GameObject> bulletparticlepool;
	public int bulletpoolcount;



	[Header("SmokeSetting")]
	public GameObject smoke;
	public List<GameObject> smokepool;
	public int smokepoolcount;

<<<<<<< HEAD
=======
	public Transform rayorigin;




	public static VRShoot instance;
	[Header("Decals Setting")]
	public GameObject decals;
	public List<GameObject> decalspool;
	public int decalpoolcount;




	[Header("BulletParticleSystemSetting")]
	public GameObject bulletparticlesystem;
	public List<GameObject> bulletparticlepool;
	public int bulletpoolcount;



	[Header("SmokeSetting")]
	public GameObject smoke;
	public List<GameObject> smokepool;
	public int smokepoolcount;

>>>>>>> 7a2985b3cdca5662237f8fd41940c9c2a0da3972


	public Transform guntip;
	private SteamVR_TrackedController trackcontroller;
	public SteamVR_Controller.Device controller;
	private SteamVR_TrackedObject trackedobject;
	private GameObject m4;


	public static bool isshooting;
	[SerializeField]
	private LayerMask mask;

	public AmmoManager ammomanger;



	private Vector3 smokeoffset = new Vector3(0,0,0.1f);


	void Start()
	{

		//StartCoroutine ("decaltimewait");


	}
	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
		trackedobject = GetComponentInParent<SteamVR_TrackedObject> ();
		trackcontroller = GetComponentInParent<SteamVR_TrackedController> ();
		decalspool = new List<GameObject> ();
		for (int i = 0; i < decalpoolcount; i++) 
		{
			GameObject decalobj = Instantiate (decals);
			decalobj.SetActive (false);
			decalspool.Add (decalobj);
<<<<<<< HEAD

		}
		for (int i = 0; i < bulletpoolcount; i++) 
		{
			GameObject bulletobj = Instantiate (bulletparticlesystem);
			bulletobj.SetActive (false);
			bulletparticlepool.Add (bulletobj);

		}
		for (int i = 0; i < smokepoolcount; i++) 
		{
			GameObject smokeobj = Instantiate (smoke);
			smokeobj.SetActive (false);
			smokepool.Add(smokeobj);

		}
=======

		}
		for (int i = 0; i < bulletpoolcount; i++) 
		{
			GameObject bulletobj = Instantiate (bulletparticlesystem);
			bulletobj.SetActive (false);
			bulletparticlepool.Add (bulletobj);

		}
		for (int i = 0; i < smokepoolcount; i++) 
		{
			GameObject smokeobj = Instantiate (smoke);
			smokeobj.SetActive (false);
			smokepool.Add(smokeobj);

		}
>>>>>>> 7a2985b3cdca5662237f8fd41940c9c2a0da3972
	}
	void Update () 
	{
		
		controller = SteamVR_Controller.Input ((int)trackedobject.index);


		//Single Shot 
		if (controller.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Shoot ();

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
<<<<<<< HEAD
		if (Physics.Raycast (transform.position,transform.up, out hit, 100f, mask)) 
=======
		if (Physics.Raycast (rayorigin.position,-rayorigin.forward, out hit, 100f, mask)) 
>>>>>>> 7a2985b3cdca5662237f8fd41940c9c2a0da3972
		{
			//Destroy (hit.transform.gameObject);
			if (ammomanger.Magzinecapacity > 0) 
			{
				GameObject Decalsused = GetDecalsofpool();
				Decalsused.transform.position = hit.point;
				Decalsused.transform.rotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
				Decalsused.SetActive (true);
				if (Decalsused == null)
				{
					return;
				}
				GameObject bullet = GetBulletfromparticlesofpool ();
				bullet.transform.position = guntip.position;
				bullet.SetActive (true);
				if (bullet == null)
				{
					return;
				}
				isshooting = true;
				//controller.TriggerHapticPulse (1000);
				GameObject usedsmoke = GetSmokefromPool ();
				usedsmoke.transform.position = guntip.position + smokeoffset;
				usedsmoke.SetActive (true);
				if (usedsmoke == null)
				{
					return;
				}
				AudioManager.PlayAudio ("Shoot");
			}
		}
	}


	public GameObject GetDecalsofpool()
	{
		for (int i = 0; i < decalspool.Count; i++) 
		{
			if (decalspool [i].activeInHierarchy == false) 
			{
				return decalspool [i];
			} 
		}
		return null;
	}
		

	public GameObject GetBulletfromparticlesofpool()
	{
		for (int i = 0; i < bulletparticlepool.Count; i++) 
		{
			if (bulletparticlepool [i].activeInHierarchy == false) 
			{
				return bulletparticlepool[i];
<<<<<<< HEAD
=======
			}
		}

		return null;
	}



	public GameObject GetSmokefromPool()
	{
		for (int i = 0; i < smokepool.Count; i++) 
		{
			if (smokepool [i].activeInHierarchy == false) 
			{
				return smokepool [i];
>>>>>>> 7a2985b3cdca5662237f8fd41940c9c2a0da3972
			}
		}

		return null;
<<<<<<< HEAD
	}



	public GameObject GetSmokefromPool()
	{
		for (int i = 0; i < smokepool.Count; i++) 
		{
			if (smokepool [i].activeInHierarchy == false) 
			{
				return smokepool [i];
			}
		}

		return null;
=======
>>>>>>> 7a2985b3cdca5662237f8fd41940c9c2a0da3972
	}
		
}
