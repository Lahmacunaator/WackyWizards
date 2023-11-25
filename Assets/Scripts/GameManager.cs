using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState State;
    public event Action<GameState> OnStateChanged;
    
    public static GameManager Instance { get; private set; }

    [SerializeReference] private List<LevelSO> levels;

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
        UpdateGameState(GameState.MainMenu);
    }

    public void UpdateGameState(GameState state)
    {
        State = state;

        switch (state)
        {
            case GameState.MainMenu:
                break;
            case GameState.Level:
                break;
            case GameState.WizardScreen:
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, "State is null");
        }

        OnStateChanged?.Invoke(state);
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