using UnityEngine;
using UniRx;
using System;

public class MoveOnInput : MonoBehaviour
{
	public float speed;

	private IDisposable updateSubscription;
	
	void Start ()
	{
		updateSubscription = Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
                GetComponent<Rigidbody>().velocity = new Vector3(
						Input.GetAxis("Horizontal"),
						0.0f,
						Input.GetAxis("Vertical"))
					* speed;
			});
	}

	void OnDestroy()
	{
		updateSubscription.Dispose();
	}
}
