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

    void CardConfirmationPanel_OnCardConfimated(int index)
    {
        Debug.Log("Confirmated Play");
        PlayerCardDeck.RemoveAtCardDeck(index);
    }

    private void PlayerElementsInit()
    {
        PlayerCardDeck.Initialize(this);
        PlayerCardConfirmationPanel.Initialize(this);
        PlayerCardConfirmationPanelUI.Initialize(this);
        PlayerBattleFieldUIManager.Initialize(this);
        PlayerCardConfirmationPanel.OnCardConfimated += CardConfirmationPanel_OnCardConfimated;
    }

    private void EnemyElementsInit()
    {
        EnemyCardDeck.Initialize(this);
        EnemyCardConfirmationPanel.Initialize(this);
        EnemyCardConfirmationPanelUI.Initialize(this);
        EnemyBattleFieldUIManager.Initialize(this);
        EnemyCardConfirmationPanel.OnCardConfimated += CardConfirmationPanel_OnCardConfimated;
    }

	#endregion // Public Methods
}
