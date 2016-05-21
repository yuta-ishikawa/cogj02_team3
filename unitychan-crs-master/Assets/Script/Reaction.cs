using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Reaction : MonoBehaviour {

	enum judgementState{
		MISS,
		BAD,
		POOR,
		GOOD,
		GREAT,
		PERFECT
	}

	[SerializeField]
	private Sprite[] judgeResultSprites;
	[SerializeField]
	private GameObject jugmentResultImage;

	private List<int> scoreList;

	void Start () {
		scoreList = new List<int> ();
		for (int i = 0; i <= (int)judgementState.PERFECT; i++) {
			scoreList.Add (0);
		}
		CreateReaction (judgementState.PERFECT, Vector3.zero); //DBEUG
	}

	void CreateReaction(judgementState judge, Vector3 judgeResultPosition) {
		// 五段階評価の表示
		GameObject judgeResult = GameObject.Instantiate (jugmentResultImage) as GameObject;
		judgeResult.transform.SetParent (this.transform);
		judgeResult.GetComponent<Image> ().sprite = judgeResultSprites [(int)judge];
		judgeResult.GetComponent<RectTransform>().localPosition = judgeResultPosition;

		// ボイスの再生
		string voiceName = "";
		switch (judge){
		case judgementState.MISS:
			voiceName = "SE_sample";
			break;
		case judgementState.BAD:
			voiceName = "SE_sample";
			break;
		case judgementState.POOR:
			voiceName = "SE_sample";
			break;
		case judgementState.GOOD:
			voiceName = "SE_sample";
			break;
		case judgementState.GREAT:
			voiceName = "SE_sample";
			break;
		case judgementState.PERFECT:
			voiceName = "SE_sample";
			break;
		}
		AudioManager.Instance.PlaySE(voiceName);

		// スコア加算
		scoreList[(int)judge]++;
		Debug.Log (scoreList [(int)judge]);
	}

	public List<int> GetScoreList(){
		return scoreList;
	}
}
