using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// ゲーム中にユニティちゃんのテンションを表すSpriteをまとめたオブジェクト
[System.Serializable]
public class TensionStatusObject : ScriptableObject {
	[SerializeField, Tooltip("0～4の順でTooBad～Perfectを設定")]
	private List<Sprite> _tensionSprites;
	public List<Sprite> tensionSprites
	{
		get { return _tensionSprites; }
		private set { _tensionSprites = value; }
	}
}
