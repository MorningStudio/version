﻿using EngineCore.Simulater;
using Layout.LayoutEffects;
using GameLogic.Game.AIBehaviorTree;
using System;
using System.Collections.Generic;
using Proto;
using GameLogic.Game.Perceptions;

namespace GameLogic.Game.Elements
{
	public class ReleaseHistory
	{
		public int MagicDataID;
		public float LastTime;
		public float CdTime;

		public bool IsCoolDown(float time)
		{
			return time > LastTime + CdTime;
		}

		public float TimeToCd(float time)
		{
			return Math.Max(0, (LastTime + CdTime) - time); 
		}
	}

	public class BattleCharacter:BattleElement<IBattleCharacter>
	{
		public BattleCharacter (int configID,GControllor controllor, IBattleCharacter view):base(controllor,view)
		{
			HP = 0;
			ConfigID = configID;
            var enums = Enum.GetValues(typeof(HeroPropertyType));
            foreach (var i in enums)
            {
                var pr = (HeroPropertyType)i;
                Properties.Add(pr, new ComplexValue());
            }
		}

        public HanlderEvent OnDead;
		public int ConfigID { private set; get; }
		private Dictionary<int, ReleaseHistory> _history = new Dictionary<int, ReleaseHistory>();
        private Dictionary<HeroPropertyType, ComplexValue> Properties = new Dictionary<HeroPropertyType, ComplexValue>();
        public HeroCategory Category { set; get; }
		public DefanceType TDefance{ set; get;}
		public DamageType TDamage{ set; get;}
        public int MaxHP
        {
            get
            {
                var hpMax = this[HeroPropertyType.MaxHP].FinalValue;
                return hpMax + (int)(this[HeroPropertyType.Force].FinalValue * BattleAlgorithm.FORCE_HP);
            }
        }
        public int MaxMP {
            get 
            {
                var maxMP = this[HeroPropertyType.MaxMP].FinalValue + (int)(this[HeroPropertyType.Knowledge].FinalValue * BattleAlgorithm.KNOWLEGDE_MP);
                return maxMP;
            }
        }
        public string Name { set; get; }
		public int TeamIndex{ set; get;}
		public int Level{ set; get;}

        public ComplexValue this[HeroPropertyType type]
        {
            get { return Properties[type]; }
        }


		private float _speed;
		public float Speed
        {
            set { _speed = value; View.SetSpeed(_speed); }
            get { return _speed; }
        }

		public int HP{ private set; get;} 

		public bool IsDeath{
			get
			{ 
				return HP == 0;
			}
		}

		public bool SubHP(int hp)
		{
			if (hp <= 0)
				return false;
			if (HP == 0)
				return true;
			HP -= hp;
			if (HP <= 0)
				HP = 0;
			var dead = HP == 0;//is dead
			if (dead) OnDeath();
            View.ShowHPChange(-hp,HP,this.MaxHP);
			return dead;
		}

		public void AddHP(int hp)
		{
            var maxHP = MaxHP;
			if (hp <= 0)
				return;
            if (HP >= maxHP)
				return;
			HP += hp;
			if (HP >=maxHP)
				HP = maxHP;
            View.ShowHPChange(hp,HP, maxHP);
		}


        public AITreeRoot AIRoot { private set; get; }

        public void SetAITree(AITreeRoot root)
        {
            AIRoot = root;
        }

		internal void Init()
		{
            HP = MaxHP;
			_history.Clear();
		}

		protected void OnDeath()
		{
			View.Death();
            if (OnDead != null)
                OnDead(this);
            var per = this.Controllor.Perception as BattlePerception;
            per.StopAllReleaserByCharacter(this);
			Destory(this, 5.5f);
		}


		public void AttachMagicHistory(int magicID, float now) 
		{
			if (!_history.ContainsKey(magicID))
			{
				var data = ExcelConfig.ExcelToJSONConfigManager
				                      .Current.GetConfigByID<ExcelConfig.CharacterMagicData>(magicID);
				//cdTime;

				_history.Add(magicID, new ReleaseHistory
				{
					MagicDataID = magicID,
					CdTime =data.TickTime,
					LastTime = now
				});

			}
			else {
				var d = _history[magicID];
				d.LastTime = now;
			}
		}

		public bool IsCoolDown(int magicID, float now, bool autoAttach = false)
		{
			ReleaseHistory h;
			bool isOK = true;
			if (_history.TryGetValue(magicID, out h))
			{ 
				isOK = h.IsCoolDown(now); 
			}
			if (autoAttach)
			{
				AttachMagicHistory(magicID, now);
			}
			return isOK;
		}
	}
}

