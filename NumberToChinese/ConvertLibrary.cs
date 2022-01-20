using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToChinese
{
    public static class ConvertLibrary
    {
        /// <summary>
        /// 將數字轉為中文大寫，最大支援至9千兆(溢位回傳0)
        /// </summary>
        /// <param name="_values">阿拉伯數字</param>
        /// <returns>中文大寫</returns>
        public static string ConvertToChinese(string _values)
        {
            //防止溢位
            if (Int64.Parse(_values) > 9999999999999999)
            {
                return "0";
            }

            string _input = _values;

            string[] chineseNumber = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
            string[] unit = { "", "拾", "佰", "仟", "萬", "拾萬", "佰萬", "仟萬", "億", "拾億", "佰億", "仟億", "兆", "拾兆", "佰兆", "仟兆" };
            List<string> BigUnit = new List<string> { "", "萬", "億", "兆" }; //於各個四位中，補上單位 三百六十"萬"五千

            List<string> splitInt = new List<string>();
            int surplusLength = _input.Length % 4; //剩餘位數

            //四個一位
            int count = 0;
            while (_input.Length != 0)
            {
                //計算剩餘數，若無則以四個為一進位
                if (count == 0 && surplusLength != 0)
                {
                    splitInt.Add(_input.Substring(0, surplusLength));
                    _input = _input.Substring(surplusLength, _input.Length - surplusLength);
                }
                else
                {
                    splitInt.Add(_input.Substring(0, 4));
                    _input = _input.Substring(4, _input.Length - 4);
                }
                count++;
            }

            //針對每個四位改為國字
            StringBuilder sb = new StringBuilder();
            bool AppendZero = false; //1001 => 一千"零"一
            for (int i = 0; i < splitInt.Count; i++)
            {
                string BigUnitAdd = BigUnit[splitInt.Count - 1 - i];
                int UnitLengh = splitInt[i].Length;
                string fourInt = splitInt[i];
                for (int index = 0; index < fourInt.Length; index++)
                {
                    UnitLengh--;
                    if (fourInt[index] != '0')
                    {
                        if (AppendZero)
                        {
                            sb.Append(chineseNumber[0]);
                            AppendZero = false;
                        }
                        sb.Append(chineseNumber[(int)Char.GetNumericValue(fourInt[index])]);
                        sb.Append(unit[UnitLengh]);
                    }
                    else { AppendZero = true; }
                }

                //避免一百億"萬" 出現
                if (!string.IsNullOrEmpty(sb.ToString()) && !BigUnit.Contains(sb.ToString().Substring(sb.Length - 1)))
                {
                    sb.Append(BigUnitAdd);
                }

            }

            return sb.ToString();

            //萬字元後可能會有誤 (ex: 3百萬60萬零一千 > 正確:360萬零一千)
            //string input = _values;
            //string[] chineseNumber = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
            //string[] unit = { "", "拾", "佰", "仟", "萬", "拾萬", "佰萬", "仟萬", "億", "拾億", "佰億", "仟億", "兆", "拾兆", "佰兆", "仟兆" };

            //StringBuilder sb = new StringBuilder();
            //int UnitLengh = input.Length;
            //bool AppendZero = false; //1001 => 一千"零"一
            //for (int i = 0; i < input.Length; i++)
            //{
            //    UnitLengh--;
            //    if (input[i] != '0')
            //    {
            //        if (AppendZero)
            //        {
            //            sb.Append(chineseNumber[0]);
            //            AppendZero = false;
            //        }
            //        sb.Append(chineseNumber[(int)Char.GetNumericValue(input[i])]);
            //        sb.Append(unit[UnitLengh]);
            //    }
            //    else { AppendZero = true; }
            //}
            //return sb.ToString();

        }

        enum NumberEnum
        {
            零 = 0,
            壹 = 1,
            貳 = 2,
            參 = 3,
            肆 = 4,
            伍 = 5,
            陸 = 6,
            柒 = 7,
            捌 = 8,
            玖 = 9
        }
        enum UnitEnum
        {
            拾 = 10,
            佰 = 100,
            仟 = 1000,
            萬 = 10000,
            億 = 100000000,
        }

        /// <summary>
        /// 將中文大寫轉為數字，最大支援至9千兆(自動過濾不認識之字串)
        /// </summary>
        /// <param name="_String">中文大寫字串</param>
        /// <returns>阿拉伯數字</returns>
        public static string ConvertToNumber(string _String)
        {
            StringBuilder sb = new StringBuilder();
            string Num = ""; //中文字串
            double TempNumber = 0; //佔存當前值，由Num轉int
            double TempSum = 0; //佔存當前值總和
            double Sum = 0; //實際總和
            for (int i = 0; i < _String.Length; i++)
            {
                if (Enum.IsDefined(typeof(NumberEnum), _String[i].ToString()))
                {
                    Num += (int)Enum.Parse(typeof(NumberEnum), _String[i].ToString());
                    TempNumber = Convert.ToInt32(Num);
                }
                if (Enum.IsDefined(typeof(UnitEnum), _String[i].ToString()))
                {
                    switch ((UnitEnum)Enum.Parse(typeof(UnitEnum), _String[i].ToString()))
                    {
                        case UnitEnum.萬:
                        case UnitEnum.億:
                            if (TempSum != 0)
                            {
                                TempSum += TempNumber;
                                TempSum *= (int)Enum.Parse(typeof(UnitEnum), _String[i].ToString());
                                Sum += TempSum;
                            }
                            else
                            {
                                TempNumber *= (int)Enum.Parse(typeof(UnitEnum), _String[i].ToString());
                                Sum += TempNumber;
                            }
                            TempNumber = 0;
                            TempSum = 0;
                            break;
                        case UnitEnum.拾:
                        case UnitEnum.佰:
                        case UnitEnum.仟:
                            TempNumber *= (int)Enum.Parse(typeof(UnitEnum), _String[i].ToString());
                            TempSum += TempNumber;
                            TempNumber = 0;
                            break;
                    }
                }
                Num = "";
            }
            if (TempSum != 0 || TempNumber != 0)
            {
                //若有結餘(十百千)，全數加上
                Sum += TempSum + TempNumber;
            }
            return Sum.ToString();
        }
    }
}
