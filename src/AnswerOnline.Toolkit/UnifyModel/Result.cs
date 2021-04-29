namespace AnswerOnline.Toolkit.UnifyModel
{
    /// <summary>
    /// 统一返回模型类(不需要返回数据的操作)
    /// </summary>
    public class Result
    {
        protected Result(bool isSucceeded, string description = null)
        {
            IsSucceeded = isSucceeded;
            Description = description;
        }

        /// <summary>
        /// 是否成功
        /// </summary> 
        public bool IsSucceeded { get; set; }

        /// <summary>
        /// 描述消息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 成功的返回
        /// </summary>
        /// <param name="description">附加消息</param>
        /// <returns><see cref="Result"/></returns>
        public static Result Success(string description = null)
        {
            return new Result(true, description);
        }

        /// <summary>
        /// 失败的返回
        /// </summary>
        /// <param name="description">附加消息</param>
        /// <returns><see cref="Result"/></returns>
        public static Result Failed(string description = null)
        {
            return new Result(false, description);
        }
    }
}
