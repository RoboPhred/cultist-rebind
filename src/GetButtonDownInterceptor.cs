
using HarmonyLib;
using UnityEngine;

namespace CultistRebind
{

    [HarmonyPatch(typeof(Input), "GetButtonDown")]
    public class GetButtonDownInterceptor
    {
        static bool Prefix(string buttonName, ref bool __result)
        {
            // Turn off the key interceptor to avoid circular resolutions if the user rebinds an existing key
            GetKeyDownInterceptor.IsEnabled = false;
            try
            {
                switch (buttonName)
                {
                    case "Pause":
                        __result = CultistRebindPlugin.Instance.PauseKey.Value.IsDown();
                        return false;
                    case "Cancel":
                        __result = CultistRebindPlugin.Instance.CancelKey.Value.IsDown();
                        return false;
                    case "Stack Cards":
                        __result = CultistRebindPlugin.Instance.StackCardsKey.Value.IsDown();
                        return false;
                }

                return true;
            }
            finally
            {
                // Turn it back on after we are done resolving keys.
                GetKeyDownInterceptor.IsEnabled = true;
            }
        }
    }
}