using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberUIElement : MonoBehaviour 
{
	#region Fields

    public Image Image;
    public Sprite[] Numbers; // 1-13

	#endregion //Fields
	
	#region Public Methods
	
    public void SetNumberImage(int number)
    {
        Image.enabled = true;

        if (number != 0)
            Image.sprite = Numbers[number - 1];
        else
            Image.enabled = false;
    }

	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods
}
// Asla bir initialize olmasın.!