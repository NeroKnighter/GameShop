﻿using GameShop.Domain;
using GameShop.Domain.Models;
using GameShop.Service.Interfaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop.Service.Implementations
{
    public class GameService : IGameService
    {
        private IBaseRepository<Game> _gameRepository;
        public GameService(IBaseRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public BaseResponse<Game> Add(Game model)
        {
            var game = _gameRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (game == null)
            {
                game = model;
                _gameRepository.Create(game);
                return new BaseResponse<Game>
                {
                    Description = "Игра добавлена",
                    StatusCode = "OK"
                };
            }
            else
            {
                return new BaseResponse<Game>
                {
                    Description = "Такая игра уже есть",
                    StatusCode = "Error"
                };
            }
        }

        public BaseResponse<Game> Delete(Game model)
        {
            var game = _gameRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (game != null)
            {
                _gameRepository.Delete(game);
                return new BaseResponse<Game>
                {
                    Description = "Игра удалена",
                    StatusCode = "OK"
                };
            }
            else
            {
                return new BaseResponse<Game>
                {
                    Description = "Игра не найдена",
                    StatusCode = "Error"
                };
            }

        }

        public BaseResponse<Game> Update(Game model)
        {
            var game = _gameRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (game != null)
            {
                game = model;
                _gameRepository.Update(game);
                return new BaseResponse<Game>
                {
                    Description = "Игра обновлена",
                    StatusCode = "OK"
                };
            }
            else
            {
                return new BaseResponse<Game>
                {
                    Description = "Игра не найдена",
                    StatusCode = "Error"
                };
            }
        }
    }
}