using GameShop.Domain;
using GameShop.Domain.Models;
using GameShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.IO;
using GameShop.Domain.Models.ViewModels;

namespace GameShop.Controllers
{
    public class GameController : Controller
    {
        private readonly IBaseRepository<Game> _gameRepository;
        private readonly IBaseRepository<Genre> _genreRepository;
        private readonly IGameService _gameService;

        public GameController(IBaseRepository<Game> gameRepository, IGameService gameService, IBaseRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _gameService = gameService;
            _genreRepository = genreRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var Genres = _genreRepository.GetAll().ToList();
            ViewBag.Genres = Genres;
            var games = _gameRepository.GetAll().ToList();
            var Images = games.Select(game => $"data:image/jpeg;base64,{Convert.ToBase64String(game.Image)}").ToList();
            ViewBag.Images = Images;
            return View(_gameRepository.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult Add()
        {
            var Genres = _genreRepository.GetAll().ToList();
            ViewBag.Genres = Genres;
            ViewBag.Value = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Add(GameAddViewModel model)
        {
            var Genres = _genreRepository.GetAll().ToList();
            ViewBag.Genres = Genres;

            if (ModelState.IsValid)
            {
                var response = _gameService.Add(model);
                if (response.StatusCode == "OK")
                {
                    return RedirectToAction("Index", "Game");
                }

            }
            return View();
        }
    }
}
