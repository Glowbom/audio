using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        // Find all Texture2Ds that have 'co' in their filename, that are labelled with 'architecture' and are placed in 'MyAwesomeProps' folder
        // to get all textures user t:texture2D
        string[] files = AssetDatabase.FindAssets("", new[] { "Assets/Glowbom/Audio/Resources" });

        foreach (string guid in files)
        {
            Debug.Log(AssetDatabase.GUIDToAssetPath(guid));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
