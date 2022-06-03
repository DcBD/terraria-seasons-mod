using Seasons.Common.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Seasons.Common.Enums;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;

namespace Seasons.Common.World
{
    public class SeasonsWorld : ModSystem
    {
        public int CurrentDay = 1;
        private int WinterDurationDays = 1; // 90
        private int SpringDuration = 1; // 92
        private int SummerDuration = 1; // 92
        private int FallDuration = 1; // 91
        private int MaxDaysInAYear => WinterDurationDays + SpringDuration + SummerDuration + FallDuration;

        public Season CurrentSeason { get; set; }

        private double PrevTime { get; set; }


        public override void OnWorldLoad()
        {
            CurrentSeason = new Season(SeasonsType.SPRING);

            Main.NewText($"Current season: {CurrentSeason}");
        }

        public override void SaveWorldData(TagCompound tag)
        {
            tag["currentDay"] = CurrentDay;
        }

        public override void OnWorldUnload()
        {
            CurrentDay = 1;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            if(tag.ContainsKey("currentDay"))
            {
                CurrentDay = (int) tag["currentDay"];
            } else
            {
                CurrentDay = 1;
            }
        }

        public override void PostUpdateWorld()
        {
            
        }

        public override void PostUpdateTime()
        {
            if(PrevTime != Main.time && Main.time == 0 && Main.dayTime)
            {
                this.PreNextDay();
            }

            PrevTime = Main.time;
        }

        public void PreNextDay()
        {
            if(CurrentDay == MaxDaysInAYear)
            {
                CurrentDay = 1;
            } else
            {
                CurrentDay++;
            }

            Main.NewText($"Next Day {CurrentDay}");

            this.PostNextDay();
        }

        public void PostNextDay()
        {
            if(CurrentDay == SpringDuration)
            {
                CurrentSeason.ChangeSeason(SeasonsType.SPRING);
            } else if(CurrentDay == SpringDuration + 1)
            {
                CurrentSeason.ChangeSeason(SeasonsType.SUMMER);
            } else if(CurrentDay == SpringDuration + SummerDuration + 1)
            {
                CurrentSeason.ChangeSeason(SeasonsType.FALL);
            } else
            {
                CurrentSeason.ChangeSeason(SeasonsType.WINTER);
            }
        }



    }
}
