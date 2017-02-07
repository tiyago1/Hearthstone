using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class InGameUIManager : HearthBehaviour 
{
	#region Fields

    public CardConfirmationPanel PlayerCardConfirmationPanel;
    public CardDeckUIElement PlayerCardDeck;
    public BattleFieldUI PlayerBattleFieldUIManager;
    public CardUIElement PlayerCardConfirmationPanelUI; 

    public CardConfirmationPanel EnemyCardConfirmationPanel;
    public CardDeckUIElement EnemyCardDeck;
    public BattleFieldUI EnemyBattleFieldUIManager;
    public CardUIElement EnemyCardConfirmationPanelUI;

    public GameManager GameManager;
    public GameObject AttackButtonObject;

    private bool IsPlayerSelected;
    private bool IsAgentSelected;

    private Card P1MinionData;
    private Card P2MinionData;

    private bool IsEnemyNotAMinion;
    private bool IsPlayerNotAMinion;

    public GameObject TurnTextObject;

    #endregion //Fields
	
	#region Unity Methods
	
	private void Awake () 
	{
		Initialize();
	}

    public void Update()
    {

    }

	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initialize()
	{
        base.Initialize(this);
        PlayerElementsInit();
        EnemyElementsInit();
	}

    private void PlayerElementsInit()
    {
        PlayerCardDeck.Initialize(this);
        PlayerCardConfirmationPanel.Initialize(this);
        PlayerCardConfirmationPanelUI.Initialize(this);
        PlayerBattleFieldUIManager.Initialize(this);
        PlayerCardConfirmationPanel.OnPlayerCardConfimated += CardConfirmationPanel_OnCardConfimated;
        PlayerBattleFieldUIManager.MinionSelected += PlayerBattleFieldUIManager_MinionSelected;
        PlayerBattleFieldUIManager.MinionDeselected += PlayerBattleFieldUIManager_MinionDeselected;
    }

    void PlayerBattleFieldUIManager_MinionSelected(Card data)
    {
        IsPlayerSelected = true;
        SetAttackButton();
        P1MinionData = data;

        if (EnemyBattleFieldUIManager.Minions.Count == 0)
        {
            IsEnemyNotAMinion = true;
            AttackButtonObject.SetActive(true);
        }
    }

    void PlayerBattleFieldUIManager_MinionDeselected()
    {
        IsPlayerSelected = false;
        P1MinionData = null;
        SetAttackButton();
    }


    private void EnemyElementsInit()
    {
        EnemyCardDeck.Initialize(this);
        EnemyCardConfirmationPanel.Initialize(this);
        EnemyCardConfirmationPanelUI.Initialize(this);
        EnemyBattleFieldUIManager.Initialize(this);
        EnemyCardConfirmationPanel.OnAgentCardConfirmated += EnemyCardConfirmationPanel_OnAgentCardConfirmated;
        EnemyBattleFieldUIManager.MinionSelected += EnemyBattleFieldUIManager_MinionSelected;
        EnemyBattleFieldUIManager.MinionDeselected += EnemyBattleFieldUIManager_MinionDeselected;
    }

    void EnemyBattleFieldUIManager_MinionSelected(Card data)
    {
        IsAgentSelected = true;
        P2MinionData = data;
        SetAttackButton();

        if (PlayerBattleFieldUIManager.Minions.Count == 0)
        {
            IsPlayerNotAMinion = true;
            AttackButtonObject.SetActive(true);
        }
    }

    void EnemyBattleFieldUIManager_MinionDeselected()
    {
        IsAgentSelected = false;
        P2MinionData = null;
        SetAttackButton();
    }

    public void SetAttackButton()
    {
        AttackButtonObject.SetActive(IsAgentSelected && IsPlayerSelected);
    }

	#endregion // Public Methods

    #region Events

    private void CardConfirmationPanel_OnCardConfimated(int index)
    {
        PlayerCardDeck.RemoveAtCardDeck(index);
    }

    private void EnemyCardConfirmationPanel_OnAgentCardConfirmated(int index)
    {
        EnemyCardDeck.RemoveAtCardDeck(index);
    }

    /// <summary>
    /// Button 
    /// </summary>
    public void OnAttackMinionClicked()
    {
        if (P1MinionData != null && P2MinionData != null)
        {
            GameManager.MatchingMinion(P1MinionData, P2MinionData);
        }
        else if(IsPlayerNotAMinion)
        {
            GameManager.DecreasePlayer(P2MinionData.AttackDamage);
            EnemyBattleFieldUIManager.BattleFieldMinionControllers.ForEach(it => it.mMinionAnimationStateController.Shrink());
            IsPlayerNotAMinion = false;
        }
        else if (IsEnemyNotAMinion)
        {
            GameManager.DecreaseAgent(P1MinionData.AttackDamage);
            PlayerBattleFieldUIManager.BattleFieldMinionControllers.ForEach(it => it.mMinionAnimationStateController.Shrink());
            IsEnemyNotAMinion = false;
        }

        AttackButtonObject.SetActive(false);
    }

    #endregion // Events
}
