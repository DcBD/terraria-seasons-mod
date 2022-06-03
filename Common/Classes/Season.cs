using Seasons.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace Seasons.Common.Classes
{
    public struct Season
    {
        public SeasonsType season { get; private set; }

        public Season(SeasonsType seasonType)
        {
            
            this.season = seasonType;
        }

        public override string ToString()
        {
            switch (season) {
                case SeasonsType.SPRING:
                    return "Spring";
                case SeasonsType.SUMMER:
                    return "Summer";
                case SeasonsType.FALL:
                    return "Fall";
                default: return "Winter";
            }

        }
        public void ChangeSeason(SeasonsType seasonType)
        {
            season = seasonType;

            Main.NewText($"New Season {this.ToString()}");
        }
    }
}
