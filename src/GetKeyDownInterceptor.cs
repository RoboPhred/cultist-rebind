
using System;
using HarmonyLib;
using UnityEngine;

namespace CultistRebind
{

    [HarmonyPatch(typeof(Input), "GetKeyDown", new Type[] { typeof(KeyCode) })]
    public class GetKeyDownInterceptor
    {
        public static bool IsEnabled = true;
        static bool Prefix(KeyCode key, ref bool __result)
        {
            if (!IsEnabled)
            {
                return true;
            }

            // Turn it off so we do not recurse if the user bound a different key to one of the overrides.
            IsEnabled = false;
            try
            {

                switch (key)
                {
                    case KeyCode.N:
                        __result = CultistRebindPlugin.Instance.NormalSpeedKey.Value.IsDown();
                        return false;
                    case KeyCode.M:
                        __result = CultistRebindPlugin.Instance.FastSpeedKey.Value.IsDown();
                        return false;
                }

                return true;
            }
            finally
            {
                // Turn it back on after we are done processing our own keys.
                IsEnabled = true;
            }
        }
    }
}