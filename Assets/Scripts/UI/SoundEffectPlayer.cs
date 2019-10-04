using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour {
	AudioClip soundEffectWalk;
	AudioClip soundEffectJump;
	AudioClip soundEffectDie;
	AudioClip soundEffectWin;
	AudioClip backgroundMusic;
	AudioClip backgroundMusic2;
	AudioClip backgroundMusic3;
	AudioClip backgroundMusic4;
	AudioClip soundEffectSaw;

	AudioSource[] audioSources;
	AudioSource walkAudioSource;
	AudioSource backgroundAudioSource;
	AudioSource backgroundAudioSource2;
	AudioSource backgroundAudioSource3;
	AudioSource backgroundAudioSource4;
	AudioSource SoundEffectRobot;

	void Start () {

		// Load all the sound files
		/*soundEffectWalk = Resources.Load<AudioClip>("Sounds/dk-a2600_walk");
		soundEffectJump = Resources.Load<AudioClip>("Sounds/dk-a2600_jump");
		soundEffectDie = Resources.Load<AudioClip>("Sounds/dk-a2600_die");
		soundEffectWin = Resources.Load<AudioClip>("Sounds/dk-a2600_victory");*/
		//soundEffectRobot = Resources.Load<AudioClip>("Sounds/Robot");
		backgroundMusic = Resources.Load<AudioClip>("Sounds/Music/hell ambiance");
		backgroundMusic2 = Resources.Load<AudioClip>("Sounds/Music/Metal1");
		backgroundMusic3 = Resources.Load<AudioClip>("Sounds/Music/Elevator");
		backgroundMusic4 = Resources.Load<AudioClip>("Sounds/Music/Drone1");

		// Create a few Audio Sources (in case we want to play more than one sound at a time)
		audioSources = new AudioSource[5];
		for (int i = 0; i < 5; i++) {
			audioSources[i] = gameObject.AddComponent<AudioSource>();
		}

		/*// Create a dedicated Audio Source for the walk sound
		walkAudioSource = gameObject.AddComponent<AudioSource>();
		walkAudioSource.clip = soundEffectWalk;
		walkAudioSource.loop = true;
		walkAudioSource.playOnAwake = false;*/

		/*SoundEffectRobot = gameObject.AddComponent<AudioSource>();
		SoundEffectRobot.clip = soundEffectRobot;
		SoundEffectRobot.loop = true;
		SoundEffectRobot.volume = 0.05f;*/

		// Create a dedicated Audio Source for the background music
		backgroundAudioSource = gameObject.AddComponent<AudioSource>();
		backgroundAudioSource.clip = backgroundMusic;
		backgroundAudioSource.loop = true;
		backgroundAudioSource.volume = 1f;
		backgroundAudioSource.Play();

		backgroundAudioSource2 = gameObject.AddComponent<AudioSource>();
		backgroundAudioSource2.clip = backgroundMusic2;
		backgroundAudioSource2.loop = true;
		backgroundAudioSource2.volume = 1f;
		backgroundAudioSource2.Play();

		backgroundAudioSource3 = gameObject.AddComponent<AudioSource>();
		backgroundAudioSource3.clip = backgroundMusic3;
		backgroundAudioSource3.loop = true;
		backgroundAudioSource3.volume = 1f;
		backgroundAudioSource3.Play();

		backgroundAudioSource4 = gameObject.AddComponent<AudioSource>();
		backgroundAudioSource4.clip = backgroundMusic4;
		backgroundAudioSource4.loop = true;
		backgroundAudioSource4.volume = .5f;
		backgroundAudioSource4.Play();
	}

	void PlaySoundEffect(AudioClip clip) {

		// Find an available Audio Source and use it to play the sound
		foreach (AudioSource source in audioSources) {
			if (!source.isPlaying) {
				source.clip = clip;
				source.Play();
				return;
			}
		}
	}

	/*public void PlayWalkEffect(bool play) {

		if (play) {
			if (!walkAudioSource.isPlaying) walkAudioSource.Play();
		}
		else {
			walkAudioSource.Pause();
		}
	}

	public void PlayJumpEffect() {
		PlaySoundEffect(soundEffectJump);
	}
	public void PlayDieEffect() {
		PlaySoundEffect(soundEffectDie);
	}
	public void PlayWinEffect() {
		PlaySoundEffect(soundEffectWin);
	}*/
	/*public void PlaySawEffect() {
		SoundEffectSaw.Play();
	}

	public void StopSawEffect() {
		SoundEffectSaw.Stop();
	}*/
	public void StartBackgroundMusic() {
		backgroundAudioSource4.Play();
	}

	public void StopBackgroundMusic() {
		backgroundAudioSource4.Stop();
	}
}
