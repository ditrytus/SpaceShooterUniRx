using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text scoreText;
	
	public int score;

	public Subject<int> newScore;

	void Start () {
		newScore = new Subject<int>();

		newScore
			.Select(n => score = score + n)
			.Select(s => $"Score: {s}")
			.SubscribeToText(scoreText);

		newScore.OnNext(score);
	}
}
