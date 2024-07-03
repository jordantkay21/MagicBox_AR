using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxManager : MonoBehaviour
{
    private string correctGemOrder = "BlueRedGreen";
    private string enteredGemOrder = "";

    private int amountOfGems = 3;
    private int currentGem = 0;

    public Gem[] gemsInScene;
    public UnityEvent gameIsWon;
    
    
    public void GemSelect(Gem currentSelectGem)
    {
        enteredGemOrder += currentSelectGem.gemColorName;
        currentGem += 1;

        currentSelectGem.ChangeEmission(true);

        if (currentGem == 3)
            CompareGemOrder();

        print(currentSelectGem.gemColorName + " Gem Selected!");
    }

    public void CompareGemOrder()
    {
        if (enteredGemOrder == correctGemOrder)
        {
            print("Order is Correct!");
            CompleteGame();
        }
        else
        {
            print("Order in Incorrect, resetting");
            print("User entered: " + enteredGemOrder);
            ResetGame();
        }
    }
    private void CompleteGame()
    {
        gameIsWon.Invoke();
    }

    private void ResetGame()
    {
        currentGem = 0;
        enteredGemOrder = "";

        foreach (Gem gem in gemsInScene)
        {
            gem.ChangeEmission(false);
        }
    }

}
