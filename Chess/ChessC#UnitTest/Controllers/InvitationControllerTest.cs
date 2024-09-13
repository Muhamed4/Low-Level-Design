using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Controllers;
using Chess_C_.Data;
using Chess_C_.Models;
using ChessC_UnitTest.Data;
using Microsoft.EntityFrameworkCore;

namespace ChessC_UnitTest.Controllers
{
    public class InvitationControllerTest
    {
        [Fact]
        public async Task Send_Invitation_WhenTwoPlayersExistInDataBase_ShouldSendInvitationToReceiverAndReturnTrue()
        {
            // Given
                var dbContext = new InMemoryDbContext();
                var sut = new InvitationController(dbContext);
                Player sender = new Player() {
                    FirstName = "Abdo",
                    LastName = "Morsi",
                    UserName = "Abdo Morsi",
                    Email = "abdomorsi722@gmail.com",
                    Password = "abdo123",
                    Street = "SalahElddinStreet",
                    State = "Almonshaa",
                    ZipCode = "9323",
                    City = "Sohag",
                    Country = "Egypt",
                    AccountStatus = AccountStatus.ACTIVE
                };
                Player receiver = new Player() {
                    FirstName = "Muhamed",
                    LastName = "Morsi",
                    UserName = "Muhamed Morsi",
                    Email = "muhamedmorsi752@gmail.com",
                    Password = "muhamed123",
                    Street = "SalahElddinStreet",
                    State = "Almonshaa",
                    ZipCode = "9323",
                    City = "Sohag",
                    Country = "Egypt",
                    AccountStatus = AccountStatus.ACTIVE
                };
                dbContext.Players.Add(sender);
                dbContext.Players.Add(receiver);
                dbContext.SaveChanges();
            // When
                var result = await sut.SendInvitation(sender.Id, receiver.Id);
            // Then
                Assert.True(result);
        }

        [Fact]
        public async Task Send_Invitation_WhenAyPlayerDoesNotExistInDataBase_ShouldReturnFalse()
        {
            // Given
                var dbContext = new InMemoryDbContext();
                var sut = new InvitationController(dbContext);
                Player sender = new Player() {
                    FirstName = "Abdo",
                    LastName = "Morsi",
                    UserName = "Abdo Morsi",
                    Email = "abdomorsi722@gmail.com",
                    Password = "abdo123",
                    Street = "SalahElddinStreet",
                    State = "Almonshaa",
                    ZipCode = "9323",
                    City = "Sohag",
                    Country = "Egypt",
                    AccountStatus = AccountStatus.ACTIVE
                };
                var receiverId = Guid.NewGuid();
                dbContext.Players.Add(sender);
                dbContext.SaveChanges();
            // When
                var result = await sut.SendInvitation(sender.Id, receiverId);
            // Then
                Assert.False(result);
        }   
    }
}