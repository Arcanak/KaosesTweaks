﻿using System;
using HarmonyLib;
using KaosesTweaks.Settings;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Localization;

namespace KaosesTweaks.Patches
{
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), "CalculateLearningRate", new Type[] { typeof(int), typeof(int), typeof(int), typeof(int), typeof(TextObject), typeof(bool) })]
    public class LearningRatePatches
    {
        static void Postfix(ref ExplainedNumber __result)
        {
            __result.LimitMin(KaosesMCMSettings.Instance.MinimumLearningRate);
        }

        static bool Prepare() => KaosesMCMSettings.Instance is { } settings && settings.MinimumLearningRate != 0.0f;
    }
}
