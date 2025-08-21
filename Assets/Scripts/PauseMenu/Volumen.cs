using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{

    [SerializeField] Toggle muteMusic;
    [SerializeField] Toggle muteEffect;

    [SerializeField] Slider volumenMusic;
    [SerializeField] Slider volumenEffect;

    private Bus musicBus;
    private Bus effectBus;
    
    void Start()
    {
        musicBus = RuntimeManager.GetBus("bus:/Musica_De_Fondo");
        effectBus = RuntimeManager.GetBus("bus:/Efectos");
    }


    void Update()
    {
        if(muteMusic.isOn)
        {
            musicBus.setVolume(0);
        }
        else
        {
            musicBus.setVolume(volumenMusic.value);
        }

        if (muteEffect.isOn)
        {
            effectBus.setVolume(0);
        }
        else
        {
            effectBus.setVolume(volumenEffect.value);
        }

    }
}
