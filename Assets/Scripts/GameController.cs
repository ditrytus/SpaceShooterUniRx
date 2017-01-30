using UnityEngine;
using UniRx;
using System;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnPositions;
	public FloatRange spawnPositionXRange;
	public int initialHazardCount;
	public float spawnInterval;
	public float waveDelay;
	public float waveInterval;
	private int hazardCount;
	public ScoreController scoreController;

	void Start () {
		hazardCount = initialHazardCount;

		var waves = new Subject<Unit>();

		waves
			.Subscribe(_ => {
				Observable
					.Interval(TimeSpan.FromSeconds(spawnInterval))
					.Take(hazardCount)
					.Subscribe(
						__ =>
							SpawnAsteroid(),
						() =>
							Observable
								.Timer(TimeSpan.FromSeconds(waveInterval))
								.Subscribe(___ => {
									waves.OnNext(Unit.Default);
								}));
				hazardCount++;
			});

		waves.OnNext(Unit.Default);
	}

	void SpawnAsteroid()
	{
		var asteroid = Instantiate(
			hazard,
			new Vector3(
				UnityEngine.Random.Range(spawnPositionXRange.min, spawnPositionXRange.max),
				spawnPositions.y,
				spawnPositions.z),
			Quaternion.identity);
		
		asteroid.GetComponent<DestroyOnCollision>().scoreController = scoreController;
	}
}
