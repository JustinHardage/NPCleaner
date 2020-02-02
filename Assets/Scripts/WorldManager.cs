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
    public AudioSource _audioSource;
    public AudioClip _doorClose;
    public AudioClip _doorOpen;
    public AudioClip _dialogUp;
    public AudioClip _dialogDown;

    // UI references
    public Image _timerClock;
    public Text _timerText;
    public GameObject _gameOverPanel;
    public GameObject _dialogPanel;
    public Text _dialogText;

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

    public void TextPopUp(string text)
    {
        _dialogText.text = text;
        // shrink to zero-size
        _audioSource.PlayOneShot(_dialogUp);
        _dialogPanel.SetActive(true);
        // animate popping up
    }

    public void TextPopDown()
    {
        _dialogText.text = "popped down";
        // animate popping down
        // set to zero-size
        _dialogPanel.SetActive(false);
        _audioSource.PlayOneShot(_dialogDown);
    }

    public void PlayCloseDoorSound()
    {
        _audioSource.PlayOneShot(_doorClose);
    }

    public void PlayOpenDoorSound()
    {
        _audioSource.PlayOneShot(_doorOpen);
    }
}
