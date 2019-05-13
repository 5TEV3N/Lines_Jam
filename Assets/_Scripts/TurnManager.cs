using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
///     BIG THANKS FOR MATT F FOR THIS SCRIPT
/// </summary>


public class TurnManager : MonoBehaviour
{


    [Header("Player Turn Order Attributes")]
    public List<PlayerInfo> currentPlayerTurnOrder = new List<PlayerInfo>(); //This represents the current turn order
    
    private List<PlayerInfo> previousPlayerTurnOrder = new List<PlayerInfo>(); //Previous Turn's order

    [Space(10)]
    public int totalPlayerCount = 4; //Total Count of Players

    [Space(10)]
    public PlayerInfo currentPlayerJudge = new PlayerInfo(); //Current Judge Info
    public PlayerInfo previousPlayerJudge = new PlayerInfo(); //Previous Judge Info

    private void Start()
    {
        InitializeTurnOrder(); //Initialize the default turn order
    }

    private void Update()
    {
        CheckForInput();
    }

    /// <summary>
    /// Initializes the turn order so that the system can work with non null data
    /// </summary>
    private void InitializeTurnOrder()
    {
        currentPlayerTurnOrder = ReturnInitialTurnOrder(); //Return Initialize Player Order (0, 1, 2, 3)
        previousPlayerTurnOrder = new List<PlayerInfo>(currentPlayerTurnOrder); //Deep copy the list into another holder so that you don't lose reference if you modified the current player order

        previousPlayerJudge = currentPlayerTurnOrder[Random.Range(0, totalPlayerCount)]; //Randomly choose a judge from current turn order
    }
    
    /// <summary>
    /// Basic Input Check on each frame
    /// </summary>
    private void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetNewTurnOrder();
        }
    }

    /// <summary>
    /// This function establishes a new turn order
    /// </summary>
    private void SetNewTurnOrder()
    {
        previousPlayerJudge = currentPlayerJudge; //Set the previous judge to the round current judge before turn calculation
        
        List<PlayerInfo> newTurnOrder = ReturnShuffledTurnOrder(previousPlayerTurnOrder, previousPlayerJudge); //Return a shuffled turn order

        while (CheckIfPlayerIsJudgingTwice(newTurnOrder, previousPlayerJudge)) //If the returned shuffled turn order is invalid (the judge is the same), recalculate. Keep doing this until you find a good dataset. Be careful with while loops though, can crash your program if not handled correctly.
        {
            Debug.Log("Turn Order Recalculating"); //<TO BE REMOVED> Remove this before standalone, debug calls are mucho expensive
            
            newTurnOrder = ReturnShuffledTurnOrder(previousPlayerTurnOrder, previousPlayerJudge); //If the turn order is invalid, try again
        }

        previousPlayerTurnOrder = new List<PlayerInfo>(currentPlayerTurnOrder); //Set the previous turn order to the turn before calculation
        
        currentPlayerTurnOrder = newTurnOrder; //At this point the turn order is valid, apply it to the current turn order
        currentPlayerJudge = newTurnOrder[totalPlayerCount - 1]; //Always set the judge to be the players last added to the turn order
    }

    /// <summary>
    /// Returns a list of PlayerInfo of players 0 through n, with their ID and names initialized
    /// </summary>
    /// <returns></returns>
    private List<PlayerInfo> ReturnInitialTurnOrder()
    {
        List<PlayerInfo> newInitializedTurnOrder = new List<PlayerInfo>(totalPlayerCount); //Create a new empty list initialized at total player size

        for (int i = 0; i < totalPlayerCount; i++)
        {
            newInitializedTurnOrder.Add(new PlayerInfo("Player " + i, i, false, false)); //Loop over the list, adding a new PlayerInfo element with an ID and player name
        }

        return newInitializedTurnOrder;
    }

    /// <summary>
    /// Returns a shuffled turn order using Random.Range
    /// </summary>
    /// <param name="previousTurnOrder"></param>
    /// <param name="previousJudge"></param>
    /// <returns></returns>
    private List<PlayerInfo> ReturnShuffledTurnOrder(List<PlayerInfo> previousTurnOrder, PlayerInfo previousJudge)
    {
        List<PlayerInfo> newShuffledTurnOrder = new List<PlayerInfo>(totalPlayerCount); //Create a new empty list initialized at total player size
        List<PlayerInfo> availablePlayers = new List<PlayerInfo>(previousTurnOrder); //Create a new list that holds the available players to choose from

        for (int i = 0; i < totalPlayerCount; i++) //Loop over every player
        {
            int randomID = Random.Range(0, availablePlayers.Count); //Choose a random int between 0, and n

            PlayerInfo randomPlayer = availablePlayers[randomID]; //Return a player at the random index calculated above
            
            newShuffledTurnOrder.Add(randomPlayer); //Add this player to the turn order
            availablePlayers.Remove(randomPlayer); //Remove this player from the available players to choose from
        }

        return newShuffledTurnOrder;
    }

    /// <summary>
    /// Checks if the new turn order is valid (same judge twice)
    /// </summary>
    /// <param name="newTurnOrder"></param>
    /// <param name="previousJudge"></param>
    /// <returns></returns>
    private bool CheckIfPlayerIsJudgingTwice(List<PlayerInfo> newTurnOrder, PlayerInfo previousJudge)
    {
        if (newTurnOrder[totalPlayerCount - 1].playerID == previousJudge.playerID) //If the player ID (int) is the same as last turn's judge, return true meaning the judge is the same
        {
            return true;
        }
        
        return false;
    }

    public PlayerInfo ReturnPlayerWhoIsCurrentlyPlaying()
    {
        PlayerInfo currentPlayer = new PlayerInfo();
        for (int i = 0; i < currentPlayerTurnOrder.Count; i++)
        {
            if (currentPlayerTurnOrder[i].isPlaying)
            {
                currentPlayer = currentPlayerTurnOrder[i];
            }
        }

        return currentPlayer;
    }

}

[System.Serializable]
public struct PlayerInfo //A structure holding the info about each player, including their ID and name
{
    [Header("Player Info Attributes")]
    public string playerName;
    
    [Space(10)]
    public int playerID;

    [Space(10)]
    public bool isPlaying;
    public bool isJudge;

    public PlayerInfo(string newPlayerName, int newPlayerID, bool playing, bool judge)
    {
        this.playerName = newPlayerName;
        this.playerID = newPlayerID;
        this.isPlaying = playing;
        this.isJudge = judge;
    }
}