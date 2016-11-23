using System;

namespace WebApiCore.Application.Models
{
    /// <summary>
    ///  
    /// </summary>
    public class Output
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const int Success =1;

        //
        public const int Falure = 0;
        /// <summary>
        /// 构造bb函数
        /// </summary>
        public Output()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public Output(int status, String message = "")
        {
            this.ResultStatus = status;
            this.Message = message;
        }

        /// <summary>
        /// The result status
        /// </summary>
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
    public class OutputWithData<T> : Output
    {
        /// <summary> 
        /// 
        /// </summary>
        public OutputWithData()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="dataBody"></param>
        /// <param name="message"></param>
        public OutputWithData( T dataBody, String message = "", int status =1)
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
