using System;
using System.Threading.Tasks;
using Assignment_4;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController
    {
        PlayersProcessor _processor;

        public PlayersController(PlayersProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet("{id:Guid}")]
        public Task<Player> Get(Guid id)
        {
            return _processor.Get(id);
        }

        [HttpGet("{name}")]
        public Task<Player> GetWithName(string name)
        {
            return _processor.GetName(name);
        }
        
        [HttpGet("tag/{tag}")]
        public Task<Player[]> GetWithTag(string tag)
        {
            return _processor.GetTag(tag);
        }

        [HttpGet]
        public Task<Player[]> GetAll()
        {
            return _processor.GetAll();
        }

        [HttpPost]
        public Task<Player> Create([FromBody] NewPlayer player)
        {
            return _processor.Create(player);
        }

        [HttpPut("{id:Guid}")]
        public Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            return _processor.Modify(id, player);
        }

        [HttpPut("{id:Guid}/name")]
        public Task<Player> UpdateName(Guid id, [FromBody] UpdatedPlayerName player)
        {
            return _processor.UpdatedPlayerName(id, player);
        }

        [HttpDelete("{id:Guid}")]
        public Task<Player> Delete(Guid id)
        {
            return _processor.Delete(id);
        }
    }
}