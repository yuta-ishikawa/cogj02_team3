using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	public enum JudgementState{
		MISS,		//0点
		BAD,		//2点
		POOR,		//4点
		GOOD,		//6点
		GREAT,		//8点
		PERFECT,	//10点
		JUDGEMENT_STATE_NUM,
	}

	private List<int> scoreList;

	void Start () {
		if(this != Instance)
		{
			Destroy(this);
			return;
		}

		DontDestroyOnLoad(this.gameObject);

		scoreList = new List<int> ();
		for (int i = 0; i < (int)JudgementState.JUDGEMENT_STATE_NUM; i++) {
			scoreList.Add (0);
		}
	}

	public void ResetScore() {
		for (int i = 0; i < (int)JudgementState.JUDGEMENT_STATE_NUM; i++) {
			scoreList.Add (0);
		}
	}

	public void AddScore(JudgementState judge) {
		scoreList [(int)judge]++;
	}

	public int GetScore() {
		int score = 0;
		for (int i = 0; i < (int)JudgementState.JUDGEMENT_STATE_NUM; i++) {
			score += scoreList[i] * i * 2;
		}
		return score;
	}

	public List<int> GetScoreList() {
		return scoreList;
	}

	public void ChangeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
