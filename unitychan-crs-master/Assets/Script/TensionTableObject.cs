using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TensionTableObject : ScriptableObject {
	[SerializeField, Tooltip("0～4の順でTooBad～Perfectを設定, 基本的に設定した値以下ならその段階の評価になる")]
	private List<int> _table;
	public List<int> table
	{
		get { return _table; }
		private set { _table = value; }
	}
}
