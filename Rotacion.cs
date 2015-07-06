using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {

	public Transform planeta;
	public float velocidad = 5f;
	[Range(0f, 10f)] public float gravedad = 0.1f;
	[Range(0f, 150f)] public float salto = 0.1f;

	private SphereCoordinate sphCoord;
	private const float offset = 0.1f;
	private bool colision;

	// Use this for initialization
	void Start () {
		colision = false;
		sphCoord = new SphereCoordinate(this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
			print("Longitude: " + sphCoord.longitude + ", Latitude: " + sphCoord.latitude + ", Magnitude: " + sphCoord.magnitude);
			print("XYZ: " + sphCoord.ToVector3());
			//sphCoord = new SphereCoordinate(this.transform.position);

			sphCoord.latitude += Input.GetAxis("Vertical") * velocidad;
			sphCoord.longitude += Input.GetAxis("Horizontal") * velocidad;
			
			sphCoord.UpdateVar();
	}

	void FixedUpdate(){
		this.GetComponent<Rigidbody>().position = sphCoord.ToVector3();
		this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, -1 * sphCoord.longitude, sphCoord.latitude - 90f);
		if (!colision) {
			this.GetComponent<Rigidbody>().AddForce(this.transform.up * -1f * gravedad);
			sphCoord.UpdateCoord(this.transform.position);
		}
		if( Input.GetButtonDown("Jump")){
			this.GetComponent<Rigidbody>().AddForce(this.transform.up * salto);
			sphCoord.UpdateCoord(this.transform.position);
		}
		
	}

	void OnCollisionEnter(){
		colision = true;
	}

	void OnCollisionExit(){
		colision = false;
	}

}
