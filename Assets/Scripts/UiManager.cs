using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateWinScreen()
    {
        winScreen.SetActive(true);
    }
    
    public void ActivateLoseScreen()
    {
        loseScreen.SetActive(true);
    }

    public void OnReturnToMenuButtonClicked()
    {
        GameManager.Instance.UpdateGameState(GameState.MainMenu);
    }
}
