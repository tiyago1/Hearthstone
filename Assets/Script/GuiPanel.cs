using UnityEngine;
using System.Collections;

public class GuiPanel : MonoBehaviour 
{
	#region Fields

    protected InGameUIManager mIngameUIManager;

	#endregion //Fields
		
	#region Public Methods
	
	public virtual void Initialize(InGameUIManager inGameUIManager)
	{
        mIngameUIManager = inGameUIManager;
	}
	
	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods
}
