using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment_4;

namespace Assignment_2
{
    public class PlayersProcessor
    {
        private IRepository _repository;

        public PlayersProcessor(IRepository repository) {
            _repository = repository;
        }

        public Task<Player> Get(Guid id)
        {
            return _repository.GetPlayer(id);
        }

        public Task<Player> GetName(string name)
        {
            return _repository.GetPlayerByName(name);
        }

        public Task<Player[]> GetTag(string tag)
        {
            return _repository.GetPlayerByTag(tag);
        }

        public Task<Player[]> GetAll()
        {
            return _repository.GetAllPlayers();
        }

        public Task<Player> Create(NewPlayer player)
        {
            Player newPlayer = new Player();
            newPlayer.Name = player.Name;
            newPlayer.Id = Guid.NewGuid();
            newPlayer.CreationTime = System.DateTime.Now;
            newPlayer.Level = player.Level;
            newPlayer.Tag = player.Tag;
            newPlayer.items = new List<Item>();
            return _repository.CreatePlayer(newPlayer);
        }

        public Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            return _repository.ModifyPlayer(id, player);
        }

        public Task<Player> UpdatedPlayerName(Guid id, UpdatedPlayerName player)
        {
            return _repository.UpdatePlayerName(id, player);
        }

        public Task<Player> Delete(Guid id)
        {
            return _repository.DeletePlayer(id);
        }
    }
}