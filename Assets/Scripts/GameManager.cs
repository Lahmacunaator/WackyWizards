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

    public void UpdateGameState(GameState state)
    {
        State = state;

        switch (state)
        {
            case GameState.MainMenu:
                Time.timeScale = 1f;
                break;
            case GameState.Level:
                Time.timeScale = 1f;
                levelTimer = 0;
                break;
            case GameState.WizardScreen:
                Time.timeScale = 0f;
                FindAnyObjectByType<Shop>(FindObjectsInactive.Include).gameObject.SetActive(true);
                break;
            case GameState.Win:
                Time.timeScale = 1f;
                break;
            case GameState.Lose:
                Time.timeScale = 1f;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, "State is null");
        }

        OnStateChanged?.Invoke(state);
    }
    public void ChangeScene(int SceneIndex) 
    {
        SceneManager.LoadScene(SceneIndex);
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