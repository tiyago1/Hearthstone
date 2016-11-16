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
	}

	#endregion // Public Methods
}
