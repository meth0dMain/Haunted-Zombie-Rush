using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject gameplayUI;

	public bool playerActive { get; private set; }
	public bool gameOver { get; private set; }
	public bool gameStarted { get; private set; }
	public float score { get; }

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		Assert.IsNotNull(mainMenu);
		Assert.IsNotNull(gameplayUI);
	}

	public void PlayerCollided()
	{
		gameOver = true;
	}

	public void PlayerStartedGame()
	{
		playerActive = true;
		gameplayUI.SetActive(true);
	}

	private void Start()
	{
		playerActive = false;
		gameOver = false;
		gameStarted = false;
		mainMenu.SetActive(true);
		gameplayUI.SetActive(false);
	}

	public void EnterGame()
	{
		gameStarted = true;
		mainMenu.SetActive(false);
	}
}
