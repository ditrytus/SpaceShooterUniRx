using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DestroyOnTriggerExit : MonoBehaviour {
	void Start () {
		this.OnTriggerExitAsObservable()
			.Subscribe(c => Destroy(c.gameObject));
	}
}
