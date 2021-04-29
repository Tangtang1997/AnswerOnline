namespace AnswerOnline.Toolkit.UnifyModel
{
    public class Result<T> : Result
    {
        public Result()
            : this(default, default)
        {

        }
        protected Result(T t, bool isSucceeded, string description = null)
               : base(isSucceeded, description)
        {
            Data = t;
        }

        public T Data { get; set; }

        /// <summary>
        /// 带有数据的成功的返回
        /// </summary>
        /// <param name="t">要返回的数据</param>
        /// <param name="description">附加消息</param>
        /// <returns><see cref="Result{T}"/></returns>
        public static Result<T> Success(T t, string description = null)
        {
            return new Result<T>(t, true, description);
        }

        /// <summary>
        /// 带有数据的失败的返回
        /// </summary>
        /// <param name="t">要返回的数据</param>
        /// <param name="description">附加消息</param>
        /// <returns><see cref="Result{T}"/></returns>
        public static Result<T> Failed(T t, string description = null)
        {
            return new Result<T>(t, false, description);
        }
    }
}
