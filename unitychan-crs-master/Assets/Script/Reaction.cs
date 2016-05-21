using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reaction : MonoBehaviour {

	enum judgementState{
		MISS,
		BAD,
		POOR,
		GOOD,
		GREAT,
		PERFECT
	}
	judgementState judge;

	[SerializeField]
	private Sprite[] judgeResultSprites;
	[SerializeField]
	private GameObject jugmentResultImage;

	// Use this for initialization
	void Start () {
		judge = judgementState.GOOD;
		CreateReaction (judge, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
	
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
	}
}
