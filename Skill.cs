﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PyGame
{
    internal class Skill
    {
        public required string Name;
        public required SkillType Type;
        public Buff[]? Effect;
        public float? Value;
        public required int CoolDown;
        public Skill(string Name,SkillType Type,Buff[]? Effect,float? Value, int CoolDown)
        {
            this.Name = Name;
            this.Type = Type;
            this.Effect = Effect;
            this.Value = Value;
            this.CoolDown = CoolDown;
        }
        public Skill(string Name,SkillType Type, Buff[] Effect, int CoolDown) :this(Name,Type,Effect,null,CoolDown)
        {

        }
        public Skill(string Name,SkillType Type,float Value,int CoolDown) : this(Name, Type, null, Value, CoolDown)
        {

        }
    }
    internal class SkillCollection : IEnumerable
    {
        List<Skill> Skills = new();
        Dictionary<Skill, int> CoolDownList = new();
        public Skill this[int index]
        {
            get { return Skills[index]; }
        }
        public Skill[] this[SkillType Type]
        {
            get 
            { 
                return Skills.Where(skill =>
                {
                    if (skill.Type == Type)
                        return true;
                    return false;
                }).ToArray();
            }
        }
        public void Add(Skill newSkill)
        {
            Skills.Add(newSkill);
        }
        public bool inCoolDown(Skill skill)
        {
            return CoolDownList.ContainsKey(skill);
        }
        public void NextRound()
        {
            foreach(var skill in CoolDownList.Keys)
                if (--CoolDownList[skill] <= 0)
                    CoolDownList.Remove(skill);
        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Skills).GetEnumerator();
        }
    }
}
