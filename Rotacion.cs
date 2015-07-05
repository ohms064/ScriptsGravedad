using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {

	public Transform planeta;
	public float velocidad = 5f;
	public float gravedad = 0.1f;

	private SphereCoordinate sphCoord;
	private const float offset = 0.1f;

	// Use this for initialization
	void Start () {
		sphCoord = new SphereCoordinate(this.GetComponent<Rigidbody>().position);
	}
	
	// Update is called once per frame
	void Update () {
			print("Longitude: " + sphCoord.longitude);
			print("Latitude: " + sphCoord.latitude);
			print("Valido: " + sphCoord.valido);

			sphCoord.latitude += Input.GetAxis("Vertical") * velocidad;
			sphCoord.longitude += Input.GetAxis("Horizontal") * velocidad;
			this.GetComponent<Rigidbody>().position = sphCoord.toVector3();
			this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, -1 * sphCoord.longitude, sphCoord.latitude - 90f);
			//this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(sphCoord.longitude, 0f, sphCoord.latitude - 90f);
			//this.GetComponent<Rigidbody>().AddRelativeForce(this.transform.up * -1f);

			sphCoord.updateVar();
	}

}
