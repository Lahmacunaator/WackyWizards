using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameState State;
    public event Action<GameState> OnStateChanged;
    public List<ModifierSO> AllModifiers;
    public static GameManager Instance { get; private set; }

    [SerializeReference] private List<LevelSO> levels;
    [SerializeReference] private float levelCounter = 45f;
    
    private float levelTimer = 0f;
    private TMP_Text levelTimerText;
    private UiManager uiManager;

    private int winCount = 0;
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        } 
    }

    private void Start()
    {
        //UpdateGameState(GameState.MainMenu);

        AudioManager.Instance.PlayMusic("MainTheme");
    }

    private void Update()
    {
        if (State != GameState.Level) return;
        levelTimer += Time.deltaTime;

        UpdateLevelTimerText();
        
        if (levelTimer >= levelCounter)
        {
            if (winCount >= 4)
            {
                UpdateGameState(GameState.Win);
                return;
            }
            UpdateGameState(GameState.WizardScreen);
        }
    }

    private void UpdateLevelTimerText()
    {
        if (levelTimerText == null)
        {
            levelTimerText = GameObject.Find("LevelTimer").GetComponent<TMP_Text>();
        }
        
        levelTimerText.text = $"{levelCounter-levelTimer}";
    }

    public async void UpdateGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                winCount = 0;
                await SceneManager.LoadSceneAsync(0);
                break;
            case GameState.Level:
                if (SceneManager.GetActiveScene().buildIndex != 1)
                {
                    await SceneManager.LoadSceneAsync(1);
                }
                
                Time.timeScale = 1f;
                levelTimer = 0;
                uiManager = FindFirstObjectByType<UiManager>();
                ActivateSpawners();
                break;
            case GameState.WizardScreen:
                Time.timeScale = 0f;
                FindAnyObjectByType<Shop>(FindObjectsInactive.Include).gameObject.SetActive(true);
                winCount++;
                break;
            case GameState.Win:
                Time.timeScale = 0f;
                uiManager.ActivateWinScreen();
                break;
            case GameState.Lose:
                uiManager.ActivateLoseScreen();
                Time.timeScale = 0f;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, "State is null");
        }

        State = state;
        
        OnStateChanged?.Invoke(state);
    }

    public void ActivateSpawners()
    {
        uiManager.ActivateSpawners(winCount);
    }
    public void ChangeScene(int SceneIndex) 
    {
        if (SceneIndex == 1)
        {
            UpdateGameState(GameState.Level);
        }
    }
}

public enum GameState
{
    MainMenu,
    Level,
    WizardScreen,
    Win,
    Lose
}