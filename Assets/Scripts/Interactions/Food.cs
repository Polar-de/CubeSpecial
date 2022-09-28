using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfFood{MainCourse, Appetizer, SideDish, Dessert, Drink}
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
        if (_gameData.hasTablet)
        {
            switch (typeOfFood)
            {
                case TypeOfFood.MainCourse:
                    if (!_gameData.mainCourse)
                    {
                        _gameData.mainCourse = true;
                        _gameData.questID = 3;
                        GetFood();
                        return true;
                    }

                    NotificationSystem.Instance.Notification("Sie haben schon ein Hauptgericht");
                    return false;
                case TypeOfFood.SideDish:
                    if (!_gameData.sideDish && _gameData.mainCourse)
                    {
                        _gameData.sideDish = true;
                        _gameData.questID = 4;
                        GetFood();
                        return true;
                    }

                    if (!_gameData.mainCourse)
                    {
                        NotificationSystem.Instance.Notification("Sie müssen sich erst eine Hauptspeise holen");
                        return false;
                    }

                    NotificationSystem.Instance.Notification("Sie haben schon eine Beilage");
                    return false;
                case TypeOfFood.Appetizer:
                    if (!_gameData.appetizer && _gameData.mainCourse)
                    {
                        _gameData.appetizer = true;
                        _gameData.questID = 4;
                        GetFood();
                        return true;
                    }
                    
                    if (!_gameData.mainCourse)
                    {
                        NotificationSystem.Instance.Notification("Sie müssen sich erst eine Hauptspeise holen");
                        return false;
                    }

                    NotificationSystem.Instance.Notification("Sie haben schon eine Vorspeise");
                    return false;
                case TypeOfFood.Dessert:
                    if (!_gameData.dessert && _gameData.mainCourse)
                    {
                        _gameData.dessert = true;
                        _gameData.questID = 4;
                        GetFood();
                        return true;
                    }
                    
                    if (!_gameData.mainCourse)
                    {
                        NotificationSystem.Instance.Notification("Sie müssen sich erst eine Hauptspeise holen");
                        return false;
                    }

                    NotificationSystem.Instance.Notification("Sie haben schon ein Dessert");
                    return false;
                case TypeOfFood.Drink:
                    if (!_gameData.drink && _gameData.mainCourse &&
                        (_gameData.appetizer || _gameData.dessert || _gameData.sideDish))
                    {
                        _gameData.drink = true;
                        _gameData.questID = 5;
                        GetFood();
                        return true;
                    }
                    
                    if (!_gameData.mainCourse)
                    {
                        NotificationSystem.Instance.Notification("Sie müssen sich erst eine Hauptspeise holen");
                        return false;
                    }

                    if (!_gameData.appetizer || !_gameData.dessert || !_gameData.sideDish)
                    {
                        NotificationSystem.Instance.Notification("Sie müssen sich eine Vorspeise/Beilage/Dessert holen");
                        return false;
                    }

                    NotificationSystem.Instance.Notification("Sie haben schon ein Getränk");
                    return false;
            }
        }
        else
        {
            NotificationSystem.Instance.Notification("Sie müssen sich erst ein Tablett holen");
            return false;
        }
        
        return false;
    }

    private void GetFood()
    {
        foodOnTablet.SetActive(true);
        if (foodGone != null)
            foodGone.SetActive(false);

        _gameData.Price += price;
    }
}
