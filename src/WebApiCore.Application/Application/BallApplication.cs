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

        public OutputWithData<string> SayHello(Ball ball)
        {
            var ballEntity = Mapper.Map<Ball, BallEntity>(ball);
            if (ballEntity.IsValid())
            {
                return new OutputWithData<string>(_ballRepository.Hello());
            }

            return GetError<string>(ballEntity);
        }

        public OutputWithData<bool> Save(Ball ball)
        {
            var ballEntity = Mapper.Map<Ball, BallEntity>(ball);
            if (ballEntity.IsValid())
            {
                return new OutputWithData<bool>(_ballRepository.Add(ballEntity));
            }
            return GetError<bool>(ballEntity);
        }

        OutputWithData<T> GetError<T>(BallEntity entity)
        {
            var error = entity.ValidationState.Errors.First();
            return new OutputWithData<T>(default(T),error.ErrorMessage,int.Parse(error.ErrorCode));
        }
 
    }
}
