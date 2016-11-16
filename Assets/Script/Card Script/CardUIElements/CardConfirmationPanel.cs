using UnityEngine;
using System.Collections;

public class CardConfirmationPanel : GuiPanel 
{
	#region Fields

    private CardUIElement mCardUIElement;

	#endregion //Fields
	
	#region Public Methods
	
	public void Initialize(InGameUIManager inGameUIManager)
	{
        base.Initialize(inGameUIManager);
        mCardUIElement = this.GetComponent<CardUIElement>();
	}

    public void SetCardData(Card data)
    {
        mCardUIElement.SetCardProperties(data);
    }

	#endregion // Public Methods

    #region Events

    /// <summary>
    /// Bind button click event to Button_PutBattlefield
    /// </summary>
    public void OnCardConfirmatedClicked()
    {

    }

    #endregion // Events
}
