using UnityEngine;
using System.Collections;

namespace CardGameTypes
{
    #region Types

    public enum ClassType
    {
        Magic,
        Hunter,
        Warrior
    }

    public enum CardType
    {
        Weapon,  // Heros add
        Minion,  // Use to BattleField 
        Special, // No Attack and No HP
        Neutral  // Partner cards
    }

    public enum PlayerType
    {
        Player, // Real player
        Enemy // Ai or Enemy
    }

    public enum WeaponPowerType
    {
        WeaponHard,
        WeaponMiddle,
    }

    public enum MinionPowerType
    {
        MinionHard,
        MinionMiddle
    }

    public enum SpecialPowerType
    {
        SpecialHard,
        SpecialMiddle
    }

    public enum NeutralPowerType
    {
        NeutralHard,
        NeutralMiddle
    }

    #endregion // Types

}
