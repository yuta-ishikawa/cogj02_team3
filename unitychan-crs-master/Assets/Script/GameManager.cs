using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	public enum JudgementState{
		MISS,
		BAD,
		POOR,
		GOOD,
		GREAT,
		PERFECT,
		JUDGEMENT_STATE_NUM,
	}

	private List<int> scoreList;

	void Start () {
		scoreList = new List<int> ();
		for (int i = 0; i < (int)JudgementState.JUDGEMENT_STATE_NUM; i++) {
			scoreList.Add (0);
		}
	}

	public void AddScore(JudgementState judge) {
		scoreList [(int)judge]++;
	}

	public int GetScore() {
		return 0;		//TODO
	}

	public List<int> GetScoreList() {
		return scoreList;
	}

	public void ChangeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
