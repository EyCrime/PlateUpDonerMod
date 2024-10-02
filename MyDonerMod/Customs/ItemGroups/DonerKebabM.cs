using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MyDonerMod.Customs.Items;
using System.Collections.Generic;
using UnityEngine;

namespace MyDonerMod.Customs.ItemGroups
{
    public class DonerKebabM : CustomItemGroup
    {
        public override string UniqueNameID
        {
            get
            {
                return "DonerKebabM";
            }
        }

        public override GameObject Prefab
        {
            get
            {
                return MyDonerMod.Bundle.LoadAsset<GameObject>("Doner Kebab M");
            }
        }

        public override ItemCategory ItemCategory
        {
            get
            {
                return ItemCategory.Generic;
            }
        }

        public override ItemStorage ItemStorageFlags
        {
            get
            {
                return ItemStorage.None;
            }
        }

        public override ItemValue ItemValue
        {
            get
            {
                return ItemValue.Medium;
            }
        }

        public override bool CanContainSide
        {
            get
            {
                return true;
            }
        }

        public override List<ItemGroup.ItemSet> Sets
        {
            get
            {
                return new List<ItemGroup.ItemSet>
                {
                    new ItemGroup.ItemSet
                    {
                        Max = 2,
                        Min = 2,
                        IsMandatory = true,
                        Items = new List<Item>
                        {
                            Refs.DonerBread,
                            GDOUtils.GetCustomGameDataObject<DonerMeat>().GameDataObject as Item
                        }
                    }
                };
            }
        }

        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bread", "Bread - Bun", "Bread - Inside");

            Prefab.ApplyMaterialToChild("Doner Meat", "Meat Piece Cooked");
        }
    }
}