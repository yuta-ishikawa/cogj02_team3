using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// リザルト画面に表示するユニティちゃんの表情を変更する
public class ResultFaceChanger : MonoBehaviour {

	[SerializeField]
	private RawImage faceRawImage = null;
	[SerializeField]
	private ResultFaceImageObject images;
	
	public void SetFaceImage(ResultScoreRank rank)
	{
		// 異常値チェック
		if(rank == ResultScoreRank.None)
		{
			Debug.LogAssertion("Rank Is Assertion!!!!");
			return;
		}
		
		// ランクに応じて表情設定
		faceRawImage.texture = images.textures[(int)rank];

		// nullチェック
		if (faceRawImage.texture != null) return;

		Debug.LogAssertion(rank + "Texture Is null!!!!");
	}
	
}
