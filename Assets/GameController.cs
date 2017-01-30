using UnityEngine;
using UniRx;

public class GameController : MonoBehaviour {
	public int pointsPerHazard;

	void Start () {
		var hazardWavesController = GetComponent<HazardWavesController>();
		var scoreController = GetComponent<ScoreController>();
		var gameOverController = GetComponent<GameOverController>();

		hazardWavesController
			.asteroidDestroyed
			.Subscribe(_ => {
				scoreController.newScore.OnNext(pointsPerHazard);
			});
		
		hazardWavesController
			.playerDestroyed
			.Subscribe(_ => {
				gameOverController.gameOver.OnNext(Unit.Default);
			});
	}
}
