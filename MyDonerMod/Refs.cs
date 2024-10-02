using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace MyDonerMod
{
    internal class Refs
    {
        public static Item Plate
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.Plate);
            }
        }

        public static Item DirtyPlate
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.PlateDirty);
            }
        }

        public static Item Burnt
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.BurnedFood);
            }
        }

        public static Item DonerBread
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.HotdogBun);
            }
        }

        public static Item Tomato
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.Tomato);
            }
        }

        public static Item ChoppedTomato
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.TomatoChopped);
            }
        }

        public static Item Lettuce
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.Lettuce);
            }
        }

        public static Item ChoppedLettuce
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.LettuceChopped);
            }
        }

        public static Item Onion
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.Onion);
            }
        }

        public static Item ChoppedOnion
        {
            get
            {
                return Refs.Find<Item>(ItemReferences.OnionChopped);
            }
        }

        public static Process Chop
        {
            get
            {
                return Refs.Find<Process>(ProcessReferences.Chop);
            }
        }

        internal static T Find<T>(int id) where T : GameDataObject
        {
            T result;
            if ((result = (T)((object)GDOUtils.GetExistingGDO(id))) == null)
            {
                CustomGameDataObject customGameDataObject = GDOUtils.GetCustomGameDataObject(id);
                result = (T)((object)((customGameDataObject != null) ? customGameDataObject.GameDataObject : null));
            }
            return result;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }
    }
}
