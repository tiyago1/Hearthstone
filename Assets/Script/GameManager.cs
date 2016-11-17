using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CardGameTypes;

public class GameManager : MonoBehaviour 
{
	#region Fields

    public CardDeck CardDeck;

    public Sprite[] PlayerSprite;

    public GameObject Player;
    public GameObject Enemy;

    public ClassType PlayerClassType = ClassType.Magic;
    public ClassType EnemyClassType;

    public List<Card> PlayerCards;
    public List<Card> EnemyCards;

    public PlayerClass PlayerManager;
    public PlayerClass EnemyManager;

	#endregion //Fields
	
	#region Unity Methods
	
	private void Start () 
	{
		Initalize();
	}
	
	private void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DrawCard(PlayerType.First);
        }
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initalize()
	{
        InitPlayerClass(PlayerClassType);
        InitEnemyClass(EnemyClassType);
	}

    public void OnDrawCardTestButtonClicked()
    {
        DrawCard(PlayerType.First);
    }

	#endregion // Public Methods
	
	#region Private Methods

    private void InitPlayerClass(ClassType type)
    {
        switch (type)
        {
            case ClassType.Magic:
                PlayerManager = Player.AddComponent<MagicClass>();
                PlayerCards = CardDeck.MagicCards;           
                break;
            case ClassType.Hunter:
                PlayerManager = Player.AddComponent<HunterClass>();
                PlayerCards = CardDeck.HunterCards;
                break;
            case ClassType.Warrior:
                PlayerManager = Player.AddComponent<WarriorClass>();
                PlayerCards = CardDeck.WarriorCards;
                break;
        }
    }

    private void InitEnemyClass(ClassType type)
    {

    }

    private void DrawCard(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.First:
                if (PlayerCards.Count != 0)
                {
                    int firstsNumber = Random.Range(0, PlayerCards.Count);
                    Card firstsCard = PlayerCards[firstsNumber];
                    PlayerManager.SetCard(firstsCard);
                    PlayerCards.RemoveAt(firstsNumber);
                }
                else
                    Debug.Log("Empty card deck!");
                break;
            case PlayerType.Second:
                break;
        }
    }

	#endregion //Private Methods
}

/*
            case ClassType.Magic:
                MagicClass magicClass = Player.AddComponent<MagicClass>();
                magicClass.Cards = CardDeck.MagicCards;           
                break;
            case ClassType.Hunter:
                HunterClass hunterClass = Player.AddComponent<HunterClass>();
                hunterClass.Cards = CardDeck.HunterCards;
                break;
            case ClassType.Warrior:
                WarriorClass warriorClass = Player.AddComponent<WarriorClass>();
                warriorClass.Cards = CardDeck.WarriorCards;
                break;
*/