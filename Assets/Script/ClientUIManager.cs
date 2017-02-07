using UnityEngine;
using System.Collections;
using CardGameTypes;
using UnityEngine.SceneManagement;

public class ClientUIManager : MonoBehaviour 
{
	#region Fields

    public SceneDataManager SceneDataManager;

	#endregion //Fields
	
	#region Unity Methods
	
	private void Start () 
	{
		Initalize();
	}
	
	private void Update () 
	{
	
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initalize()
	{
	
	}
	
	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods

    #region Events

    public void OnSelectPlayerClassButtonClicked(int value)
    {
        SceneDataManager.SelectedPlayerClassType = (ClassType)value;
    }

    public void OnSelectEnemyClassButtonClicked(int value)
    {
        SceneDataManager.SelectedEnemyClassType = (ClassType)value;
    }

    public void OnRedirectGameSceneClicked()
    {
        SceneManager.LoadScene("BaseScene");    
    }

    #endregion // Events
}
