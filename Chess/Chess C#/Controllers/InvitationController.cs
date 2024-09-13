using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Data;
using Chess_C_.Models;
using Microsoft.EntityFrameworkCore;

namespace Chess_C_.Controllers
{
    public class InvitationController
    {
        private readonly AppDbContext _appDbContext;
        public InvitationController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task<bool> SendInvitation(Guid sender, Guid receiver) {
            var checkPlayers = await _appDbContext.Players.Where(x => x.Id == sender || x.Id == receiver).ToListAsync();
            if(checkPlayers.Count != 2)
                return false;
            var invitation = new Invitation() { Status = InvitationStatus.ACTIVE, SenderId = sender, ReceiverId = receiver };
            await _appDbContext.Invitations.AddAsync(invitation);
            return true;
        }
    }
}