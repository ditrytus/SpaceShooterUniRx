using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ScoreController : RxBehaviour {
	public Text scoreText;
	
	public int score;

	public Subject<int> newScore;

	void Start () {
		newScore = new Subject<int>();

		var sub1 = newScore
			.Select(n => score = score + n)
			.Select(s => $"Score: {s}")
			.SubscribeToText(scoreText);

		newScore.OnNext(score);

		AddSubscriptions(sub1);
	}
}
