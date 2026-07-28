using UnityEngine;
using System.Collections.Generic;

namespace MoonGame.Systems.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        public AudioSource musicSource;
        public AudioSource sfxSource;
        public AudioSource ambientSource;
        
        [Header("Sound Settings")]
        public float masterVolume = 1.0f;
        public float musicVolume = 0.7f;
        public float sfxVolume = 0.8f;
        public float ambientVolume = 0.5f;
        
        [Header("Audio Clips")]
        public List<AudioClip> backgroundMusic = new List<AudioClip>();
        public List<AudioClip> soundEffects = new List<AudioClip>();
        public List<AudioClip> ambientSounds = new List<AudioClip>();
        
        [Header("Settings")]
        public bool playMusic = true;
        public bool playSFX = true;
        public bool playAmbient = true;
        
        private int currentMusicIndex = 0;
        private bool isPlayingMusic = false;
        
        void Start()
        {
            InitializeAudioSystem();
        }
        
        private void InitializeAudioSystem()
        {
            // Set default volumes
            if (musicSource != null)
                musicSource.volume = musicVolume * masterVolume;
                
            if (sfxSource != null)
                sfxSource.volume = sfxVolume * masterVolume;
                
            if (ambientSource != null)
                ambientSource.volume = ambientVolume * masterVolume;
                
            Debug.Log("Audio Manager initialized");
        }
        
        public void PlayMusic(int index = 0)
        {
            if (!playMusic || backgroundMusic.Count == 0)
                return;
                
            if (index >= 0 && index < backgroundMusic.Count)
            {
                if (musicSource != null)
                {
                    musicSource.clip = backgroundMusic[index];
                    musicSource.Play();
                    isPlayingMusic = true;
                }
            }
        }
        
        public void PlayRandomMusic()
        {
            if (!playMusic || backgroundMusic.Count == 0)
                return;
                
            int randomIndex = Random.Range(0, backgroundMusic.Count);
            PlayMusic(randomIndex);
        }
        
        public void PlaySoundEffect(AudioClip clip)
        {
            if (!playSFX || clip == null)
                return;
                
            if (sfxSource != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }
        
        public void PlayRandomSoundEffect()
        {
            if (!playSFX || soundEffects.Count == 0)
                return;
                
            int randomIndex = Random.Range(0, soundEffects.Count);
            PlaySoundEffect(soundEffects[randomIndex]);
        }
        
        public void PlayAmbientSound(AudioClip clip)
        {
            if (!playAmbient || clip == null)
                return;
                
            if (ambientSource != null)
            {
                ambientSource.clip = clip;
                ambientSource.loop = true;
                ambientSource.Play();
            }
        }
        
        public void SetVolume(float volume)
        {
            masterVolume = Mathf.Clamp01(volume);
            
            if (musicSource != null)
                musicSource.volume = musicVolume * masterVolume;
                
            if (sfxSource != null)
                sfxSource.volume = sfxVolume * masterVolume;
                
            if (ambientSource != null)
                ambientSource.volume = ambientVolume * masterVolume;
        }
        
        public void SetMusicVolume(float volume)
        {
            musicVolume = Mathf.Clamp01(volume);
            
            if (musicSource != null)
                musicSource.volume = musicVolume * masterVolume;
        }
        
        public void SetSFXVolume(float volume)
        {
            sfxVolume = Mathf.Clamp01(volume);
            
            if (sfxSource != null)
                sfxSource.volume = sfxVolume * masterVolume;
        }
        
        public void ToggleMusic()
        {
            playMusic = !playMusic;
            
            if (musicSource != null)
            {
                if (playMusic)
                    musicSource.Play();
                else
                    musicSource.Pause();
            }
        }
        
        public void ToggleSoundEffects()
        {
            playSFX = !playSFX;
        }
        
        public void ToggleAmbientSounds()
        {
            playAmbient = !playAmbient;
        }
    }
}