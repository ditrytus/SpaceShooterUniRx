using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	public ISubject<Unit> gameOver;
	public float restartDelay;

	public Text gameOverText;
	public Text restartText;

	void Start () {
		gameOver = new Subject<Unit>();

		gameOver.Subscribe(_ => {
			gameOverText.gameObject.SetActive(true);
		});

		var canRestart = gameOver
			.Delay(TimeSpan.FromSeconds(restartDelay));
		
		canRestart.Subscribe(_ => {
			restartText.gameObject.SetActive(true);
		});

		var restartPressed = Observable
			.EveryUpdate()
			.Where(_ => Input.GetKeyDown(KeyCode.R));

		restartPressed	
			.CombineLatest(canRestart, (a,b) => Unit.Default)
			.Subscribe(_ => {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			});
	}
}
