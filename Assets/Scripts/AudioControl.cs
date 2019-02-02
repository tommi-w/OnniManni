using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour {

	public AudioMixerGroup master;
	bool muted = false;
	float audioVolume;

	public void ToggleMute(){
		switch (muted)
		{
			case true:
				muted = !muted;
				master.audioMixer.SetFloat("Volume",audioVolume);
				break;
			case false:
				muted = !muted;
				master.audioMixer.GetFloat("Volume",out audioVolume);
				master.audioMixer.SetFloat("Volume",-80f);
				break;
			default:
			break;
		}
	}
}
