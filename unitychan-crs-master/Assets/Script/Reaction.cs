using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Reaction : MonoBehaviour {

	[SerializeField]
	private Sprite[] judgeResultSprites;
	[SerializeField]
	private GameObject jugmentResultImage;
	[SerializeField]
	private VoiceObject voiceObject;
	private List<List<AudioClip>> voiceList;
	private AudioSource audioSource;

	void Start () {
		voiceList = new List<List<AudioClip>> ();
		for (int i = 0; i < (int)GameManager.JudgementState.JUDGEMENT_STATE_NUM; i++) {
			voiceList.Add(Util.Choose(i+1, voiceObject.missVoiceClips, voiceObject.badVoiceClips, voiceObject.poorVoiceClips, voiceObject.goodVoiceClips, voiceObject.greatVoiceClips, voiceObject.perfectVoiceClips));
		}
		audioSource = this.GetComponent<AudioSource>();
	}

	public void CreateReaction(GameManager.JudgementState judge, Vector3 judgeResultPosition) {
		// 五段階評価の表示
		GameObject judgeResult = GameObject.Instantiate (jugmentResultImage) as GameObject;
		judgeResult.transform.SetParent (this.transform);
		judgeResult.GetComponent<Image> ().sprite = judgeResultSprites [(int)judge];
		judgeResult.GetComponent<RectTransform>().localPosition = judgeResultPosition;

		// ボイスの再生
		AudioClip voice = voiceList [(int)judge] [UnityEngine.Random.Range (0, voiceList [(int)judge].Count)];
		if (voice == null) {
			Debug.LogAssertion (judge + "Voice Clip Is null!!");
		}
		audioSource.clip = voice;
		audioSource.Play ();

		// スコア加算
		GameManager.Instance.AddScore(judge);
	}
}
