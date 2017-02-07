using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CardGameTypes;

public class GameManager : MonoBehaviour 
{
	#region Fields

    public InGameUIManager IngameUIManager;

    public CardDeck PlayerCardDeck;
    public CardDeck EnemyCardDeck;

    public NumberUIElement PlayerHealth;
    public NumberUIElement EnemyHealth;

    public SceneDataManager DataManager;
    public Sprite[] PlayerSprite;

    public GameObject Player;
    public GameObject Enemy;

    public ClassType PlayerClassType;
    public ClassType EnemyClassType;

    public List<Card> PlayerCards;
    public List<Card> EnemyCards;

    public PlayerClass PlayerManager;
    public AiClass EnemyManager;

	#endregion //Fields
	
	#region Unity Methods
	
	private void Start () 
	{
		Initalize();
	}
	
	private void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DrawCard(PlayerType.Player);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DrawCard(PlayerType.Enemy);
        }
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initalize()
	{
        DataManager = GameObject.Find("SceneDataManager").GetComponent<SceneDataManager>();
        InitPlayerClass(DataManager.SelectedPlayerClassType);
        InitEnemyClass(EnemyClassType);
        StartGame();
	}

    public void StartGame()
    {
        if (PlayerManager.IsInitedInitialize && EnemyManager.IsInitedInitialize)
        {
            float random = Random.Range(0.0f,1.0f);

            Debug.Log(random);

            if (random < 0.5f)
            {

            }
            else
            {
                IngameUIManager.TurnTextObject.SetActive(true);
                Debug.Log("Enemy");
            }
        }
        else
        {
            StartGame();
        }
    }

    public void MatchingMinion(Card p1 , Card p2)
    {
        int finalp1Hp = p1.HP - p2.AttackDamage;
        int finalp2Hp = p2.HP - p1.AttackDamage;

        if (p1.HP <= p2.AttackDamage)
        {
            IngameUIManager.PlayerBattleFieldUIManager.DestroyMinion();
            // p1 death
        }
        else
        {
            IngameUIManager.PlayerBattleFieldUIManager.DecraseHealthMinion(finalp1Hp);
            // p1 health decreased 
        }

        if (p2.HP <= p1.AttackDamage)
        {
            IngameUIManager.EnemyBattleFieldUIManager.DestroyMinion();
            // p2 death
        }
        else
        {
            IngameUIManager.EnemyBattleFieldUIManager.DecraseHealthMinion(finalp2Hp);
            // p2 health decreased 
        }

        Debug.Log("Matching");
    }

    public void DecreaseAgent(int attackDamage)
    {
        int remainderHP = EnemyManager.HP - attackDamage;

        if (remainderHP > 0)
        {
            EnemyHealth.SetNumberImage(remainderHP);
            EnemyManager.HP = remainderHP;
        }
        else
        {
            return;
            // Burada öldür lose ekranı gelsin.
        }
    }

    public void DecreasePlayer(int attackDamage)
    {
        int remainderHP = PlayerManager.HP - attackDamage;

        if (remainderHP > 0)
        {
            PlayerHealth.SetNumberImage(remainderHP);
            PlayerManager.HP = remainderHP;
        }
        else
        {
            return;
            // Burada öldür win ekranı gelsin.
        }
    }

    public void OnDrawPlayerCardTestButtonClicked()
    {
        DrawCard(PlayerType.Player);
    }

    public void OnDrawEnemyCardTestButtonClicked()
    {
        DrawCard(PlayerType.Enemy);
    }

	#endregion // Public Methods
	
	#region Private Methods

    private void InitPlayerClass(ClassType type)
    {
        switch (type)
        {
            case ClassType.Magic:
                PlayerManager = Player.AddComponent<MagicClass>();
                PlayerCards = PlayerCardDeck.MagicCards;
                PlayerManager.CardConfirmationPanel = IngameUIManager.PlayerCardConfirmationPanel;
                PlayerManager.HP = 10;
                PlayerHealth.SetNumberImage(10);
                PlayerManager.Initialize();
                break;
            //case ClassType.Hunter:
            //    PlayerManager = Player.AddComponent<HunterClass>();
            //    PlayerManager.CardConfirmationPanel = IngameUIManager.CardConfirmationPanel;
            //    PlayerCards = CardDeck.HunterCards;
            //    break;
            //case ClassType.Warrior:
            //    PlayerManager = Player.AddComponent<WarriorClass>();
            //    PlayerManager.CardConfirmationPanel = IngameUIManager.CardConfirmationPanel;
            //    PlayerCards = CardDeck.WarriorCards;
            //    break;
        }
    }

    private void InitEnemyClass(ClassType type)
    {
        switch (type)
        {
            case ClassType.Magic:
                EnemyManager = Enemy.AddComponent<AiMagicClass>();
                EnemyCards = EnemyCardDeck.MagicCards;
                EnemyManager.CardConfirmationPanel = IngameUIManager.EnemyCardConfirmationPanel;
                EnemyManager.HP = 10;
                EnemyHealth.SetNumberImage(10);
                EnemyManager.Initialize();
                break;
            //case ClassType.Hunter:
            //    EnemyManager = Player.AddComponent<HunterClass>();
            //    PlayerManager.CardConfirmationPanel = IngameUIManager.CardConfirmationPanel;
            //    EnemyCards = CardDeck.HunterCards;
            //    break;
            //case ClassType.Warrior:
            //    PlayerManager = Player.AddComponent<WarriorClass>();
            //    PlayerManager.CardConfirmationPanel = IngameUIManager.CardConfirmationPanel;
            //    PlayerCards = CardDeck.WarriorCards;
            //    break;
        }
    }

    private void DrawCard(PlayerType type)
    {
        switch (type)
        {
            case PlayerType.Player:
                if (PlayerCards.Count != 0)
                {
                    int playerRandomNumber = Random.Range(0, PlayerCards.Count);
                    Card playerCardData = PlayerCards[playerRandomNumber];
                    PlayerManager.SetCard(playerCardData);
                    PlayerCards.RemoveAt(playerRandomNumber);
                }
                //else
                //    Debug.Log("Empty card deck!");
                break;
            case PlayerType.Enemy:
                if (EnemyCards.Count != 0)
                {
                    int enemyRandomNumber = Random.Range(0, EnemyCards.Count);
                    Card enemyCardData = EnemyCards[enemyRandomNumber];
                    EnemyManager.SetCard(enemyCardData);
                    EnemyCards.RemoveAt(enemyRandomNumber);
                }
                //else
                //    Debug.Log("Empty card deck!");
                break;
        }
    }

	#endregion //Private Methods

    #region Events
    /// <summary>
    /// Bu methodları şuan da kullanmıyorum gerekmezse eğer silinebilir.
    /// </summary>
    private void PlayerManager_FinishedInitialize()
    {

    }

    private void EnemyManager_FinishedInitialize()
    {

    }

    #endregion // Events
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