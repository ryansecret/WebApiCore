using System.Collections.Generic;

namespace WebApiCore.DomainModel
{
    public class ValidationState
    {
        public ValidationState()
        {
            
        }
        public ValidationState(IEnumerable<ValidationError> errors,bool isvalid)
        {
           
            this.Errors = errors;
            this.IsValid = isvalid;
        }
        public IEnumerable<ValidationError> Errors { get; private set; }
        public bool IsValid { get;private set; }
    }

    public struct ValidationError
    {
        public string ErrorMessage;
        public string ErrorCode;
    }
}
