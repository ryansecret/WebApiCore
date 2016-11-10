using System;

namespace WebApiCore.Application.Models
{
    /// <summary>
    /// 返回对象,客户端契约
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int Success =200;
        /// <summary>
        /// 错误
        /// </summary>
        public const int ServerError = 500;
        /// <summary>
        /// 未授权
        /// </summary>
        public const int NoAutherize = 401;
        /// <summary>
        /// 构造bb函数
        /// </summary>
        public Result()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public Result(int status, String message = "")
        {
            this.ResultStatus = status;
            this.Message = message;
        }
       
       
        public int ResultStatus;
        /// <summary>
        /// 返回的消息 
        /// </summary>
       
        public String Message;
    }
    /// <summary>
    /// 返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultWithData<T> : Result
    {
        /// <summary> 
        /// 
        /// </summary>
        public ResultWithData()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dataBody"></param>
        /// <param name="message"></param>
        public ResultWithData( T dataBody, String message = "", int status =200)
            : base(status, message)
        {
            this.DataBody = dataBody;
        }
        /// <summary>
        /// 返回的数据信息
        /// </summary>
         
        public T DataBody
        {
            get;
            private set;
        }
    }
}
