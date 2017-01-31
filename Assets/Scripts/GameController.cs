using UnityEngine;
using UniRx;

public class GameController : RxBehaviour {
	public int pointsPerHazard;

	void Start () {
		var hazardWavesController = GetComponent<HazardWavesController>();
		var scoreController = GetComponent<ScoreController>();
		var gameOverController = GetComponent<GameOverController>();

		var sub1 = hazardWavesController
			.asteroidDestroyed
			.Subscribe(_ => {
				scoreController.newScore.OnNext(pointsPerHazard);
			});
		
		var sub2 = hazardWavesController
			.playerDestroyed
			.Subscribe(_ => {
				gameOverController.gameOver.OnNext(Unit.Default);
			});

		AddSubscriptions(sub1, sub2);
	}
}
