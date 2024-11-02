using GameShop.Domain;
using GameShop.Domain.Models;
using GameShop.Domain.Models.ViewModels;
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
        public BaseResponse<Game> Add(GameAddViewModel model)
        {
            var game = _gameRepository.GetAll().FirstOrDefault(x => x.Name == model.Name);
            if (game == null)
            {
                game = new Game()
                {
                    Name = model.Name,
                    Description = model.Description,
                    GenreId = model.GenreId,
                    Price = model.Price
                };
                using (var memoryStream = new MemoryStream())
                {
                    model.Image.CopyTo(memoryStream);
                    game.Image = memoryStream.ToArray();
                }
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

        public BaseResponse<Game> Delete(int Id)
        {
            var game = _gameRepository.GetAll().FirstOrDefault(x => x.Id == Id);
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

        public BaseResponse<Game> Update(GameEditViewModel model)
        {
            var game = _gameRepository.GetAll().FirstOrDefault(x => x.Id == model.Id);
            if (game != null)
            {
                game.Name = model.Name;
                game.Description = model.Description;
                game.GenreId = model.GenreId;
                game.Price = model.Price;
                using (var memoryStream = new MemoryStream())
                {
                    model.Image.CopyTo(memoryStream);
                    game.Image = memoryStream.ToArray();
                }

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
