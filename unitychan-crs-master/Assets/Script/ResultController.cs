using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

// ResultScene内の管理と操作を行うコンポーネント
public class ResultController : MonoBehaviour {

	[SerializeField]
	private FadeParam		fadeParam = null;
	[SerializeField]
	private ResultVoice		resultVoice;
	[SerializeField]
	private GameObject		scoreResult;
	[SerializeField]
	private Text			scoreText;
	[SerializeField]
	private ParticleSystem	particle;

	//private 
	private string[] resultRankStr = { "TooBad", "Bad", "Good", "Great", "Perfect" };

	void Awake()
	{		
		// ここでリザルトの情報を確定させる
		scoreResult.SetActive(false);

		// デバッグ用
		// リストが空ならデフォルトの値を使う
		if (FindObjectOfType<GameManager>() == null) return;
		List<int> scoreList = GameManager.Instance.GetScoreList();
		
		scoreText.text = resultRankStr[4] + Environment.NewLine + 
			GameManager.Instance.GetScore() + Environment.NewLine +	Environment.NewLine +
			scoreList[5] + Environment.NewLine +
			scoreList[4] + Environment.NewLine +
			scoreList[3] + Environment.NewLine +
			scoreList[2] + Environment.NewLine +
			scoreList[1] + Environment.NewLine +
			scoreList[0];
	}

	void Start()
	{
		// フェードが終わったらボイス再生
		ScreenFadeManager.Instance.FadeOut(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade Out OK");
				resultVoice.PlayVoice(delegate{
					// ポップアップの表示を行う

					// 最高ランクならパーティクルも再生
					if (resultVoice.IsMaxRank()) particle.Play();
				});
			});
	}

	// タイトルへの遷移
	public void OnClickTitleButton()
	{
		// フェードアウト中は反応しないように
		if (ScreenFadeManager.Instance.isFadeAction) return;

		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Title");
			});
	}

	// リトライへの遷移
	public void OnClickRetryButton()
	{
		// フェードアウト中は反応しないように
		if (ScreenFadeManager.Instance.isFadeAction) return;

		ScreenFadeManager.Instance.FadeIn(fadeParam.time, fadeParam.color,
			delegate {
				Debug.Log("Fade In OK");
				SceneManager.LoadScene("Main");
				// メインに遷移後すぐにFadeOutを完了させる
				ScreenFadeManager.Instance.FadeOut(0.01f, new Color(1.0f, 1.0f, 1.0f), delegate { Debug.Log("OK"); });
			});
	}
}
