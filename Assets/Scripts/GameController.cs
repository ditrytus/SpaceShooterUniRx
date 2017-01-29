using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnPositions;
	public FloatRange spawnPositionXRange;

	void Start () {
		SpawnWave();
	}

	void SpawnWave()
	{
        Instantiate(
			hazard,
			new Vector3(
				Random.Range(spawnPositionXRange.min, spawnPositionXRange.max),
				spawnPositions.y,
				spawnPositions.z),
			Quaternion.identity);
	}
}
