using UnityEngine;
using UnityEngine.Assertions;

namespace Asteroid
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource AudioSource { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            AudioSource = GetComponent<AudioSource>();
            Assert.IsNotNull(AudioSource);
        }
    }
}