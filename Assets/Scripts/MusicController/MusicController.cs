using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference eventReference;

    private FMOD.Studio.EventInstance currentMusic;


    public int nivel_actual;

    public bool isMusicPlaying = false;

    private void Update()
    {
        Debug.Log("Se esta reproduciendo musica: " + isMusicPlaying);
    }


    private void Start()
    {
        if(isMusicPlaying == false)
        {
            currentMusic = RuntimeManager.CreateInstance(eventReference);

            currentMusic.start();

            isMusicPlaying = true;
        }

    }


    public void stopCurrentMusic()
    {
        currentMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        currentMusic.release();

        isMusicPlaying = false;
    }

}
