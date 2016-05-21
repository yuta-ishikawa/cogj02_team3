using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {

	[SerializeField, Tooltip("表示テキストデータオブジェクト")]
	private ResultTextObject textObj;
	[SerializeField]
	private Text resultText;

	// ここはGameManagerクラスが確立したら消す
	private enum ScoreRank
	{
		None = -1, TooBad, Bad, Good, Great, Perfect
	};

	[SerializeField, Tooltip("デバッグ兼確認用")]
	private ScoreRank rank = ScoreRank.None;

	private void SetTextData()
	{
		// 異常値チェック
		if (rank == ScoreRank.None)
		{
			Debug.LogAssertion("Rank Is Assertion!!!!");
			return;
		}

		// ランクに応じて表情設定
		resultText.text = textObj.texts[(int)rank];

		// nullチェック
		if (!string.IsNullOrEmpty(resultText.text)) return;

		Debug.LogAssertion(rank + "Text Is null!!!!");
	}

	// Use this for initialization
	void Start () {
		SetTextData();
	}
}
