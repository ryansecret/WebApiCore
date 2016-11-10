namespace WebApiCore.DomainModel
{
    public class StatisticItem
    {
        /// <summary>
        /// 值
        /// </summary>
        public int Value;
        /// <summary>
        /// X轴
        /// </summary>
        public string Lable { get; set; }
    }

    public class StatisticItemEx
    {
        public string Lable;

        public int OrderCount;

        public decimal Money;
    }
}