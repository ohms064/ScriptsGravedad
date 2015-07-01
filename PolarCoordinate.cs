using UnityEngine;
using System.Collections;

public abstract class PolarCoordinate {
	public float longitude;
	public float latitude;
	public float magnitude;
	public abstract Vector3 toVector3();
}
