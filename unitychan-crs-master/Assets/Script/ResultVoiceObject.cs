using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResultVoiceObject : ScriptableObject {
	[SerializeField, Tooltip("0～4の順でTooBad～Perfectを設定")]
	private List<AudioClip> _clips;
	public List<AudioClip> clips
	{
		get { return _clips; }
		private set { _clips = value; }
	}
}
