using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultText : MonoBehaviour {

	[SerializeField, Tooltip("表示テキストデータオブジェクト")]
	private ResultTextObject textObj;
	[SerializeField]
	private Text resultText;

	public void SetTextData(ResultScoreRank rank)
	{
		// 異常値チェック
		if (rank == ResultScoreRank.None)
		{
			Debug.LogAssertion("Rank Is Assertion!!!!");
			return;
		}

		// ランクに応じてテキスト設定
		resultText.text = textObj.texts[(int)rank];

		// nullチェック
		if (!string.IsNullOrEmpty(resultText.text)) return;

		Debug.LogAssertion(rank + "Text Is null!!!!");
	}
}
