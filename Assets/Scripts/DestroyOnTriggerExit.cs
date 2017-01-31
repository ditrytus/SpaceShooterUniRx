using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DestroyOnTriggerExit : RxBehaviour {
	void Start () {
		var sub1 = this.OnTriggerExitAsObservable()
			.Subscribe(c => Destroy(c.gameObject));

		AddSubscriptions(sub1);
	}
}
