using UnityEngine;
using System.Collections;

public class SphereCoordinate {
	public float longitude;
	public float latitude;
	public float magnitude;

	public SphereCoordinate (Vector3 vector) {
		Vector2 ro = new Vector2(vector.x, vector.z);
		magnitude = vector.magnitude;
		if(ro.magnitude == 0f){
			longitude = 0;
			latitude = 90f;
		}
		else{
			longitude = Mathf.Acos(vector.x / ro.magnitude) * Mathf.Rad2Deg;
			latitude = Mathf.Acos(ro.magnitude / magnitude) * Mathf.Rad2Deg;
		}
	}
	
	public SphereCoordinate () {
		latitude = 0;
		longitude = 0;
		magnitude = 0;
	}

	public Vector3 toVector3(){
		float x = magnitude * Mathf.Cos(latitude * Mathf.Deg2Rad);
		float y = magnitude * Mathf.Sin(latitude * Mathf.Deg2Rad) * Mathf.Cos(longitude * Mathf.Deg2Rad);
		float z = magnitude * Mathf.Sin(latitude * Mathf.Deg2Rad) * Mathf.Sin(longitude * Mathf.Deg2Rad);
		return new Vector3(x, y, z);
	}
}
