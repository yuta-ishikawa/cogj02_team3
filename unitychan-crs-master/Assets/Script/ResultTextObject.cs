using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// リザルトで表示するテキストをまとめたオブジェクト
[System.Serializable]
public class ResultTextObject : ScriptableObject {
	[SerializeField, Tooltip("0～4の順でTooBad～Perfectを設定")]
	private List<string> _texts;
	public List<string> texts
	{
		get { return _texts; }
		private set { _texts = value; }
	}
}
