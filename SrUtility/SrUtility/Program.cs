// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SrUtility.cs" company="SrUtility">
//      Copyright (c) SrUtility. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;
using Color = SharpDX.Color;

namespace SrUtility
{
    internal class SrUtility
    {
        protected static Menu Config;

        // ADCs list.
        public static string[] ADCs =
        {
            "Ahri", "Urgot", "Ashe", "Vayne", "Kalista", "Caitlyn", "Draven",
            "Jhin", "Jinx", "Twitch", "Tristana", "MissFortune", "Lucian"
        };

        public SrUtility()
        {
            CustomEvents.Game.OnGameLoad += GameOnGameLoad;
        }

        private static void Main(string[] args)
        {
            var SrUtility = new SrUtility();
        }

        private void GameOnGameLoad(EventArgs args)
        {
            // Menu.
            Config = new Menu("SrUtility", "SrUtility", true).SetFontStyle(FontStyle.Bold, Color.Red);

            var BuyAtStart = Config.AddItem(new MenuItem("Buy at game start", "Buy at game start").SetValue(true));
            var Vayne = Config.AddItem(new MenuItem("Upgrade Trinket with ADCs", "Upgrade Trinket with ADCs").SetValue(true));
            var Janna = Config.AddItem(new MenuItem("Upgrade Trinket with Supports", "Upgrade Trinket with Supports").SetValue(true));
            var Info = Config.AddItem(new MenuItem("Script by ShiroSR", "Script by ShiroSR")).SetFontStyle(FontStyle.Regular, Color.Orange);
            Config.AddToMainMenu();

            // Items at game start.

            #region ADCs

            if (ADCs.Any(x => x == ObjectManager.Player.ChampionName) &&
                Config.Item("Buy at game start").GetValue<bool>())
            {
                ObjectManager.Player.BuyItem((ItemId)1055);
                ObjectManager.Player.BuyItem((ItemId)2003);
                ObjectManager.Player.BuyItem((ItemId)3340);
            }

            #endregion

            #region Janna

            if ((ObjectManager.Player.ChampionName == "Janna") && Config.Item("Buy at game start").GetValue<bool>())
            {
                ObjectManager.Player.BuyItem((ItemId)1055);
                ObjectManager.Player.BuyItem((ItemId)2003);
                ObjectManager.Player.BuyItem((ItemId)2003);
                ObjectManager.Player.BuyItem((ItemId)2003);
                ObjectManager.Player.BuyItem((ItemId)3340);
            }

            #endregion

            Game.OnUpdate += OnUpdate;
        }

        private void OnUpdate(EventArgs args)
        {
            // Trinket upgrade.
            var time = Environment.TickCount;
            if (Config.Item("Upgrade Trinket with ADCs").GetValue<bool>() &&
                ADCs.Any(x => x == ObjectManager.Player.ChampionName) && (ObjectManager.Player.Level >= 9))
                ObjectManager.Player.BuyItem((ItemId)3363);
            if (Config.Item("Upgrade Trinket with Supports").GetValue<bool>() &&
                (ObjectManager.Player.ChampionName == "Janna") && (ObjectManager.Player.Level >= 9))
                ObjectManager.Player.BuyItem((ItemId)3364);
        }
    }
}