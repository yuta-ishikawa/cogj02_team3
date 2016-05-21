using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// リザルトで表示するテキストをまとめたオブジェクト
[System.Serializable]
public class ResultFaceImageObject : ScriptableObject {
	[SerializeField, Tooltip("0～4の順でTooBad～Perfectを設定")]
	private List<Texture> _textures;
	public List<Texture> textures
	{
		get { return _textures; }
		private set { _textures = value; }
	}
}
