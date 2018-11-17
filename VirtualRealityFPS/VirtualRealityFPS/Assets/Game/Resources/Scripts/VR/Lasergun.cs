using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Lasergun : MonoBehaviour {


	public Transform rayorigin;


	private LineRenderer laser;
	Ray ray;
	public float laserlimit = 50f;
	[SerializeField]
	LayerMask mask;
	public Vector3 laseroffset;


	// Use this for initialization
	void Start () 
	{
		
		laser = GetComponent<LineRenderer> ();	
	}

	// Update is called once per frame
	void Update () 
	{
		
		RaycastHit hit;
		if (Physics.Raycast(rayorigin.position, -rayorigin.forward, out hit, 50f,mask))
		{
<<<<<<< HEAD
			ray.origin = transform.position;
			ray.direction = transform.up;
			laser.SetPosition (0, transform.position+laseroffset);
			laser.SetPosition (1, ray.origin + ray.direction * hit.distance);
=======
			ray.origin = rayorigin.position;
			ray.direction = -rayorigin.forward;
			laser.SetPosition (0, rayorigin.position+laseroffset);
			laser.SetPosition (1,rayorigin.position + ray.direction * hit.distance);
>>>>>>> 7a2985b3cdca5662237f8fd41940c9c2a0da3972

		} else
		{
			ray.origin = rayorigin.position;
			ray.direction = -rayorigin.forward;
			laser.SetPosition (0, rayorigin.position+laseroffset);
			laser.SetPosition (1, rayorigin.position + ray.direction * laserlimit);

		}
			
	}
}
