using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class ItemsProcessor
    {
        private IRepository _repository;

        public ItemsProcessor(IRepository repository) {
            _repository = repository;
        }

        public Task<Item> Get(Guid playerid, Guid itemid)
        {
            return _repository.GetItem(playerid, itemid);
        }

        public Task<Item[]> GetAll(Guid playerId)
        {
            return _repository.GetAllItems(playerId);
        }

        public Task<Item> Create(Guid playerid, NewItem item)
        {
            Player player = _repository.GetPlayer(playerid).Result;
            if (player.Level < 3 && item.Type == "Sword") 
            {
                throw new PlayerNallikallioException();
            }
            Item newItem = new Item();
            newItem.Name = item.Name;
            // set other values for new item
            newItem.Id = Guid.NewGuid();
            newItem.CreationTime = item.CreationDate;
            return _repository.CreateItem(playerid, newItem);
        }

        public Task<Item> Modify(Guid playerid, Guid itemid, ModifiedItem item)
        {
            return _repository.ModifyItem(playerid, itemid, item);
        }

        public Task<Item> Delete(Guid playerid, Guid itemid)
        {
            return _repository.DeleteItem(playerid, itemid);
        }
    }
}