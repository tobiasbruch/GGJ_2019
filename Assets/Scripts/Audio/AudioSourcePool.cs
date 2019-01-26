using System.Collections.Generic;
using UnityEngine;

    public class AudioSourcePool
    {
        private List<AudioSource> _audioSources;

        private GameObject _gameObject;

        public AudioSourcePool(GameObject gameObject)
        {
            _gameObject = gameObject;
            _audioSources = new List<AudioSource>();
        }

        public AudioSource GetSoundSource()
        {
            AudioSource source = null;

            for (int i = 0; i < _audioSources.Count; i++)
            {
                if (!_audioSources[i].isPlaying)
                {
                    source = _audioSources[i];
                    break;
                }
            }

            if (source != null)
            {
                return source;
            }

            source = CreateNewAudioSource();
            _audioSources.Add(source);
            return source;
        }

        private AudioSource CreateNewAudioSource()
        {
            return _gameObject.AddComponent<AudioSource>();
        }
    }

