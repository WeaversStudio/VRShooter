using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Lasergun : MonoBehaviour {



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
		if (Physics.Raycast(transform.position, transform.up, out hit, 50f,mask))
		{
			ray.origin = transform.position;
			ray.direction = transform.up;
			laser.SetPosition (0, transform.position+laseroffset);
			laser.SetPosition (1, ray.origin + ray.direction * hit.distance);

		} else
		{
			ray.origin = transform.position;
			ray.direction = transform.up;
			laser.SetPosition (0, transform.position+laseroffset);
			laser.SetPosition (1, ray.origin + ray.direction * laserlimit);

		}
			
	}
}
