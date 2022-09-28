using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] quests;
    private GameData _gameData;
    private int oldID;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    private void Update()
    {
        if (oldID != _gameData.questID)
        {
            quests[oldID].SetActive(false);
            oldID = _gameData.questID;
        }
        if (!quests[_gameData.questID].activeSelf)
            quests[_gameData.questID].SetActive(true);
    }
}
