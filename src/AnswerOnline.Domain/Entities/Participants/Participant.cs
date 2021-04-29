using System;
using AnswerOnline.Domain.Abstractions;

namespace AnswerOnline.Domain.Entities.Participants
{
    /// <summary>
    /// 参赛者
    /// </summary>
    public class Participant : AggregateRoot
    {
        /// <summary>
        /// 创建一个参赛者对象
        /// </summary>
        /// <param name="phoneNumber">手机号</param>
        /// <param name="name">姓名</param>
        /// <param name="department"></param>
        public Participant(string phoneNumber, string name, string department)
        {
            PhoneNumber = phoneNumber;
            Name = name;
            Department = department;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 最高分
        /// </summary>
        public int HighestScore { get; set; }

        /// <summary>
        /// 最高分用时（秒）
        /// </summary>
        public double TimeOfHighestScore { get; set; }

        /// <summary>
        /// 答题次数
        /// </summary>
        public int AnsweredNumber { get; set; }

        /// <summary>
        /// 可不可以继续答题
        /// </summary>
        /// <returns></returns>
        public bool HaveResidueDegree()
        {
            //每天只有2次答题机会
            return AnsweredNumber < 2;
        }

        /// <summary>
        /// 更新最高分和最高分用时
        /// </summary>
        /// <param name="score"></param>
        /// <param name="time"></param>
        public void UpdateHighestScore(int score, double time)
        {
            //记录一次答题次数
            AnsweredNumber += 1;

            if (score < HighestScore)
            {
                return;
            }

            HighestScore = score;
            TimeOfHighestScore = time;

            ModifyTime = DateTime.Now;
        }
    }
}