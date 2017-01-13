using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MoveOnInput : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
                GetComponent<Rigidbody>().velocity = new Vector3(
						Input.GetAxis("Horizontal"),
						0.0f,
						Input.GetAxis("Vertical"))
					* speed;
			});
	}
}
