using UnityEngine;

public enum SkillUpgradeType
{
    None,
    //--------Dash Tree--------
    Dash,
    Dash_CloneOnStart,
    Dash_CloneOnStartAndArrival,
    Dash_ShardOnStart,
    Dash_ShardOnStartAndArrival,

    //-----------Shard Tree---------
    Shard,
    Shard_MoveToEnemy,
    Shard_Multicast,
    Shard_Teleport,
    Shard_TeleportHpRewind,

    //--------Shard Tree--------
    SwordThrow,
    SwordThrow_Spin,
    SwordThrow_Pierce,
    SwordThrow_Bounce,

    //--------Time Echo Tree--------
    TimeEcho,
    TimeEcho_SingleAttack,
    TimeEcho_MultiAttack,
    TimeEcho_ChanceToDuplicate,

    TimeEcho_HealWisp,

    TimeEcho_CleanseWisp,
    TimeEcho_CooldownWisp,

    //---------Domain Expansion----------
    Domain_SlowingDown,
    Domain_EchoSpam,
    Domain_ShardSpam
}
