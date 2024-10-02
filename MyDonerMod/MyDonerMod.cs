using System;
using System.Linq;
using System.Reflection;
using MyDonerMod.Customs.Appliances;
using MyDonerMod.Customs.Dishes;
using MyDonerMod.Customs.ItemGroups;
using MyDonerMod.Customs.Items;
using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenMods;
using UnityEngine;
using KitchenLib.Event;

namespace MyDonerMod
{
    public class MyDonerMod : BaseMod, IModSystem
    {
        public const string MOD_ID = "com.eycrime.mydonermod";

        public const string MOD_NAME = "MyDonerMod";

        public const string MOD_VERSION = "1.0.0";

        public const string MOD_AUTHOR = "EyCrime";

        public const string MOD_GAMEVERSION = ">=1.1.4";

        public static AssetBundle Bundle;
        internal static KitchenLogger Logger;

        public static DonerMachine DonerMachine;

        public MyDonerMod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly())
        {
        }

        protected override void OnInitialise()
        {
            MyDonerMod.LogWarning($"{MOD_ID} v{MOD_VERSION} in use!");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Logger = base.InitLogger();
            MyDonerMod.LogInfo("Attempting to load asset bundle...");
            MyDonerMod.Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_ID);
            MyDonerMod.LogInfo("Done loading asset bundle.");
            this.AddGameData();
            Events.BuildGameDataEvent = (EventHandler<BuildGameDataEventArgs>)Delegate.Combine(Events.BuildGameDataEvent, new EventHandler<BuildGameDataEventArgs>(delegate (object s, BuildGameDataEventArgs args)
            {
            }));
        }

        private void AddGameData()
        {
            MyDonerMod.LogInfo("Attempting to register game data...");
            base.AddGameDataObject<DonerDish>();
            MyDonerMod.DonerMachine = base.AddGameDataObject<DonerMachine>();
            base.AddGameDataObject<DonerKebabM>();
            base.AddGameDataObject<DonerKebabMT>();
            base.AddGameDataObject<DonerKebabMTS>();
            base.AddGameDataObject<DonerKebabComplete>();
            base.AddGameDataObject<DonerMeat>();
            MyDonerMod.LogInfo("Done loading game data.");
        }
        public static void LogInfo(string _log)
        {
            Debug.Log("[MyDonerMod] " + _log);
        }
        
        public static void LogWarning(string _log)
        {
            Logger.LogWarning("[MyDonerMod] " + _log);
        }

        public static void LogError(string _log)
        {
            Logger.LogError("[MyDonerMod] " + _log);
        }

        public static void LogInfo(object _log)
        {
            Logger.LogInfo(_log.ToString());
        }

        public static void LogWarning(object _log)
        {
            Logger.LogWarning(_log.ToString());
        }

        public static void LogError(object _log)
        {
            Logger.LogError(_log.ToString());
        }
    }
}
