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
    /// 每个版本号最大 99
    /// </summary>
    public enum GameVersion
    {
        /// <summary>
        /// 主要版本
        /// </summary>
        Master=1,
        /// <summary>
        /// 更新版本
        /// </summary>
        Major=0,
        /// <summary>
        /// 开发版本
        /// </summary>
        Develop=1,

    }
   /// <summary>
    /// 错误码 考虑平台问题 不要尝试串码
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 协议版本异常
        /// </summary>
        VersionError=1,
        /// <summary>
        /// 通用错误
        /// </summary>
        Error=0,
        /// <summary>
        /// 处理成功
        /// </summary>
        OK=1,
        /// <summary>
        /// 登陆失败
        /// </summary>
        LoginFailure=2,
        /// <summary>
        /// 用户名重复
        /// </summary>
        RegExistUserName=3,
        /// <summary>
        /// 输入为空
        /// </summary>
        RegInputEmptyOrNull=4,
        /// <summary>
        /// 没有游戏角色信息
        /// </summary>
        NoGamePlayerData=5,
        /// <summary>
        /// 英雄数据异常
        /// </summary>
        NoHeroInfo=6,

    }
}