using UnityEngine;
using System.Collections;
using UnityEditor;
using CardGameTypes;
using System.IO;
using System;

public class CardEditor : EditorWindow
{
    #region Fields

    public static ClassType selectedClass;
    public static CardType selectedCard;
           
    public static SpecialCard specialCard = new SpecialCard();
    public static WeaponCard  weaponCard = new WeaponCard();
    public static MinionCard  minionCard = new MinionCard();
    public static NeutralCard neutralCard = new NeutralCard();

    public static string Path;

    #endregion // Fields

    #region Methods

    [MenuItem("CardEditor/CreateCard")]
    public static void ShowEditor()
    {
        EditorWindow.GetWindow(typeof(CardEditor));
        Initialize();
    }

    public static void Initialize()
    {
        InitCard();
        Debug.Log(Application.persistentDataPath);
        Debug.Log(Application.dataPath);
        Debug.Log(Application.streamingAssetsPath);
        Debug.Log(Application.temporaryCachePath);
    }

    public void OnGUI()
    {
        GUILayout.Label("Create Card");
        selectedClass = (ClassType)EditorGUILayout.EnumPopup("Select Your Class : ", selectedClass);
        selectedCard = (CardType)EditorGUILayout.EnumPopup("Select Your Card Type : ", selectedCard);
        GUILayout.Label(selectedCard.ToString());
        
        switch (selectedCard)
        {
            case CardType.Weapon:
                weaponCard.Name            = EditorGUILayout.TextField("Name : ", weaponCard.Name);
                weaponCard.HP              = EditorGUILayout.IntField("HP : ", weaponCard.HP);
                weaponCard.AttackDamage    = EditorGUILayout.IntField("Attack Damage : ", weaponCard.AttackDamage);
                weaponCard.ManaCost        = EditorGUILayout.IntField("Mana Cost : ", weaponCard.ManaCost);
                weaponCard.Description     = EditorGUILayout.TextField("Description : ", weaponCard.Description);
                weaponCard.Owner           = (ClassType)selectedClass;
                weaponCard.SelectedPower   = (WeaponPowerType)EditorGUILayout.EnumPopup("Power : ", weaponCard.SelectedPower);
                break;
            case CardType.Minion:
                minionCard.Name            = EditorGUILayout.TextField("Name : ", minionCard.Name);
                minionCard.HP              = EditorGUILayout.IntField("HP : ", minionCard.HP);
                minionCard.AttackDamage    = EditorGUILayout.IntField("Attack Damage : ", minionCard.AttackDamage);
                minionCard.ManaCost        = EditorGUILayout.IntField("Mana Cost : ", minionCard.ManaCost);
                minionCard.Description     = EditorGUILayout.TextField("Description : ", minionCard.Description);
                minionCard.SelectedPower   = (MinionPowerType)EditorGUILayout.EnumPopup("Power : ", minionCard.SelectedPower);
                minionCard.Owner           = (ClassType)selectedClass;
                break;
            case CardType.Special:
                specialCard.Name           = EditorGUILayout.TextField("Name : ", specialCard.Name);
                specialCard.HP             = EditorGUILayout.IntField("HP : ", specialCard.HP);
                specialCard.AttackDamage   = EditorGUILayout.IntField("Attack Damage : ", specialCard.AttackDamage);
                specialCard.ManaCost       = EditorGUILayout.IntField("Mana Cost : ", specialCard.ManaCost);
                specialCard.Description    = EditorGUILayout.TextField("Description : ", specialCard.Description);
                specialCard.SelectedPower  = (SpecialPowerType)EditorGUILayout.EnumPopup("Power : ", specialCard.SelectedPower);
                specialCard.Owner          = (ClassType)selectedClass;
                break;
            case CardType.Neutral:
                neutralCard.Name           = EditorGUILayout.TextField("Name : ", neutralCard.Name);
                neutralCard.HP             = EditorGUILayout.IntField("HP : ", neutralCard.HP);
                neutralCard.AttackDamage   = EditorGUILayout.IntField("Attack Damage : ", neutralCard.AttackDamage);
                neutralCard.ManaCost       = EditorGUILayout.IntField("Mana Cost : ", neutralCard.ManaCost);
                neutralCard.Description    = EditorGUILayout.TextField("Description : ", neutralCard.Description);
                neutralCard.SelectedPower  = (NeutralPowerType)EditorGUILayout.EnumPopup("Power : ", neutralCard.SelectedPower);
                neutralCard.Owner          = (ClassType)selectedClass;
                break;
        }

        if (GUILayout.Button("Save"))
        {
            SaveCard();
            InitCard();
            Debug.Log("Success");
        }

    }

    public static void InitCard()
    {
        specialCard = ScriptableObject.CreateInstance<SpecialCard>();
        minionCard = ScriptableObject.CreateInstance<MinionCard>();
        weaponCard = ScriptableObject.CreateInstance<WeaponCard>();
        neutralCard = ScriptableObject.CreateInstance<NeutralCard>();
    }

    public void SaveCard()
    {
        switch (selectedCard)
        {
            case CardType.Weapon:
              Debug.Log( System.String.Format
                    ("Name : {0} HP : {1} , Attack Damage : {2} , ManaCost : {3} , SelectedPower : {4} , Owner : {5} ",
                    weaponCard.Name, weaponCard.HP, weaponCard.AttackDamage, weaponCard.ManaCost, weaponCard.SelectedPower, weaponCard.Owner));
              CreateLevelAsset(weaponCard.Name, weaponCard);
              SetCardDeck();
                break;
            case CardType.Minion:
              Debug.Log( System.String.Format
                    ("Name : {0} HP : {1} , Attack Damage : {2} , ManaCost : {3} , SelectedPower : {4} , Owner : {5} ",
                    minionCard.Name, minionCard.HP, minionCard.AttackDamage, minionCard.ManaCost, minionCard.SelectedPower, minionCard.Owner));
                    
              CreateLevelAsset(minionCard.Name, minionCard);
                break;
            case CardType.Special:
              Debug.Log( System.String.Format
                    ("Name : {0} HP : {1} , Attack Damage : {2} , ManaCost : {3} , SelectedPower : {4} , Owner : {5} ",
                    specialCard.Name, specialCard.HP, specialCard.AttackDamage, specialCard.ManaCost, specialCard.SelectedPower, specialCard.Owner));

              CreateLevelAsset(specialCard.Name, specialCard);
                break;
        }
    }

    public void CreateLevelAsset(string name, Card card)
    {
        Path = "Assets/Classes/" + selectedClass + "/" + selectedCard + "/" + name + ".asset";
        EditorUtility.SetDirty(card);
        AssetDatabase.CreateAsset(card, Path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
    }

    public void SetCardDeck()
    {
        //CardDeck.AssasinWeapon.Add("Mahmut", weaponCard);
    }

    #endregion // Methods
}

/*
 * Note
 * Debug.Log(Application.persistentDataPath);
 * Debug.Log(Application.dataPath);
 * Debug.Log(Application.streamingAssetsPath);
*/