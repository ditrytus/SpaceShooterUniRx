using UnityEngine;
using UniRx;
using System;

public class HazardWavesController : RxBehaviour {
	public GameObject hazard;
	public Vector3 spawnPositions;
	public FloatRange spawnPositionXRange;
	public int initialHazardCount;
	public float spawnInterval;
	public float waveDelay;
	public float waveInterval;
	private int hazardCount;

	public ISubject<Unit> asteroidDestroyed;
	public ISubject<Unit> playerDestroyed;

	public HazardWavesController()
	{
		asteroidDestroyed = new Subject<Unit>();
		playerDestroyed = new Subject<Unit>();
		
		hazardCount = initialHazardCount;
	}

	void Start () {
		var waves = new Subject<Unit>();

		var sub1 = waves
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

		AddSubscriptions(sub1);
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
		
		var destroyOnCollision = asteroid.GetComponent<DestroyOnCollision>();

		destroyOnCollision.asteroidDestroyed = asteroidDestroyed;
		destroyOnCollision.playerDestroyed = playerDestroyed;
	}
}
