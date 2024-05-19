using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class audioManager : StaticInstance<audioManager>
{
    public Sound[] bgmSounds;
    public Sound[] sounds;
    public static float bgMusicVolume = .18f;
    public static float effectsMusicVolume = .18f;
    static Sound actualBGM;

    protected override void Awake()
    {
        base.Awake();
        foreach (Sound s in bgmSounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("No se encontr� el audio!");
            return;
        }
        s.source.Play();
    }
    public void PlayBGM(string name)
    {
        actualBGM = Array.Find(bgmSounds, bgmSounds => bgmSounds.name == name);
        if (actualBGM == null)
        {
            Debug.LogError("No se encontr� el audio!");
            return;
        }
        actualBGM.source.Play();
    }
    public void updateBGMusic(string newTheme)
    {
        if(actualBGM == null)
        {
            PlayBGM(newTheme);
            updateBGValume(bgMusicVolume);
        }
        if (actualBGM.name != newTheme)
        {
            actualBGM.source.Stop();
            PlayBGM(newTheme);
            updateBGValume(bgMusicVolume);
        }
    }
    public void updateBGValume(float volume)
    {
        bgMusicVolume = volume;
        actualBGM.source.volume = volume;
    }
    public void updateEffectsVolume(float volume)
    {
        effectsMusicVolume = volume;
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }
    private IEnumerator UpdateBGMusicWithFade(string newTheme, float fadeDuration)
    {
        float t = 0.0f;
        Sound newBGM = Array.Find(bgmSounds, bgmSounds => bgmSounds.name == newTheme);
        if (newBGM == null)
        {
            Debug.LogError("No se encontr� el audio!");
            yield break;
        }

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalizedTime = t / fadeDuration;
            actualBGM.source.volume = Mathf.Lerp(bgMusicVolume, 0, normalizedTime);
            newBGM.source.volume = Mathf.Lerp(0, bgMusicVolume, normalizedTime);
            yield return null;
        }

        actualBGM.source.Stop();
        newBGM.source.volume = 0.5f;
        PlayBGM(newTheme);
    }

    public void updateWithFade(string newTheme, float fadeDuration)
    {
        if (actualBGM.name != newTheme)
        {
            StartCoroutine(UpdateBGMusicWithFade(newTheme, fadeDuration));
        }
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Mercado")
        {
            audioManager.Instance.updateBGMusic("Mercado");
        }
        else if (SceneManager.GetActiveScene().name == "PruebaRestaurante") {
            audioManager.Instance.updateBGMusic("Cocina");
        }
        else if (SceneManager.GetActiveScene().name == "Menu"){
            audioManager.Instance.updateBGMusic("Menu");
        }

    }
    

}
