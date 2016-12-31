﻿/*
██████╗ ██╗   ██╗     █████╗ ██╗     ██████╗ ██╗  ██╗ █████╗  ██████╗  ██████╗ ██████╗ 
██╔══██╗╚██╗ ██╔╝    ██╔══██╗██║     ██╔══██╗██║  ██║██╔══██╗██╔════╝ ██╔═══██╗██╔══██╗
██████╔╝ ╚████╔╝     ███████║██║     ██████╔╝███████║███████║██║  ███╗██║   ██║██║  ██║
██╔══██╗  ╚██╔╝      ██╔══██║██║     ██╔═══╝ ██╔══██║██╔══██║██║   ██║██║   ██║██║  ██║
██████╔╝   ██║       ██║  ██║███████╗██║     ██║  ██║██║  ██║╚██████╔╝╚██████╔╝██████╔╝
╚═════╝    ╚═╝       ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚═════╝ 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace GodJungleTracker.Classes
{
    public class Packets
    {
        public static OnPatienceChange Patience;
        public static OnAttack Attack;
        public static OnMissileHit MissileHit;
        public static OnDisengaged Disengaged;
        public static OnMonsterSkill MonsterSkill;
        public static OnCreateGromp CreateGromp;
        public static OnCreateCampIcon CreateCampIcon;

        static Packets() 
        {
            try
            {
                Patience = new OnPatienceChange();
                Attack = new OnAttack();
                MissileHit = new OnMissileHit();
                Disengaged = new OnDisengaged();
                MonsterSkill = new OnMonsterSkill();
                CreateGromp = new OnCreateGromp();
                CreateCampIcon = new OnCreateCampIcon();
            }
            catch (Exception)
            {
                //ignored
            }
        }

        public class OnPatienceChange
        {
            public OnPatienceChange(int header = 0, int length = 35, int length2 = 53, int length3 = 56)
            {
                Length = length;
                Length2 = length2;
                Length3 = length3;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
            public int Length2 { get; set; }
            public int Length3 { get; set; }
        }

        public class OnAttack
        {
            public OnAttack(int header = 0, int length = 71)
            {
                Length = length;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
        }

        public class OnMissileHit
        {
            public OnMissileHit(int header = 0, int length = 35)
            {
                Length = length;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
        }

        public class OnDisengaged
        {
            public OnDisengaged(int header = 0, int length = 125, int length2 = 35, int length3 = 23, int length4 = 20)
            {
                Length = length;
                Length2 = length2;
                Length3 = length3;
                Length4 = length4;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
            public int Length2 { get; set; }
            public int Length3 { get; set; }
            public int Length4 { get; set; }
        }

        public class OnMonsterSkill
        {
            public OnMonsterSkill(int header = 0, int length = 47, int length2 = 68, int length3 = 38)
            {
                Length = length;
                Length2 = length2;
                Length3 = length3;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
            public int Length2 { get; set; }
            public int Length3 { get; set; }
        }

        public class OnCreateGromp
        {
            public OnCreateGromp(int header = 0, int length = 347, int length2 = 350)
            {
                Length = length;
                Length2 = length2;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
            public int Length2 { get; set; }
        }

        public class OnCreateCampIcon
        {
            public OnCreateCampIcon(int header = 0, int length = 59, int length2 = 86, int length3 = 365, int length4 = 335, int length5 = 371)
            {
                Length = length;
                Length2 = length2;
                Length3 = length3;
                Length4 = length4;
                Length5 = length5;
                Header = header;
            }
            public int Header { get; set; }
            public int Length { get; set; }
            public int Length2 { get; set; }
            public int Length3 { get; set; }
            public int Length4 { get; set; }
            public int Length5 { get; set; }
        }
    }
}