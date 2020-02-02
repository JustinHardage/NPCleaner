using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    // singleton
    private static WorldManager _instance;
    public static WorldManager Instance => _instance ?? (_instance = FindObjectOfType<WorldManager>());

    // inspector references
    public Room _currentRoom;

    // UI references
    public Image _timerClock;
    public Text _timerText;
    public GameObject _gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        _timerText.text = _currentRoom?.TimerReadout() ?? "--:--";
        _timerClock.fillAmount = _currentRoom == null ? 1 : _currentRoom._remainingTime / _currentRoom._startingTime;
    }

    public void TimeOver(Room callingRoom)
    {
        if (_currentRoom != callingRoom) { return; }

        GameOver();
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);

        StartCoroutine(GameOverDelay());
    }

    public IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Start");
    }
}
