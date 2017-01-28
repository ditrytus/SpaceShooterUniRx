using UnityEngine;

public class MoveForward : MonoBehaviour
{
	public float speed;
	
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;		
	}
}
