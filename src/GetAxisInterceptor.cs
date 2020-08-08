
using HarmonyLib;
using UnityEngine;

namespace CultistRebind
{

    [HarmonyPatch(typeof(Input), "GetAxis")]
    public class GetAxisInterceptor
    {
        static bool Prefix(string axisName, ref float __result)
        {
            // Turn off the key interceptor to avoid circular resolutions if the user rebinds an existing key
            GetKeyDownInterceptor.IsEnabled = false;
            try
            {
                switch (axisName)
                {
                    case "Start Recipe":
                        __result = CultistRebindPlugin.Instance.StartRecipeKey.Value.IsPressed() ? 1 : 0;
                        return false;
                    case "Collect All":
                        __result = CultistRebindPlugin.Instance.CollectAllKey.Value.IsPressed() ? 1 : 0;
                        return false;
                    case "Zoom":
                        if (CultistRebindPlugin.Instance.ZoomInKey.Value.IsPressed())
                        {
                            __result = 1;
                        }
                        else if (CultistRebindPlugin.Instance.ZoomOutKey.Value.IsPressed())
                        {
                            __result = -1;
                        }
                        return false;
                    case "Zoom Level 1":
                        __result = CultistRebindPlugin.Instance.ZoomLevel1Key.Value.IsPressed() ? 1 : 0;
                        return false;
                    case "Zoom Level 2":
                        __result = CultistRebindPlugin.Instance.ZoomLevel2Key.Value.IsPressed() ? 1 : 0;
                        return false;
                    case "Zoom Level 3":
                        __result = CultistRebindPlugin.Instance.ZoomLevel3Key.Value.IsPressed() ? 1 : 0;
                        return false;
                    case "Horizontal":
                        if (CultistRebindPlugin.Instance.MoveLeftKey.Value.IsPressed())
                        {
                            __result = -1;
                        }
                        else if (CultistRebindPlugin.Instance.MoveRightKey.Value.IsPressed())
                        {
                            __result = 1;
                        }
                        return false;
                    case "Vertical":
                        if (CultistRebindPlugin.Instance.MoveUpKey.Value.IsPressed())
                        {
                            __result = 1;
                        }
                        else if (CultistRebindPlugin.Instance.MoveDownKey.Value.IsPressed())
                        {
                            __result = -1;
                        }
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