using System.Collections.Generic;

namespace RPG_Notebook
{
    internal class EnemyData
    {
		public string name = "";
		public string region = "";
		public string type = "";
		public List<Ability> abilities;
		public List<Loot> loot;
		public Dictionary<string, Resistance> resistances;
		public List<string> passives;
		public int[] attributes;
		public List<DamageType> types;
		public EnemyData()
		{
			abilities = new List<Ability>();
			loot = new List<Loot>();	
			resistances = new Dictionary<string, Resistance>();
			passives = new List<string>();
			attributes = new int[5];
			types = new List<DamageType>();
			SetDamageTypeList();
		}

		public class Ability
		{
			public string name;
			public int range = 0;
			public int ac = 0;
			public int cd = 0;
			public string aoe = "";
			public string dmg = "";
			public string dmgType = "";
			public string target = "";
			public string effect = "";
			public string requierments = "";
			public string aibehaviour = "";

			public Ability(string Name)
			{
				name = Name;
			}
		}

		public class DamageType
		{
            public enum Type
            {
				melee,
				magic,
				condition
            }

			public string name;
			public Type type;
			public string imgURL = "";

			public DamageType(string Name, Type typed, string ImgURL)
			{
				name = Name;
				type = typed;
				imgURL = ImgURL;
			}
		}

		public class Loot
		{

		}

		public class Resistance
		{
			public string dmgType;
			public string value;
			public bool isImmune;
            public string imageURL = "";

            public Resistance(string DmgType, string ImageURL, string Value, bool IsImmune)
			{
				dmgType = DmgType;
				value = Value;
				isImmune = IsImmune;
				imageURL = ImageURL;
			}
		}

		public void AddRes(string DmgType, string imageURL, string Value, bool IsImmune)
		{
			var newRes = new Resistance(DmgType, imageURL, Value, IsImmune);

			if (!resistances.ContainsKey(DmgType))
            {
				resistances.Add(DmgType, newRes);
            }
            else
            {
				resistances[DmgType] = newRes;
            }
		}

		private void SetDamageTypeList() {
			var mapPath = "C:/Users/Anthon/Desktop/Unity Projects/Screamo/RPG-Notebook/RPG-Notebook";
			types.Add(new DamageType("Burn damage", DamageType.Type.magic, mapPath + "/Icons/Burn Damage.png"));
			types.Add(new DamageType("Slash damage", DamageType.Type.melee, mapPath + "/Icons/Slash damage.png"));
			types.Add(new DamageType("Pierce damage", DamageType.Type.melee, mapPath + "/Icons/Pierce damage.png"));
			types.Add(new DamageType("Blunt damage", DamageType.Type.melee, mapPath + "/Icons/Blunt damage.png"));
			//types.Add(new DamageType("Chaos damage", DamageType.Type.magic, "/Choas Damage.png"));
			//types.Add(new DamageType("Mind damage", DamageType.Type.magic, "/Mind Damage.png"));
			types.Add(new DamageType("Shock damage", DamageType.Type.magic, mapPath + "/Icons/Shock damage.png"));
			types.Add(new DamageType("Bleeding", DamageType.Type.condition, mapPath + "/Icons/Bleeding.png"));
			types.Add(new DamageType("Burning", DamageType.Type.condition, mapPath + "/Icons/Burning.png"));
			types.Add(new DamageType("Poison", DamageType.Type.condition, mapPath + "/Icons/Poison.png"));
			//types.Add(new DamageType("Erode", DamageType.Type.condition, "/Erode.png"));
		}
	}
}