using UnityEngine;
using System.Collections;
using CardGameTypes;

public class SceneDataManager : MonoBehaviour 
{
	#region Fields

    public ClassType SelectedPlayerClassType;
    public ClassType SelectedEnemyClassType;

	#endregion //Fields
	
	#region Unity Methods
	
	private void Awake () 
	{
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion // Uniy Methods
}


// Bu Script Scene ler arası yok olmıyacak.
// Class seçimini gamemanager bundan alıcak.