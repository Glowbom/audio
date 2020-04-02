using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

/*
 * Created on Wed Apr 1 2020
 *
 * Copyright (c) 2020 Glowbom, Inc.
 */
public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioDataLoader audioDataLoader = new AudioDataLoader();
        audioDataLoader.audioData = new AudioData();
        audioDataLoader.audioData.sounds = new List<string>();
        audioDataLoader.audioData.keys = new List<string>();
        audioDataLoader.audioData.pictures = new List<string>();
        audioDataLoader.audioData.texts = new List<string>();
        audioDataLoader.audioData.textTimes = new List<string>();
        audioDataLoader.audioData.times = new List<string>();

#if UNITY_EDITOR
        // Find all Texture2Ds that have 'co' in their filename, that are labelled with 'architecture' and are placed in 'MyAwesomeProps' folder
        // to get all textures user t:texture2D
        string[] files = AssetDatabase.FindAssets("", new[] { "Assets/Glowbom/Audio/Resources" });

        foreach (string guid in files)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Debug.Log(path);

            if (path.Contains(".mp3"))
            {
                audioDataLoader.audioData.sounds.Add(path);

                string[] times = path.Split('_');
                string[] parts = times[0].Split('/');
                audioDataLoader.audioData.keys.Add(parts[parts.Length - 1]);
            } else if ((path.Contains(".jpg") || path.Contains(".png")) && !audioDataLoader.audioData.pictures.Contains(path))
            {
                string[] times = path.Split('_');
                audioDataLoader.audioData.times.Add(times[times.Length - 2] + "_" + times[times.Length - 1]
                                        .Replace(".jpg", "").Replace(".png", ""));
                audioDataLoader.audioData.pictures.Add(path);
            } else if (path.Contains(".txt") && path.Contains("_") && !audioDataLoader.audioData.texts.Contains(path))
            {
                string[] times = path.Split('_');
                audioDataLoader.audioData.textTimes.Add(times[times.Length - 2] + "_" + times[times.Length - 1]
                                        .Replace(".txt", ""));
                audioDataLoader.audioData.texts.Add(path);
            }
        }

        audioDataLoader.save();
#endif

        audioDataLoader.load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
