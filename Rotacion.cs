using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {

	public Transform planeta;
	public float velocidad = 5f;

	private SphereCoordinate sphCoord;
	private

	// Use this for initialization
	void Start () {
		sphCoord = new SphereCoordinate(this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
			print("latitude: " + sphCoord.latitude);
			print("longitude: " + sphCoord.longitude);
			print("magnitude: " + sphCoord.magnitude);
			sphCoord.longitude += Input.GetAxis("Vertical") * velocidad;
			sphCoord.latitude += Input.GetAxis("Horizontal") * velocidad;
			this.transform.position = sphCoord.toVector3();
			this.transform.localEulerAngles = new Vector3(sphCoord.longitude, 0, sphCoord.latitude - 90f);


	}

}
