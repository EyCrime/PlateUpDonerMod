using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using MyDonerMod.Customs.ItemGroups;
using MyDonerMod.Customs.Items;
using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace MyDonerMod.Customs.Dishes
{
    public class DonerDish : CustomDish
    {
        public override string UniqueNameID
        {
            get
            {
                return "DonerDish";
            }
        }

        public override DishType Type
        {
            get
            {
                return DishType.Base;
            }
        }

        public override DishCustomerChange CustomerMultiplier
        {
            get
            {
                return DishCustomerChange.LargeDecrease;
            }
        }

        public override CardType CardType
        {
            get
            {
                return CardType.Default;
            }
        }

        public override Unlock.RewardLevel ExpReward
        {
            get
            {
                return Unlock.RewardLevel.Large;
            }
        }

        public override UnlockGroup UnlockGroup
        {
            get
            {
                return UnlockGroup.Dish;
            }
        }

        public override bool IsSpecificFranchiseTier
        {
            get
            {
                return false;
            }
        }

        public override bool IsAvailableAsLobbyOption
        {
            get
            {
                return true;
            }
        }

        public override bool DestroyAfterModUninstall
        {
            get
            {
                return false;
            }
        }

        public override bool IsUnlockable
        {
            get
            {
                return true;
            }
        }

        public override GameObject DisplayPrefab
        {
            get
            {
                return MyDonerMod.Bundle.LoadAsset<GameObject>("Doner Kebab Complete");
            }
        }

        public override GameObject IconPrefab
        {
            get
            {
                return this.DisplayPrefab;
            }
        }

        public override int Difficulty
        {
            get
            {
                return 4;
            }
        }

        public override List<string> StartingNameSet
        {
            get
            {
                return new List<string>
                {
                    "Mustafas Gemüsekebab"
                };
            }
        }

        public override List<Dish.MenuItem> ResultingMenuItems
        {
            get
            {
                return new List<Dish.MenuItem>
                {
                    new Dish.MenuItem
                    {
                        Item = (GDOUtils.GetCustomGameDataObject<DonerKebabComplete>().GameDataObject as ItemGroup),
                        Phase = MenuPhase.Main,
                        Weight = 1f
                    }
                };
            }
        }

        public override HashSet<Item> MinimumIngredients
        {
            get
            {
                return new HashSet<Item>
                {
                    Refs.DonerBread,
                    GDOUtils.GetCustomGameDataObject<DonerMeat>().GameDataObject as Item,
                    Refs.Tomato,
                    Refs.Lettuce,
                    Refs.Onion
                };
            }
        }

        public override HashSet<Process> RequiredProcesses
        {
            get
            {
                return new HashSet<Process>
                {
                    Refs.Chop
                };
            }
        }

        public override Dictionary<Locale, string> Recipe
        {
            get
            {
                return new Dictionary<Locale, string>
                {
                    {
                        Locale.English,
                        "Make meat in bread, a little lettuce, tomato, onion and your perfect kebab is ready."
                    },
                    {
                        Locale.German,
                        "Machst du Fleisch in Brott, dasu bisschen Salat, Tomate, Swibil und fertig ist dein perfekter Döner."
                    }
                };
            }
        }

        public override List<ValueTuple<Locale, UnlockInfo>> InfoList
        {
            get
            {
                return new List<ValueTuple<Locale, UnlockInfo>>
                {
                    new ValueTuple<Locale, UnlockInfo>(Locale.English, LocalisationUtils.CreateUnlockInfo("Doner Kebab", "The best kebab in the world", "Doner Kebab Dish")),
                    new ValueTuple<Locale, UnlockInfo>(Locale.German, LocalisationUtils.CreateUnlockInfo("Döner", "Der beste Döner der Welt", "Döner Gericht"))
                };
            }
        }

        public override void OnRegister(Dish gameDataObject)
        {
            DisplayPrefab.ApplyMaterialToChild("Bread", "Bread - Bun", "Bread - Inside");

            DisplayPrefab.ApplyMaterialToChild("Tomato - Chopped/Tomato - Chopped/Tomato Sliced/Liquid", "Tomato Flesh");
            DisplayPrefab.ApplyMaterialToChild("Tomato - Chopped/Tomato - Chopped/Tomato Sliced/Liquid.001", "Tomato Flesh 2");
            DisplayPrefab.ApplyMaterialToChild("Tomato - Chopped/Tomato - Chopped/Tomato Sliced/Skin", "Tomato");

            DisplayPrefab.ApplyMaterialToChild("Salad/Splittable View/Taco/Salad/Salad 1", "Lettuce");

            DisplayPrefab.ApplyMaterialToChild("Onion - Chopped/Splittable View/Taco/Onion - Chopped/Onion - Chopped 1/Circle.001", "Onion - Flesh", "Onion");
            DisplayPrefab.ApplyMaterialToChild("Onion - Chopped/Splittable View/Taco/Onion - Chopped/Onion - Chopped 1/Circle.002", "Onion - Flesh", "Onion");
            DisplayPrefab.ApplyMaterialToChild("Onion - Chopped/Splittable View/Taco/Onion - Chopped/Onion - Chopped 1/Circle.004", "Onion - Flesh", "Onion");

            DisplayPrefab.ApplyMaterialToChild("Doner Meat", "Meat Piece Cooked");
        }
    }
}
