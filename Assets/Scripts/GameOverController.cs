using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : RxBehaviour {
	public ISubject<Unit> gameOver;
	public float restartDelay;

	public Text gameOverText;
	public Text restartText;

	void Start () {
		gameOver = new Subject<Unit>();

		var sub1 = gameOver.Subscribe(_ => {
			gameOverText.gameObject.SetActive(true);
		});

		var canRestart = gameOver
			.Delay(TimeSpan.FromSeconds(restartDelay));
		
		var sub2 = canRestart.Subscribe(_ => {
			restartText.gameObject.SetActive(true);
		});

		var restartPressed = Observable
			.EveryUpdate()
			.Where(_ => Input.GetKeyDown(KeyCode.R));

		var sub3 = restartPressed	
			.CombineLatest(canRestart, (a,b) => Unit.Default)
			.Subscribe(_ => {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			});
		
		AddSubscriptions(sub1, sub2, sub3);
	}
}
