using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMouseSensitivity : MonoBehaviour
{
    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public void SetMouseSensitivity(float sliderValue)
    {
        _gameData.MouseX = sliderValue * 6;
        _gameData.MouseY = sliderValue * 6;
    }
}
