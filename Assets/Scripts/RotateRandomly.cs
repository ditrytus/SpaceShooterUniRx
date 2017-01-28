using UnityEngine;

public class RotateRandomly : MonoBehaviour {

	public float tumble;

	void Start () {
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
}
