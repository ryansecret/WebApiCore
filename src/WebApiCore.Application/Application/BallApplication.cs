using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiCore.Application.Models;
using WebApiCore.Application.Models.Ball;
using WebApiCore.DomainModel.WebApiCore;

/// <summary>
/// The Application namespace.
/// </summary>
namespace WebApiCore.Application.Application
{
    public class BallApplication
    {
        public readonly IBallRepository _ballRepository;
        public BallApplication(IBallRepository ballRepository)
        {
            _ballRepository = ballRepository;
        }

        public ResultWithData<string> SayHello(Ball ball)
        {
            var ballEntity = Mapper.Map<Ball, BallEntity>(ball);
            if (ballEntity.IsValid())
            {
                return new ResultWithData<string>(_ballRepository.Hello());
            }

            return GetError<string>(ballEntity);
        }

        public ResultWithData<bool> Save(Ball ball)
        {
            var ballEntity = Mapper.Map<Ball, BallEntity>(ball);
            if (ballEntity.IsValid())
            {
                return new ResultWithData<bool>(_ballRepository.Add(ballEntity));
            }
            return GetError<bool>(ballEntity);
        }

        ResultWithData<T> GetError<T>(BallEntity entity)
        {
            var error = entity.ValidationState.Errors.First();
            return new ResultWithData<T>(default(T),error.ErrorMessage,int.Parse(error.ErrorCode));
        }
 
    }
}
