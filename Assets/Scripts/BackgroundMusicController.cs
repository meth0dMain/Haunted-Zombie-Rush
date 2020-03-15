using UnityEngine;
using UnityEngine.Assertions;

public class BackgroundMusicController : MonoBehaviour
{
	[SerializeField] private AudioClip menuMusic;
	[SerializeField] private AudioClip gameMusic;
	private AudioSource _audioSource;

	private void Awake()
	{
		_audioSource = GetComponent<AudioSource>();
		Assert.IsNotNull(_audioSource);
		Assert.IsNotNull(menuMusic);
		Assert.IsNotNull(gameMusic);
	}

	private void Update()
	{
		var clipToPlay = GameManager.instance.gameStarted ? gameMusic : menuMusic;
		PlayMusic(clipToPlay);
	}

	private void PlayMusic(AudioClip clipToPlay)
	{
		if (_audioSource.clip != clipToPlay)
		{
			_audioSource.clip = clipToPlay;
			_audioSource.Play();
		}
	}
}
