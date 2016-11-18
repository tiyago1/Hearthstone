using UnityEngine;
using System.Collections;

public class InGameUIManager : GuiPanel 
{
	#region Fields

    public CardConfirmationPanel CardConfirmationPanel;
    public CardDeckUIElement PlayerCardDeck;
    //public GameObject PlayerPanel;
    public CardUIElement ConfirmCardPanel;
    private Card mData;

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
        PlayerCardDeck.Initialize(this);
        CardConfirmationPanel.Initialize(this);
        ConfirmCardPanel.Initialize(this);
        PlayerCardDeck.Initialize(this);
        CardConfirmationPanel.OnCardConfimated += CardConfirmationPanel_OnCardConfimated;
	}

    void CardConfirmationPanel_OnCardConfimated(int index)
    {
        Debug.Log("Confirmated Play");
        PlayerCardDeck.RemoveAtCardDeck(index);
        
    }

	#endregion // Public Methods
}
