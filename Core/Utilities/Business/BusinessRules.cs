using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return new SuccessResult();
        }

        public static async Task<IResult> CheckAsync(params Task<IResult>[] logics)
        {
            foreach (var logic in logics)
            {
                var result = await logic;
                if (!result.Success)
                {
                    return result;
                }
            }
            return new SuccessResult();
        }

        public static IDataResult<T> CheckData<T>(T data, params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return new ErrorDataResult<T>(logic.Message);
                }
            }
            return new SuccessDataResult<T>(data);
        }
    }
}
