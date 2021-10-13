using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPause : MonoBehaviour
{
    Animator anim = default;
    PauseManager3D _pauseManager = default;
    // Start is called before the first frame update

    void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager3D>();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        _pauseManager.OnPauseResume += PauseResume;
    }
    void OnDisable()
    {
        _pauseManager.OnPauseResume -= PauseResume;
    }

    void PauseResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        anim.enabled = false;
    }

    public void Resume()
    {
        anim.enabled = true;
    }
}
