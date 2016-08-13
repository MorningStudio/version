/************************************************/
//本代码自动生成，切勿手动修改
/************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Proto
{
   /// <summary>
    /// 防御类型
    /// </summary>
    public enum DefanceType
    {
        /// <summary>
        /// 普通
        /// </summary>
        Normal=0,
        /// <summary>
        /// 盾牌
        /// </summary>
        Shield=1,
        /// <summary>
        /// 重甲
        /// </summary>
        Armored=2,

    }
   /// <summary>
    /// 种族类型
    /// </summary>
    public enum HeroCategory
    {
        /// <summary>
        /// 力量
        /// </summary>
        Force=0,
        /// <summary>
        /// 智力
        /// </summary>
        Knowledge=1,
        /// <summary>
        /// 敏捷
        /// </summary>
        Agility=2,

    }
   /// <summary>
    /// 伤害类型
    /// </summary>
    public enum DamageType
    {
        /// <summary>
        /// 混乱
        /// </summary>
        Confusion=0,
        /// <summary>
        /// 物理
        /// </summary>
        Physical=1,
        /// <summary>
        /// 魔法
        /// </summary>
        Magic=2,

    }
   /// <summary>
    /// 解锁条件
    /// </summary>
    public enum LevelUnlockType
    {
        /// <summary>
        /// 无需解锁
        /// </summary>
        None=0,
        /// <summary>
        /// 前置关卡
        /// </summary>
        NeedCompleteLevel=1,
        /// <summary>
        /// 需求道具
        /// </summary>
        NeedItem=2,
        /// <summary>
        /// 消耗道具
        /// </summary>
        ConsumeItem=3,

    }
   /// <summary>
    /// 属性枚举
    /// </summary>
    public enum HeroPropertyType
    {
        /// <summary>
        /// 防御
        /// </summary>
        Defance=1,
        /// <summary>
        /// 伤害
        /// </summary>
        DamageMin=2,
        /// <summary>
        /// 伤害大
        /// </summary>
        DamageMax=3,
        /// <summary>
        /// HP
        /// </summary>
        MaxHP=4,
        /// <summary>
        /// 魔法上限
        /// </summary>
        MaxMP=5,
        /// <summary>
        /// 力量
        /// </summary>
        Force=6,
        /// <summary>
        /// 智慧
        /// </summary>
        Knowledge=7,
        /// <summary>
        /// 敏捷
        /// </summary>
        Agility=8,
        /// <summary>
        /// 闪避
        /// </summary>
        Jouk=9,
        /// <summary>
        /// 暴击
        /// </summary>
        Crt=10,
        /// <summary>
        /// 命中
        /// </summary>
        Hit=11,
        /// <summary>
        /// 魔法躲避
        /// </summary>
        Resistibility=12,
        /// <summary>
        /// 普通攻击间隔时间
        /// </summary>
        MagicWaitTime=13,

    }
   /// <summary>
    /// 行为锁
    /// </summary>
    public enum ActionLockType
    {
        /// <summary>
        /// 禁止释放主动技能
        /// </summary>
        NOSKILL=1,
        /// <summary>
        /// 禁止移动
        /// </summary>
        NOMOVE=2,
        /// <summary>
        /// 禁止攻击
        /// </summary>
        NOATTACK=4,

    }
}