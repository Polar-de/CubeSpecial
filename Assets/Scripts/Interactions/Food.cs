using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfFood{MainCourse, Appetizer, SideDish, Dessert}
public class Food : MonoBehaviour, IInteract
{
    [SerializeField] private string interactionPrompt;
    [SerializeField] private GameObject foodOnTablet;
    [SerializeField] private GameObject foodGone;
    [SerializeField] private float price;
    [SerializeField] private TypeOfFood typeOfFood;

    private GameData _gameData;

    private void Start()
    {
        _gameData = FindObjectOfType<GameData>();
    }

    public string InteractionPrompt => interactionPrompt;

    public bool Interact(PlayerInteraction playerInteraction)
    {
        switch (typeOfFood)
        {
            case TypeOfFood.MainCourse:
                if (!_gameData.mainCourse)
                {
                    _gameData.mainCourse = true;
                    GetFood();
                    return true;
                }
                else
                {
                    Debug.Log("Du hast schon eine Hauptspeise.");
                    return false;
                }
            case TypeOfFood.SideDish:
                if (!_gameData.sideDish)
                {
                    _gameData.mainCourse = true;
                    GetFood();
                    return true;
                }
                else
                {
                    Debug.Log("Du hast schon eine Beilage.");
                    return false;
                }
            case TypeOfFood.Appetizer:
                if (!_gameData.appetizer)
                {
                    _gameData.appetizer = true;
                    GetFood();
                    return true;
                }
                else
                {
                    Debug.Log("Du hast schon eine Vorspeise.");
                    return false;
                }
            case TypeOfFood.Dessert:
                if (!_gameData.dessert)
                {
                    _gameData.dessert = true;
                    GetFood();
                    return true;
                }
                else
                {
                    Debug.Log("Du hast schon ein Dessert.");
                    return false;
                }
        }

        return false;
    }

    private void GetFood()
    {
        foodOnTablet.SetActive(true);
        foodGone.SetActive(false);

        _gameData.Price += price;
    }
}
