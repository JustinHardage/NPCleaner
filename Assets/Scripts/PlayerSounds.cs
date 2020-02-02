using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource _footstepSource;
    public AudioSource _actionSource;
    public AudioSource _voiceSource;

    public List<AudioClip> _stepClips;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayStep()
    {
        _footstepSource.clip = _stepClips[Random.Range(0, _stepClips.Count - 1)];
        _footstepSource.pitch = Random.Range(0.9f, 1.1f);
        _footstepSource.Play();
    }
}
