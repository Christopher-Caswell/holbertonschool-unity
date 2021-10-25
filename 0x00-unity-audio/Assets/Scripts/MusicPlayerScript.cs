// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.Audio;

// public class MusicPlayerScript : MonoBehaviour
// {
//     public AudioMixer MuzakMixer;

//     private float muzakVolume = 1f;

//     void Update()
//     {
//         MuzakMixer.Volume = muzakVolume;
//     }

//     public void SetVolume(float volume)
//     {
//         muzakVolume = LinearToDecibel(volume);
//     }

//     private float LinearToDecibel(float linear)
//     {
//         float dB;

//         if (linear != 0)
//         {
//             dB = 20.0f * Mathf.Log10(linear);
//         }
//         else
//         {
//             dB = -144.0f;
//         }

//         return dB;
//     }

// }
