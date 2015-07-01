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
		sphCoord = new SphereCoordinate(this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
			//sphCoord.magnitude -= gravedad;
			// if(Physics.Raycast(rayo, out hit, (this.GetComponent<CapsuleCollider>().height / 2) + offset)){
			// 	print("Suelo!");
			// 	print(hit.distance);
			// }else{
			// 	sphCoord.magnitude -= gravedad;
			// }
			sphCoord.updateVar();

			sphCoord.longitude += Input.GetAxis("Vertical") * velocidad;
			sphCoord.latitude += Input.GetAxis("Horizontal") * velocidad;
			this.GetComponent<Rigidbody>().position = sphCoord.toVector3();
			//this.transform.localEulerAngles = new Vector3(sphCoord.longitude, 0, sphCoord.latitude);
			this.GetComponent<Rigidbody>().rotation = Quaternion.Euler(sphCoord.longitude, 0, sphCoord.latitude);


	}

}
