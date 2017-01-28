using UnityEngine;
using UniRx;

public class TiltOnMove : MonoBehaviour
{
	public float tilt;

	void Start ()
	{
        Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{	
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
			});
	}
}
