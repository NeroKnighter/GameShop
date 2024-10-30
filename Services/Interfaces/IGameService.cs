using GameShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.Domain.Models;

namespace GameShop.Service.Interfaces
{
    public interface IGameService
    {
        BaseResponse<Game> Add(Game model);
        BaseResponse<Game> Update(Game model);
        BaseResponse<Game> Delete(Game model);

    }
}
