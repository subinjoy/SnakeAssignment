using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : ScreenFactory
{
    public static GameOverScreen Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
