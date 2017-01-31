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

		var sub2 = gameOver
			.Delay(TimeSpan.FromSeconds(restartDelay))
			.Subscribe(_ => {
				restartText.gameObject.SetActive(true);

				Observable
					.EveryUpdate()
					.Where(__ => Input.GetKeyDown(KeyCode.R))
					.First()
					.Subscribe(___ => {
						SceneManager.LoadScene(SceneManager.GetActiveScene().name);
					});
			});
		
		AddSubscriptions(sub1, sub2);
	}
}
