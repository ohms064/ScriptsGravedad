using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class RotacionRigid : MonoBehaviour {

	public GameObject planeta;
	public float velocidad = 5f;
	public float gravedad = 2f;
	public float fuerza = 20f;
	private bool gravedadActiva;

	private PolarCoordinate sphCoord; //Recibe cualquier sistema de coordendas que herede de PolarCoordinate

	// Use this for initialization
	void Start () {
		sphCoord = new SphereCoordinate(this.transform.position);
		this.GetComponent<Rigidbody>().isKinematic = false;
		this.GetComponent<Rigidbody>().useGravity  = false;
		gravedadActiva = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		print("latitude: " + sphCoord.latitude);
		print("longitude: " + sphCoord.longitude);
		print("magnitude: " + sphCoord.magnitude);
		sphCoord.longitude += Input.GetAxis("Vertical") * velocidad;
		sphCoord.latitude += Input.GetAxis("Horizontal") * velocidad;
		this.GetComponent<Rigidbody>().position = sphCoord.toVector3();
		this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(sphCoord.longitude, 0, sphCoord.latitude - 90f);
			
		if(gravedadActiva)
			this.GetComponent<Rigidbody>().AddForce((planeta.GetComponent<Rigidbody>().worldCenterOfMass - this.GetComponent<Rigidbody>().position).normalized * gravedad);
		
		//if( Input.GetButtonDown("Jump"))
		//	this.GetComponent<Rigidbody>().AddForce(Vector3.up * fuerza);
	}


	void OnCollisionEnter(Collision otro){
		gravedadActiva = false;
	}

	void OnCollisionExit(Collision otro){
		gravedadActiva = true;
	}

}
