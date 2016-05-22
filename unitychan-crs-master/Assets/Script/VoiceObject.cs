using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoiceObject : ScriptableObject {
	[SerializeField]
	private List<AudioClip> _missVoiceClips;
	public List<AudioClip> missVoiceClips
	{
		get { return _missVoiceClips; }
	}
	[SerializeField]
	private List<AudioClip> _badVoiceClips;
	public List<AudioClip> badVoiceClips
	{
		get { return _badVoiceClips; }
	}
	[SerializeField]
	private List<AudioClip> _poorVoiceClips;
	public List<AudioClip> poorVoiceClips
	{
		get { return _poorVoiceClips; }
	}
	[SerializeField]
	private List<AudioClip> _goodVoiceClips;
	public List<AudioClip> goodVoiceClips
	{
		get { return _goodVoiceClips; }
	}
	[SerializeField]
	private List<AudioClip> _greatVoiceClips;
	public List<AudioClip> greatVoiceClips
	{
		get { return _greatVoiceClips; }
	}
	[SerializeField]
	private List<AudioClip> _perfectVoiceClips;
	public List<AudioClip> perfectVoiceClips
	{
		get { return _perfectVoiceClips; }
	}
}
