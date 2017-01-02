using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using LeagueSharp;
using LeagueSharp.Common;
using Color = SharpDX.Color;

namespace PingSharp
{
    internal class PingSharp
    {
        protected static Menu Config;

        public PingSharp()
        {
            CustomEvents.Game.OnGameLoad += GameOnGameLoad;
        }
        private static void Main(string[] args)
        {
            var PingSharp = new PingSharp();
        }
        private static int _flag = -1;
        private static Dictionary<PingCategory, string> _pingTypeList = new Dictionary<PingCategory, string>();

        private void GameOnGameLoad(EventArgs args)
        {
            _pingTypeList.Add(PingCategory.AssistMe, "AssistMe");
            _pingTypeList.Add(PingCategory.Danger, "Danger");
            _pingTypeList.Add(PingCategory.EnemyMissing, "EnemyMissing");
            _pingTypeList.Add(PingCategory.Fallback, "Fallback");
            _pingTypeList.Add(PingCategory.Normal, "Normal");
            _pingTypeList.Add(PingCategory.OnMyWay, "OnMyWay");

            Config = new Menu("PingSharp", "Ping# Revamped", true).SetFontStyle(FontStyle.Bold, Color.Red);

            var Fire = Config.AddItem(new MenuItem("fire", "Fire!").SetValue(new KeyBind("C".ToCharArray()[0], KeyBindType.Press)).SetFontStyle(FontStyle.Bold));
            var Target = Config.AddSubMenu(new Menu("Target: ", "target"));
            {
                foreach (var ally in ObjectManager.Get<Obj_AI_Hero>().Where(h => h.IsAlly && !h.IsMe))
                Target.AddItem(new MenuItem("ally." + ally.ChampionName, "Target: " + ally.ChampionName).SetValue(false));
            }
            Config.AddItem(new MenuItem("ping", "Ping Type").SetValue(new StringList(new[] { "AssistMe", "Danger", "EnemyMissing", "Fallback", "Normal", "OnMyWay" })));
            Config.AddItem(new MenuItem("delay", "Delay(ms)").SetValue(new Slider(0, 0, 100)));
            Config.AddItem(new MenuItem("by", "Ported by ShiroSR").SetFontStyle(FontStyle.Italic, Color.DarkCyan));
            Config.AddToMainMenu();
            Game.OnUpdate += Game_OnUpdate;
        }

        static void Game_OnUpdate(EventArgs args)
        {
            var delay = Config.Item("delay").GetValue<Slider>().Value;

            if (_flag == -1)
            {
                _flag = delay;
            }
            if (_flag != 0)
            {
                _flag--;
                return;
            }
            var shouldFire = Config.Item("fire").GetValue<KeyBind>().Active;
            var pingType = Config.Item("ping").GetValue<StringList>().SelectedValue;

            if (!shouldFire)
                return;
            var ping = _pingTypeList.FirstOrDefault(p => p.Value == pingType).Key;
            foreach (var ally in ObjectManager.Get<Obj_AI_Hero>().Where(h => h.IsAlly && !h.IsMe))
                if (Config.Item("ally." + ally.ChampionName).GetValue<bool>())
                    Game.SendPing(ping, ally.ServerPosition);

            _flag = delay;
        }
    }
}