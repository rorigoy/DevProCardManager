﻿using System.Linq;
using DevPro_CardManager.Enums;
using System;
using System.Collections.Generic;

namespace DevPro_CardManager
{
    public class CardInfos: ICloneable
    {

        public CardInfos(IList<string> carddata)
        {
            Id = Int32.Parse(carddata[0]);
            Ot = Int32.Parse(carddata[1]);
            AliasId = Int32.Parse(carddata[2]);
            SetCode = Int32.Parse(carddata[3]);
            Type = Int32.Parse(carddata[4]);
            Level = Int32.Parse(carddata[5]);
            Race = Int32.Parse(carddata[6]);
            Attribute = Int32.Parse(carddata[7]);
            Atk = Int32.Parse(carddata[8]);
            Def = Int32.Parse(carddata[9]);
            Category = Int32.Parse(carddata[10]);
        }

        public void SetCardText(string[] cardtext)
        {
            Name = cardtext[1];
            Description = cardtext[2];
            var effects = new List<string>();

            for (var i = 3; i < cardtext.Length; i++)
            {
                if(cardtext[i] != "")
                    effects.Add(cardtext[i]);
            }
            EffectStrings = effects.ToArray();

        }

        public CardType[] GetCardTypes()
        {
            var typeArray = Enum.GetValues(typeof(CardType));
            return typeArray.Cast<CardType>().Where(type => ((Type & (int) type) != 0)).ToArray();
        }

        public int[] GetCardSets(List<int>setArray)
        {
            var sets = new List<int> {setArray.IndexOf(SetCode & 0xffff), setArray.IndexOf(SetCode >> 0x10)};
            return sets.ToArray();
        }

        public object Clone()
        {
            return  MemberwiseClone();
        }

        public int AliasId { get; set; }

        public int Atk { get; set; }

        public int Attribute { get; set; }

        public int Def { get; set; }

        public string Description { get; set; }

        public int Id { get; private set; }

        public int Level { get; set; }

        public string Name = "";

        public int Race { get; set; }

        public int Type { get; set; }

        public int Category { get; set; }

        public int Ot { get; set; }

        public string[] EffectStrings { get; set; }

        public int SetCode { get; set; }

    }
}