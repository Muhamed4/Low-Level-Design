using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Data;
using Chess_C_.Models;

namespace Chess_C_.Controllers
{
    public class PlayerController
    {
        private readonly AppDbContext _appDbContext;
        public PlayerController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task CreateNewGame() {
            throw new NotImplementedException();
        }

        public async Task JoinGame(Guid InviteId) {
            throw new NotImplementedException();
        }

        public async Task SendInvitation(Guid receiverId) {
            throw new NotImplementedException();
        }

        public async Task<List<Game>> ListPastMatches() {
            throw new NotImplementedException();
        }
    }
}