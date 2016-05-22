using UnityEngine;
using System.Collections;
using System;

public class ResultVoice : MonoBehaviour {

	[SerializeField, Tooltip("上からTooBad～Perfectの順に設定すること")]
	private ResultVoiceObject voiceObj;
	
	// 念のためコンポーネント格納用の変数を用意
	private AudioSource audioSource;

	ResultScoreRank tmpRank;

	public void SetVoice(ResultScoreRank rank)
	{
		tmpRank = rank;

		// 異常値チェック
		if (rank == ResultScoreRank.None)
		{
			Debug.LogAssertion("Rank Is Assertion!!!!");
			return;
		}

		// ランクに応じて表情設定
		audioSource.clip = voiceObj.clips[(int)rank];

		// nullチェック
		if (audioSource.clip != null) return;

		Debug.LogAssertion(rank + "Voice Clip Is null!!!!");
	}

	// 最高評価かどうか
	public bool IsMaxRank() { return tmpRank == ResultScoreRank.Perfect ? true : false; }

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	// 一応任意のタイミングでボイス再生
	public void PlayVoice(Action callBack)
	{
		audioSource.Play();
		StartCoroutine(PlayingVoice(callBack));
	}

	IEnumerator PlayingVoice(Action callBack)
	{
		while (audioSource.isPlaying)
		{
			yield return new WaitForSeconds(0.1f);
		}
		callBack();
	}

}
