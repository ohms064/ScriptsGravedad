using UnityEngine;
using System.Collections;

public class SphereCoordinate : PolarCoordinate{
	public float longitude;
	public float latitude;
	public float magnitude;
	public float valido = 0f;

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

	public void updateVar(){
		valido = 0f;
		if (longitude > 360f) {
			valido += 1f;
			longitude -= 360f;
		}else if (longitude < 0f) {
			longitude += 360f;
			valido -= 1f;
		}

		if (latitude > 360f) {
			valido += 10f;
			latitude -= 360f;
		}else if (latitude < 0f) {
			latitude += 360f;
			valido -= 10f;
		}
	}

	public override Vector3 toVector3(){
		float ro = magnitude *Mathf.Cos(latitude * Mathf.Deg2Rad); 
		float x = ro * Mathf.Cos(longitude * Mathf.Deg2Rad);
		float y = magnitude * Mathf.Sin(latitude * Mathf.Deg2Rad);
		float z = ro * Mathf.Sin(longitude * Mathf.Deg2Rad);
		return new Vector3(x, y, z);
	}
}
