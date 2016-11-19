using UnityEngine;
using System;
using System.Collections;

public class CardConfirmationPanel : GuiPanel 
{
	#region Fields

    public CardUIElement mCardUIElement;
    public event Action<int> OnCardConfimated;

	#endregion //Fields
	
	#region Public Methods

	public override void Initialize(InGameUIManager inGameUIManager)
	{
        base.Initialize(inGameUIManager);
        mCardUIElement = this.GetComponent<CardUIElement>();
        OnCardConfimated += CardConfirmationPanel_OnCardConfimated;
	}

    void CardConfirmationPanel_OnCardConfimated(int obj)
    {
        //  
    }

    public void SetCardData(Card data, int index)
    {
        mCardUIElement.SetCardProperties(data, index);
    }

	#endregion // Public Methods

    #region Events

    /// <summary>
    /// Bind button click event to Button_PutBattlefield
    /// </summary>
    public void OnCardConfirmatedClicked()
    {

        OnCardConfimated(mCardUIElement.Index);
    }

    #endregion // Events
}
