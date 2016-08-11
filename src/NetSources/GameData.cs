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
    /// 
    /// </summary>
    public class Vector3 : Proto.ISerializerable
    {
        public Vector3()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public float x { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public float y { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public float z { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            x = reader.ReadSingle();
            y = reader.ReadSingle();
            z = reader.ReadSingle();
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(x);
            writer.Write(y);
            writer.Write(z);
            
        }

    }
    /// <summary>
    /// 游戏服务器信息
    /// </summary>
    public class GameServerInfo : Proto.ISerializerable
    {
        public GameServerInfo()
        {
            Host = string.Empty;

        }
        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { set; get; }
        /// <summary>
        /// 主机端口
        /// </summary>
        public int Port { set; get; }
        /// <summary>
        /// 服务器ID
        /// </summary>
        public int ServerID { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            Host = Encoding.UTF8.GetString(reader.ReadBytes( reader.ReadInt32()));
            Port = reader.ReadInt32();
            ServerID = reader.ReadInt32();
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            var Host_bytes = Encoding.UTF8.GetBytes(Host==null?string.Empty:Host);writer.Write(Host_bytes.Length);writer.Write(Host_bytes);
            writer.Write(Port);
            writer.Write(ServerID);
            
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class WearEquip : Proto.ISerializerable
    {
        public WearEquip()
        {
            GUID = string.Empty;

        }
        /// <summary>
        /// 
        /// </summary>
        public int EquipID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string GUID { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            EquipID = reader.ReadInt32();
            GUID = Encoding.UTF8.GetString(reader.ReadBytes( reader.ReadInt32()));
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(EquipID);
            var GUID_bytes = Encoding.UTF8.GetBytes(GUID==null?string.Empty:GUID);writer.Write(GUID_bytes.Length);writer.Write(GUID_bytes);
            
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class HeroMagic : Proto.ISerializerable
    {
        public HeroMagic()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public int MagicKey { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            MagicKey = reader.ReadInt32();
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(MagicKey);
            
        }

    }
    /// <summary>
    /// 玩家角色
    /// </summary>
    public class DHero : Proto.ISerializerable
    {
        public DHero()
        {
            Equips = new List<WearEquip>();
            Magics = new List<HeroMagic>();

        }
        /// <summary>
        /// 配置ID
        /// </summary>
        public int HeroID { set; get; }
        /// <summary>
        /// 当前等级
        /// </summary>
        public int Level { set; get; }
        /// <summary>
        /// 当前经验
        /// </summary>
        public int Exprices { set; get; }
        /// <summary>
        /// 当前穿戴装备
        /// </summary>
        public List<WearEquip> Equips { set; get; }
        /// <summary>
        /// 英雄当前激活魔法
        /// </summary>
        public List<HeroMagic> Magics { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            HeroID = reader.ReadInt32();
            Level = reader.ReadInt32();
            Exprices = reader.ReadInt32();
            int Equips_Len = reader.ReadInt32();
            while(Equips_Len-->0)
            {
                WearEquip Equips_Temp = new WearEquip();
                Equips_Temp = new WearEquip();Equips_Temp.ParseFormBinary(reader);
                Equips.Add(Equips_Temp );
            }
            int Magics_Len = reader.ReadInt32();
            while(Magics_Len-->0)
            {
                HeroMagic Magics_Temp = new HeroMagic();
                Magics_Temp = new HeroMagic();Magics_Temp.ParseFormBinary(reader);
                Magics.Add(Magics_Temp );
            }
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(HeroID);
            writer.Write(Level);
            writer.Write(Exprices);
            writer.Write(Equips.Count);
            foreach(var i in Equips)
            {
                i.ToBinary(writer);               
            }
            writer.Write(Magics.Count);
            foreach(var i in Magics)
            {
                i.ToBinary(writer);               
            }
            
        }

    }
    /// <summary>
    /// 装备属性
    /// </summary>
    public class EquipProperty : Proto.ISerializerable
    {
        public EquipProperty()
        {

        }
        /// <summary>
        /// 属性类型
        /// </summary>
        public HeroPropertyType Property { set; get; }
        /// <summary>
        /// 属性值
        /// </summary>
        public int Value { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            Property = (HeroPropertyType)reader.ReadInt32();
            Value = reader.ReadInt32();
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write((int)Property);
            writer.Write(Value);
            
        }

    }
    /// <summary>
    /// 装备信息（道具附加养成）
    /// </summary>
    public class Equip : Proto.ISerializerable
    {
        public Equip()
        {
            GUID = string.Empty;
            Properties = new List<EquipProperty>();

        }
        /// <summary>
        /// 
        /// </summary>
        public string GUID { set; get; }
        /// <summary>
        /// 附加属性
        /// </summary>
        public List<EquipProperty> Properties { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            GUID = Encoding.UTF8.GetString(reader.ReadBytes( reader.ReadInt32()));
            int Properties_Len = reader.ReadInt32();
            while(Properties_Len-->0)
            {
                EquipProperty Properties_Temp = new EquipProperty();
                Properties_Temp = new EquipProperty();Properties_Temp.ParseFormBinary(reader);
                Properties.Add(Properties_Temp );
            }
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            var GUID_bytes = Encoding.UTF8.GetBytes(GUID==null?string.Empty:GUID);writer.Write(GUID_bytes.Length);writer.Write(GUID_bytes);
            writer.Write(Properties.Count);
            foreach(var i in Properties)
            {
                i.ToBinary(writer);               
            }
            
        }

    }
    /// <summary>
    /// 玩家道具
    /// </summary>
    public class PlayerItem : Proto.ISerializerable
    {
        public PlayerItem()
        {
            GUID = string.Empty;

        }
        /// <summary>
        /// 配置ID
        /// </summary>
        public int ItemID { set; get; }
        /// <summary>
        /// 拥有数量
        /// </summary>
        public int Num { set; get; }
        /// <summary>
        /// 唯一识别码
        /// </summary>
        public string GUID { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            ItemID = reader.ReadInt32();
            Num = reader.ReadInt32();
            GUID = Encoding.UTF8.GetString(reader.ReadBytes( reader.ReadInt32()));
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(ItemID);
            writer.Write(Num);
            var GUID_bytes = Encoding.UTF8.GetBytes(GUID==null?string.Empty:GUID);writer.Write(GUID_bytes.Length);writer.Write(GUID_bytes);
            
        }

    }
    /// <summary>
    /// 玩家背包
    /// </summary>
    public class PlayerPackage : Proto.ISerializerable
    {
        public PlayerPackage()
        {
            Items = new List<PlayerItem>();
            Equips = new List<Equip>();

        }
        /// <summary>
        /// 道具列表
        /// </summary>
        public List<PlayerItem> Items { set; get; }
        /// <summary>
        /// 背包上限
        /// </summary>
        public int MaxSize { set; get; }
        /// <summary>
        /// 装备
        /// </summary>
        public List<Equip> Equips { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            int Items_Len = reader.ReadInt32();
            while(Items_Len-->0)
            {
                PlayerItem Items_Temp = new PlayerItem();
                Items_Temp = new PlayerItem();Items_Temp.ParseFormBinary(reader);
                Items.Add(Items_Temp );
            }
            MaxSize = reader.ReadInt32();
            int Equips_Len = reader.ReadInt32();
            while(Equips_Len-->0)
            {
                Equip Equips_Temp = new Equip();
                Equips_Temp = new Equip();Equips_Temp.ParseFormBinary(reader);
                Equips.Add(Equips_Temp );
            }
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(Items.Count);
            foreach(var i in Items)
            {
                i.ToBinary(writer);               
            }
            writer.Write(MaxSize);
            writer.Write(Equips.Count);
            foreach(var i in Equips)
            {
                i.ToBinary(writer);               
            }
            
        }

    }
    /// <summary>
    /// 用户服务器映射
    /// </summary>
    public class PlayerServerInfo : Proto.ISerializerable
    {
        public PlayerServerInfo()
        {

        }
        /// <summary>
        /// 玩家ID
        /// </summary>
        public long UserID { set; get; }
        /// <summary>
        /// 所在服务器
        /// </summary>
        public int ServerID { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            UserID = reader.ReadInt64();
            ServerID = reader.ReadInt32();
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write(UserID);
            writer.Write(ServerID);
            
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class HeroProperty : Proto.ISerializerable
    {
        public HeroProperty()
        {

        }
        /// <summary>
        /// 属性
        /// </summary>
        public HeroPropertyType Property { set; get; }
        /// <summary>
        /// 值
        /// </summary>
        public int Value { set; get; }

        public void ParseFormBinary(BinaryReader reader)
        {
            Property = (HeroPropertyType)reader.ReadInt32();
            Value = reader.ReadInt32();
             
        }

        public void ToBinary(BinaryWriter writer)
        {
            writer.Write((int)Property);
            writer.Write(Value);
            
        }

    }
}