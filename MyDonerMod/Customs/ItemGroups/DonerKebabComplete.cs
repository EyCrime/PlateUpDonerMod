using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MyDonerMod.Customs.Items;
using System.Collections.Generic;
using UnityEngine;

namespace MyDonerMod.Customs.ItemGroups
{
    public class DonerKebabComplete : CustomItemGroup
    {
        public override string UniqueNameID
        {
            get
            {
                return "DonerKebabComplete";
            }
        }

        public override GameObject Prefab
        {
            get
            {
                return MyDonerMod.Bundle.LoadAsset<GameObject>("Doner Kebab Complete");
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
                            Refs.ChoppedOnion,
                            GDOUtils.GetCustomGameDataObject<DonerKebabMTS>().GameDataObject as Item
                        }
                    }
                };
            }
        }

        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Bread", "Bread - Bun", "Bread - Inside");

            Prefab.ApplyMaterialToChild("Tomato - Chopped/Tomato - Chopped/Tomato Sliced/Liquid", "Tomato Flesh");
            Prefab.ApplyMaterialToChild("Tomato - Chopped/Tomato - Chopped/Tomato Sliced/Liquid.001", "Tomato Flesh 2");
            Prefab.ApplyMaterialToChild("Tomato - Chopped/Tomato - Chopped/Tomato Sliced/Skin", "Tomato");

            Prefab.ApplyMaterialToChild("Salad/Splittable View/Taco/Salad/Salad 1", "Lettuce");

            Prefab.ApplyMaterialToChild("Onion - Chopped/Splittable View/Taco/Onion - Chopped/Onion - Chopped 1/Circle.001", "Onion - Flesh", "Onion");
            Prefab.ApplyMaterialToChild("Onion - Chopped/Splittable View/Taco/Onion - Chopped/Onion - Chopped 1/Circle.002", "Onion - Flesh", "Onion");
            Prefab.ApplyMaterialToChild("Onion - Chopped/Splittable View/Taco/Onion - Chopped/Onion - Chopped 1/Circle.004", "Onion - Flesh", "Onion");

            Prefab.ApplyMaterialToChild("Doner Meat", "Meat Piece Cooked");
        }
    }
}