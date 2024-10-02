using Kitchen.Components;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MyDonerMod.Customs.Items;
using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace MyDonerMod.Customs.Appliances
{
    public class DonerMachine : CustomAppliance
    {
        public override string UniqueNameID
        {
            get
            {
                return "DonerMachine";
            }
        }

        public override GameObject Prefab
        {
            get
            {
                return MyDonerMod.Bundle.LoadAsset<GameObject>("Doner Machine");
            }
        }

        public override List<IApplianceProperty> Properties
        {
            get
            {
                return new List<IApplianceProperty>
                {
                    KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<DonerMeat>().ID)
                };
            }
        }

        public override PriceTier PriceTier
        {
            get
            {
                return PriceTier.Medium;
            }
        }

        public override RarityTier RarityTier
        {
            get
            {
                return RarityTier.Uncommon;
            }
        }
        public override bool IsPurchasable
        {
            get
            {
                return true;
            }
        }

        public override bool SellOnlyAsDuplicate
        {
            get
            {
                return true;
            }
        }

        public override List<ValueTuple<Locale, ApplianceInfo>> InfoList
        {
            get
            {
                return new List<ValueTuple<Locale, ApplianceInfo>>
                {
                    new ValueTuple<Locale, ApplianceInfo>(Locale.English, new ApplianceInfo
                    {
                        Name = "Doner Meat",
                        Description = "Provides Doner Meat"
                    }),
                     new ValueTuple<Locale, ApplianceInfo>(Locale.German, new ApplianceInfo
                    {
                        Name = "Dönerfleisch",
                        Description = "Schneidet das Dönerfleisch schweißfrei."
                    })
                };
            }
        }

        public override void OnRegister(Appliance gameDataObject)
        {
            //Prefab.ApplyMaterialToChildren("Doner Machine Stand/DonerMeat", new Material[] { MyDonerMod.Bundle.LoadAsset<Material>("Doner Meat Material") });
            Prefab.ApplyMaterialToChild("Doner Machine Stand/DonerMeat", "Meat Piece Cooked");
            Prefab.ApplyMaterialToChild("Doner Machine Stand/Rod", "Metal Very Dark");
            Prefab.ApplyMaterialToChild("Doner Machine Stand/Top", "Metal Very Dark");
            Prefab.ApplyMaterialToChild("Doner Machine Stand/Bot", "Metal Very Dark");

            Prefab.ApplyMaterialToChild("Counter/Base", "Wood - Default");
            Prefab.ApplyMaterialToChild("Counter/Base", "Wood 4 - Painted");
            Prefab.ApplyMaterialToChild("Counter/Base/Handle", "Knob");
            Prefab.ApplyMaterialToChild("Counter/Top", "Wood - Default");
            Prefab.ApplyMaterialToChild("Counter/Stand", "Wood 1");
        }
    }
}
