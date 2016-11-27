using UnityEngine;
using System.Collections;

public class InGameUIManager : GuiPanel 
{
	#region Fields

    public CardConfirmationPanel PlayerCardConfirmationPanel;
    public CardDeckUIElement PlayerCardDeck;
    public BattleFieldUIManager PlayerBattleFieldUIManager;
    public CardUIElement PlayerCardConfirmationPanelUI; 
    //public GameObject PlayerPanel;

    public CardConfirmationPanel EnemyCardConfirmationPanel;
    public CardDeckUIElement EnemyCardDeck;
    public BattleFieldUIManager EnemyBattleFieldUIManager;
    public CardUIElement EnemyCardConfirmationPanelUI; 

    #endregion //Fields
	
	#region Unity Methods
	
	private void Awake () 
	{
		Initialize();
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
    }

    private void EnemyElementsInit()
    {
        EnemyCardDeck.Initialize(this);
        EnemyCardConfirmationPanel.Initialize(this);
        EnemyCardConfirmationPanelUI.Initialize(this);
        EnemyBattleFieldUIManager.Initialize(this);
        EnemyCardConfirmationPanel.OnAgentCardConfirmated += EnemyCardConfirmationPanel_OnAgentCardConfirmated;
    }

	#endregion // Public Methods

    #region Events

    private void CardConfirmationPanel_OnCardConfimated(int index)
    {
        PlayerCardDeck.RemoveAtCardDeck(index);
    }

    private void EnemyCardConfirmationPanel_OnAgentCardConfirmated(int index)
    {
        Debug.Log("Agent Card ConfirmationPanel");
        EnemyCardDeck.RemoveAtCardDeck(index);
    }

    #endregion // Events
}
