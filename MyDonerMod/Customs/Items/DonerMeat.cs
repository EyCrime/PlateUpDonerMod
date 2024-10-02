using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace MyDonerMod.Customs.Items
{
    public class DonerMeat : CustomItem
    {
        public override string UniqueNameID
        {
            get
            {
                return "DonerMeat";
            }
        }

        public override GameObject Prefab
        {
            get
            {
                return MyDonerMod.Bundle.LoadAsset<GameObject>("Doner Meat");
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
                return ItemStorage.StackableFood;
            }
        }

        public override ItemValue ItemValue
        {
            get
            {
                return ItemValue.Medium;
            }
        }

        public override Appliance DedicatedProvider
        {
            get
            {
                return MyDonerMod.DonerMachine.GameDataObject;
            }
        }

        public override void OnRegister(Item gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Doner Meat", "Meat Piece Cooked");
        }
    }
}
