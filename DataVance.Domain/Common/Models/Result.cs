using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Domain.Common.Models
{
    public class Result
    {

        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public static Result Success() => new Result(true, Array.Empty<string>());

        public static Result Failure(IEnumerable<string> errors) => new Result(false, errors);
        public static Result Failure(string error) => new Result(false, new[] { error });
    }

    public class Result<T> : Result
    {
        public T? Value { get; }

        protected internal Result(bool succeeded, T? value, IEnumerable<string> errors) 
            : base(succeeded, errors)
        {
            Value = value;
        }

        public static Result<T> Success(T value) => new(true, value, Array.Empty<string>());
        public new static Result<T> Failure(IEnumerable<string> errors) => new(false, default, errors);
        public new static Result<T> Failure(string error) => new(false, default, new[] { error });
    }
}
